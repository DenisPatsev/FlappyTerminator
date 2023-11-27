using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bullet;

    private Player _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBullet bullet))
        {
            Die();
            Destroy(collision);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (gameObject.activeSelf == true)
            {
                Instantiate(_bullet, transform.position, Quaternion.identity);
                var delay = new WaitForSeconds(_delay);

                yield return delay;
            }
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        _target.AddScore();
    }

    public void Initialize(Player target)
    {
        _target = target;
    }
}
