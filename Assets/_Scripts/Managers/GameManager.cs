using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObjectPooler zombiePool;
    public ObjectPooler bulletPool;
    public Transform[] enemySpawnPoints;
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += DespawnEnemy;
        SpawnEnemy();
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= DespawnEnemy;
    }

    public void SpawnEnemy()
    {
        GameObject enemyToSpawn = zombiePool.GetPooledObject();
        enemies.Add(enemyToSpawn);
        enemyToSpawn.transform.position = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position;
        enemyToSpawn.SetActive(true);
    }

    private void DespawnEnemy(Enemy enemy)
    {
        enemies.Remove(enemy.gameObject);
    }
}
