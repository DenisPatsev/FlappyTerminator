using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacity;

    private List<Enemy> _pool = new List<Enemy>();

    protected void Initialize(Enemy[] _prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var index = Random.Range(0, _prefabs.Length);

            Enemy enemy = Instantiate(_prefabs[index], _container.transform.position, Quaternion.identity);
            enemy.gameObject.SetActive(false);
            _pool.Add(enemy);
        }
    }

    protected bool TryGetObject(out Enemy result)
    {
        result = _pool.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    protected void DisableObjects()
    {
        Vector3 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (Enemy enemy in _pool)
        {
            if (enemy.gameObject.activeSelf == true)
            {
                if (enemy.transform.position.x < disablePoint.x)
                {
                    enemy.gameObject.SetActive(false);
                }
            }
        }
    }
}
