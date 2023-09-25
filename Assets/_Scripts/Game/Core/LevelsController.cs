using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    private int _levelsCount;
    private int _lastLoadedScene = 1;
    private bool _animationOver; // if false - sceneClosing animation end, if true - sceneOpening animation end
    private AsyncOperation _loadingSceneOperation;

    private void Awake()
    {
        _levelsCount = SceneManager.sceneCountInBuildSettings;
    }

    private void Start()
    {
        LoadNextLevel();
        GameEvents.Instance.OnLevelRestarted += RestartLevel;
        GameEvents.Instance.OnNextLevel += SetNewCurrentLevel;
        GameEvents.Instance.OnNextLevel += LoadNextLevel;
        GameEvents.Instance.OnAnimationOver += CheckAnimationsOver;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnLevelRestarted -= RestartLevel;
        GameEvents.Instance.OnNextLevel -= SetNewCurrentLevel;
        GameEvents.Instance.OnNextLevel -= LoadNextLevel;
        GameEvents.Instance.OnAnimationOver -= CheckAnimationsOver;
    }

    private void LoadNextLevel()
    {
        UnloadCurrentLevel(_lastLoadedScene);
        var levelLoadIndex = SLS.Data.CurrentLevelIndex.Value % _levelsCount;
        if (levelLoadIndex == 0) levelLoadIndex++;
        StartCoroutine(LoadLevel(levelLoadIndex));
        _lastLoadedScene = levelLoadIndex;
    }

    private void UnloadCurrentLevel(int levelIndex)
    {
        GameEvents.Instance.SwitchScene("sceneEnd");
        var retrievedScene = SceneManager.GetSceneByBuildIndex(levelIndex);
        if (retrievedScene.IsValid())
        {
            SceneManager.UnloadSceneAsync(levelIndex);
        }
    }

    private void RestartLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        UnloadCurrentLevel(currentSceneIndex);
        StartCoroutine(LoadLevel(currentSceneIndex));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitUntil(() => _animationOver == false); 
        yield return _loadingSceneOperation = SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(levelIndex));
        GameEvents.Instance.NewSceneLoaded();
        GameEvents.Instance.SwitchScene("sceneStart");
    }

    private void SetNewCurrentLevel()
    {
        SLS.Data.CurrentLevelIndex.Value++;
    }

    public void CheckAnimationsOver(bool over)
    {
        _animationOver = over;
    }
}
