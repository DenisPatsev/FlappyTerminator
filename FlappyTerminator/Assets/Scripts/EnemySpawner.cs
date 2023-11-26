using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private SpawnPoint[] _spawners;
    [SerializeField] private float _delay;

    private void Start()
    {
        Initialize(_enemies);

        StartCoroutine(GenerateEnemy());
    }

    private void Update()
    {

        DisableObjects();
    }

    private IEnumerator GenerateEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            float spawnerIndex = Random.Range(0, _spawners.Length);

            if (TryGetObject(out Enemy enemy))
            {
                for (int i = 0; i < _spawners.Length; i++)
                {
                    if (i == spawnerIndex)
                    {
                        SetEnemy(enemy, _spawners[i].transform.position);
                    }
                }
            }

            yield return wait;
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);

        enemy.transform.position = spawnPoint;
    }
}
