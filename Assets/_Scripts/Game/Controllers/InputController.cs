using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    private float _horizontalDirection;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public float GetHorizontalDirection()
    {
        if (Input.GetMouseButton(0))
        {
            _horizontalDirection = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            _horizontalDirection = 0;
        }
        return _horizontalDirection;
    }

    //For mobile
    /* public float GetHorizontalDirection()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _horizontalDirection = Input.GetTouch(0).deltaPosition.y;
        }
        return _horizontalDirection;
    } */
}
