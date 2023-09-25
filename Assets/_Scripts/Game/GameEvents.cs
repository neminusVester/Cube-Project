using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoSingleton<GameEvents>
{
    public event Action<GameObject> OnCubePicked;
    public event Action<GameObject> OnWallCollision;
    public event Action OnPlayerJumped;
    public event Action OnPlayerLose;
    public event Action OnPlayerStarted;
    public event Action OnLevelRestarted;
    public event Action OnFinishTrigger;
    public event Action OnNextLevel;
    public event Action<string> OnSceneTransition;
    public event Action<bool> OnAnimationOver;
    public event Action OnSceneLoaded;

    public void PlayerTouchCube(GameObject cube)
    {
        OnPlayerJumped?.Invoke();
        OnCubePicked?.Invoke(cube);
    }

    public void PlayerTouchWall(GameObject cube) => OnWallCollision?.Invoke(cube);

    public void StickmanTouchWall() => OnPlayerLose?.Invoke();

    public void PlayerStartGame() => OnPlayerStarted?.Invoke();

    public void PlayerRestartGame() => OnLevelRestarted?.Invoke();

    public void PlayerTouchFinish() => OnFinishTrigger?.Invoke();

    public void InstantiateNextLevel() => OnNextLevel?.Invoke();

    public void SwitchScene(string trigger)
    {
        OnSceneTransition?.Invoke(trigger);
    }

    public void EndAnimation(bool end) => OnAnimationOver?.Invoke(end);

    public void NewSceneLoaded() => OnSceneLoaded?.Invoke();

}
