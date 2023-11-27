using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerBullet _bullet;
    [SerializeField] private TMP_Text _scoreScreen;

    private float _score;
    private Rigidbody2D _body;
    private Player _player;
    private string _startText;

    public UnityAction Died;

    public float Score => _score;

    private void Start()
    {
        _score = 0;
        _player = GetComponent<Player>();
        _body = GetComponent<Rigidbody2D>();
        _startText = _scoreScreen.text;
        _scoreScreen.text += " " + _score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBullet bullet) == false)
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
        Died.Invoke();
    }

    public void Shoot()
    {
        PlayerBullet bullet = Instantiate(_bullet, transform.position, transform.rotation);
        bullet.Initialize(_player);
    }

    public void AddScore()
    {
        _score++;
        _scoreScreen.text = _startText;
        _scoreScreen.text += " " + _score.ToString();
        Debug.Log(_score);
    }

    public void Restart()
    {
        transform.position = Vector3.zero;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        _body.velocity = Vector3.zero;
    }
}
