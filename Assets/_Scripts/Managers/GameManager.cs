using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uiManager;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public Transform[] enemySpawnPoints;
    public Transform[] playerSpawnPoints;
    public Player player;

    [SerializeField]
    private int initialEnemyCount;
    [SerializeField]
    private int maxEnemyCount;
    private int currentEnemyCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnPlayer();
        for (int i = 0; i < initialEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyKilled;
        SpawnEnemy();
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void SpawnPlayer()
    {
        Transform spawnPoint = GetActiveSpawnPoint();
        if (spawnPoint != null)
        {
            GameObject playerGO = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            player = playerGO.GetComponent<Player>();
            spawnPoint.gameObject.SetActive(false);
        }
    }

    private Transform GetActiveSpawnPoint()
    {
        for (int i = 0; i < playerSpawnPoints.Length; i++)
        {
            if (playerSpawnPoints[i].gameObject.activeInHierarchy)
            {
                return playerSpawnPoints[i];
            }
        }

        return null;
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount > maxEnemyCount)
        {
            return;
        }
        Vector3 spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].transform.position;
        Vector3 spawnPosition = new Vector3(spawnPoint.x + Random.Range(-2, 3), spawnPoint.y, spawnPoint.z + Random.Range(-2, 3));
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        spawnedEnemy.SetActive(true);
        currentEnemyCount++;
    }

    public void HandleEnemyKilled(Enemy enemy)
    {
        Debug.Log("ENEMY KILLED");
        player.points++;
        uiManager.UpdatePoints();
        currentEnemyCount--;
        StartCoroutine(SpawnTimer(() => SpawnEnemy(), 5));
    }

    private IEnumerator SpawnTimer(System.Action callback, float duration)
    {
        float percent = 0;
        WaitForFixedUpdate update = new WaitForFixedUpdate();

        while (percent < duration)
        {
            percent += Time.deltaTime;
            yield return update;
        }

        callback();
    }

    public void GameOver(bool timeOver = false)
    {
        if (timeOver)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}