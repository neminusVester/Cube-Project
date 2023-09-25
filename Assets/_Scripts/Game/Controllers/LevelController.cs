using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnTransform;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private InputController inputController;
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private Transform levelSpawnTransform;
    private PlayerController _player;
    private GameObject _currentLevel;
    private int _currentLevelIndex = 0;

    public void Init(InputController inputController)
    {
        _currentLevelIndex = SLS.Data.CurrentLevelIndex.Value;
        InstantiateCurrentLevel();
        _player = Instantiate(playerController, playerSpawnTransform);
        // _player.Init(inputController);
        // cameraMovement.Init(_player.transform);

        /* GameEvents.Instance.OnLevelRestarted += InstantiateCurrentLevel;
        GameEvents.Instance.OnFinishTrigger += SetNewLevelIndex;
        GameEvents.Instance.OnNextLevel += InstantiateCurrentLevel; */
    }

    private void OnDestroy()
    {
        /* GameEvents.Instance.OnLevelRestarted -= InstantiateCurrentLevel;
        GameEvents.Instance.OnFinishTrigger -= SetNewLevelIndex;
        GameEvents.Instance.OnNextLevel -= InstantiateCurrentLevel; */
    }

    private void InstantiateCurrentLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
            _currentLevel = null;
        }
        _currentLevel = Instantiate(levels[_currentLevelIndex], levelSpawnTransform);
    }

    private void SetNewLevelIndex()
    {
        if(_currentLevelIndex + 1 == levels.Count) return;
        SLS.Data.CurrentLevelIndex.Value += 1;
        // _currentLevelIndex = SLS.Data.CurrentLevelIndex.Value;

    }
}
