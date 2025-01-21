using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("---Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TerrainGenerator _terrainGenerator;
    [SerializeField] private Grounded _playerGrounded;
    [Header("---Raycast props")]
    [SerializeField] private float _length;
    [SerializeField] private LayerMask _groundMask;
    [Header("---Speed & Jump props")]
    [SerializeField] private AnimationCurve _difficulty;
    [SerializeField] private float _speedMultipilier;
    [SerializeField] private float _jumpValue;
    [SerializeField] private float _jumpDecreaseSpeed;
    [SerializeField] private float _jumpMultiplier;


    private float _currentJumpValue;
    private int _direction = 1;
    private RaycastHit2D _hit2D;

    void Awake()
    {
        _currentJumpValue = _jumpValue;
    }
    private void Update()
    {

        transform.position += Vector3.right * _direction * Time.deltaTime * _speedMultipilier;

        _hit2D = Physics2D.Raycast(transform.position, Vector2.right * _direction, _length, _groundMask);
        if (_hit2D.collider != null)
        {
            _direction *= -1;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && _playerGrounded.IsGrounded())
        {
            _rb.AddForce(Vector2.up * _currentJumpValue * 4, ForceMode2D.Impulse);
        }
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _currentJumpValue * _jumpMultiplier);
            _currentJumpValue -= Time.deltaTime * _jumpDecreaseSpeed;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            _rb.linearVelocityY /= 2;
        }
        if (_playerGrounded.IsGrounded())
        {
            _currentJumpValue = _jumpValue;
        }
    }

}