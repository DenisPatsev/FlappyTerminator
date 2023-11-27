using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        var destroyPoint = Camera.main.ViewportToWorldPoint(new Vector2(-0.5f, 0.5f));

        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (transform.position.x < destroyPoint.x)
        {
            Destroy(gameObject);
        }
    }
}
