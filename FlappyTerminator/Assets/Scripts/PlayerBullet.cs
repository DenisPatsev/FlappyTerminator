using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;

    private void Update()
    {
        var destroyPoint = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.5f));

        transform.Translate(_player.transform.right * _speed * Time.deltaTime);

        if (transform.position.x > destroyPoint.x)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(Player player)
    {
        _player = player;
    }
}
