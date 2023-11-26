using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
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
            Instantiate(_bullet, transform.position, Quaternion.identity);
            var delay = new WaitForSeconds(_delay);

            yield return delay;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);

        FindAnyObjectByType<Player>().AddScore();
    }
}
