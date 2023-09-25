using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3(0f, 0f, -15f);
    [SerializeField] private Transform target;

    void LateUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 targetPosition = target.position + _offset;
        targetPosition.x = transform.position.x;
        targetPosition.y = transform.position.y;
        transform.position = targetPosition;
    }
}
