using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputController _inputController;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float horizontalSpeed = 50f;
    private Vector3 cubeOffset = new Vector3(0f, 0.5f, 0f);
    private float _horizontalDirection;
    private float _horizontalPositionLimit = 2f;
    private RaycastHit _hit;
    private Transform _playerParrent;

    public void Start()
    {
        // var playerPos = transform;
        _inputController = InputController.Instance;
        _playerParrent = transform.parent;
        GameEvents.Instance.OnPlayerJumped += PlayerJump;
        StartCoroutine(CheckPlayerStart());
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnPlayerJumped -= PlayerJump;
    }

    private IEnumerator CheckPlayerStart()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        GameEvents.Instance.PlayerStartGame();
    }

    private void Update()
    {
        _horizontalDirection = _inputController.GetHorizontalDirection();
    }

    private void FixedUpdate()
    {
        PlayerHorizontalMove();
    }

    private void PlayerJump()
    {
        _playerAnimator.SetBool("Jump", true);
        transform.position += cubeOffset;
    }

    /*  private void PlayerMovement()
     {
         var newHorizontalPosition = transform.position.x + _horizontalDirection * horizontalSpeed * Time.deltaTime;
         newHorizontalPosition = Mathf.Clamp(newHorizontalPosition, -_horizontalPositionLimit, _horizontalPositionLimit);
         transform.position = new Vector3(newHorizontalPosition, transform.position.y, transform.position.z);
     } */

    private void PlayerHorizontalMove()
    {
        /* if (!(transform.position.x > _playerParrent.position.x + 2f))
        {
            transform.Translate(Vector3.right * _horizontalDirection * horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(_playerParrent.position.x + 2f, transform.position.y, transform.position.z);
        } */

        // transform.Translate(transform.right * _horizontalDirection * horizontalSpeed * Time.deltaTime);
        var newHorizontalPosition = transform.localPosition.y + _horizontalDirection * horizontalSpeed * Time.deltaTime;
        newHorizontalPosition = Mathf.Clamp(newHorizontalPosition, -_horizontalPositionLimit, _horizontalPositionLimit);
        transform.localPosition = new Vector3(transform.localPosition.x, newHorizontalPosition, transform.localPosition.z);
    }

}
