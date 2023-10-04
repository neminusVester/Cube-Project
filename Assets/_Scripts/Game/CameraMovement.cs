using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    /*private void MoveToTarget()
    {
        Vector3 targetPosition = target.position + _offset;
        targetPosition.x = transform.position.x;
        targetPosition.y = transform.position.y;
        transform.position = targetPosition;
    }*/

    /*private void LateUpdate()
    {
        transform.localPosition =
            new Vector3(player.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }*/
}
