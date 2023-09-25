using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private RaycastHit _hit;
    private Vector3 _stickmanDirection = Vector3.forward;

    private void FixedUpdate()
    {
        CheckStickmanRaycast();
    }

    private void CheckStickmanRaycast()
    {
        if (Physics.Raycast(transform.position, _stickmanDirection, out _hit, 0.5f))
        {
            if (_hit.transform.name == "Wall")
            {
                GameEvents.Instance.StickmanTouchWall();
            }
        }
    }
}
