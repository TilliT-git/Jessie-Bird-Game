using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Player Rigitbody")]
    private Rigidbody _playerRb;

    [Header("Obstacle")]
    [SerializeField] private GameObject _obstacle;

    [Header("Player Move")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _bordersRot;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _speedRot;

    [Header("Boolean Values")]
    private float _jumpTimer = 0f;
    private bool _isJumping = false;

    [Header("Actions")]
    public System.Action OnPlayerJump;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        if (Time.timeScale >= 1f && !IsPointerOverUI() && Input.GetMouseButtonDown(0)) PlayerJump();

        if (_isJumping)
        {
            _jumpTimer -= Time.deltaTime;
            if (_jumpTimer <= 0)
            {
                _isJumping = false;
            }
        }

        PlayerRotation();
    }

    private bool IsPointerOverUI()
    {
        if (EventSystem.current == null) return false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
        }
        else
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }

    private void PlayerJump()
    {
        _playerRb.velocity = Vector3.zero;
        _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isJumping = true;
        _jumpTimer = _jumpDuration;
        OnPlayerJump?.Invoke();
    }

    private void PlayerRotation()
    {
        Quaternion targetRot;

        if (_isJumping)
        {
            targetRot = Quaternion.Euler(0f, 0f, _bordersRot);
        }
        else
        {
            targetRot = Quaternion.Euler(0f, 0f, -_bordersRot);
        }

        Quaternion newRot = Quaternion.Lerp(_playerRb.transform.rotation, targetRot, Time.deltaTime * _speedRot);
        _playerRb.MoveRotation(newRot);
    }
}