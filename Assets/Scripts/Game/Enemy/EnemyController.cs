using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRange = 30f;
    public int enemyHealth = 3;
    public bool startSpawning = false;
    public float enemySpawnFrequency = 4f;
    private bool spawnerOn = false;
    private int enemiesKilled = 0;

    public int enemyCounter = 0;

    void Update(){
        bool flagValue = SingletonGameStartFlag.Instance.flag;
        if (flagValue && !spawnerOn)
        {
            spawnerOn = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        int maxEnemies = 3;

        while (enemyCounter < maxEnemies)
        {
            yield return new WaitForSeconds(enemySpawnFrequency);

            float spawnX = player.position.x + Random.Range(-spawnRange, spawnRange);
            float spawnZ = player.position.z + Random.Range(-spawnRange, spawnRange);
            Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.transform.SetParent(gameObject.transform);
            enemy.GetComponent<EnemyAI>().player = player;

            enemyCounter++;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Enemies: " + enemyCounter);
        GUI.Label(new Rect(10, 30, 100, 20), "Killed: " + enemiesKilled);
    }

    public void DecrementEnemyCounter()
    {
        enemiesKilled++;
        enemyCounter--;
    }
}
