using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private RaycastHit _hit;
    private float _raycastDistance = 1f;
    private bool _isStack = false;
    private Vector3 _cubeDiretion = Vector3.back;
    private Vector3 _cubePosition;
    private Vector3 _cubeOffset = new Vector3(0f, 0.3f, 0f);
    private float _radius = 0.6f;

    private void Start()
    {
        _cubePosition = this.transform.position;
    }

    private void FixedUpdate()
    {
        CheckCubeRaycast();
        // CheckCubeSfere(_cubePosition, _radius);
    }

    /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_cubePosition, _radius);
    } */

    //переробить через Physics.OverlapSphere
    /* private void CheckCubeSfere(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != this.gameObject)
            {
                if (hitCollider.transform.name == "Wall")
                {
                    GameEvents.Instance.PlayerTouchWall(this.gameObject);
                }
                else if (!_isStack)
                {
                    _isStack = true;
                    GameEvents.Instance.PlayerTouchCube(this.gameObject);
                    Debug.Log(hitCollider.transform.name);
                }
            }

        }
    } */

    private void CheckCubeRaycast()
    {
        if (Physics.Raycast(transform.position, Vector3.back, out _hit, _raycastDistance))
        {
            if (!_isStack)
            {
                _isStack = true;
                GameEvents.Instance.PlayerTouchCube(this.gameObject);
                this.gameObject.tag = "Player";
            }
        }

        if (Physics.Raycast(transform.position, Vector3.forward, out _hit, _raycastDistance))
        {
            if (_hit.transform.name == "Wall")
            {
                GameEvents.Instance.PlayerTouchWall(this.gameObject);
            }
        }
    }
}
