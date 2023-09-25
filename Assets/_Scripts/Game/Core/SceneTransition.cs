using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private Animator _transitionAnimator;

    private void Start()
    {
        _transitionAnimator = GetComponent<Animator>();
        GameEvents.Instance.OnSceneTransition += SetAnimationTriger;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnSceneTransition -= SetAnimationTriger;
    }

    private void SetAnimationTriger(string trigger)
    {
        _transitionAnimator.SetTrigger(trigger);
    }

    public void ClosingOver()
    {
        GameEvents.Instance.EndAnimation(false);
    }

    public void OpeningOver()
    {
        GameEvents.Instance.EndAnimation(true);
    }
}
