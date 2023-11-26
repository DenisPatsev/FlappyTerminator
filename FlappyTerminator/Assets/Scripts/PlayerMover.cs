using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _rotationSpeed;

    private Quaternion _RotationUp;
    private Quaternion _RotationDown;
    private Quaternion _startRotation;

    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();

        _playerRigidbody.velocity = Vector2.zero;
    }

    private void Start()
    {
        _RotationUp = Quaternion.Euler(0, 0, _maxRotationZ);
        _RotationDown = Quaternion.Euler(0, 0, _minRotationZ);
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerRigidbody.velocity = new Vector2(_speed * Time.deltaTime, 0);
            transform.rotation = _RotationUp;
            _playerRigidbody.AddForce(Vector2.up * _force, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _RotationDown, _rotationSpeed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        transform.rotation = _startRotation;
    }
}
