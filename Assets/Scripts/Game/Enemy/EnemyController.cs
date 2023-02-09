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
    public int enemiesKilled = 0;
    private Animator anim;


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

        while (true)
        {
            if (enemyCounter < maxEnemies){
                yield return new WaitForSeconds(enemySpawnFrequency);

                float spawnX = player.position.x + Mathf.Clamp(Random.Range(-spawnRange, spawnRange), -spawnRange + 10, spawnRange - 10);
                float spawnZ = player.position.z + Mathf.Clamp(Random.Range(-spawnRange, spawnRange), -spawnRange + 10, spawnRange - 10);
                Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);

                GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                anim = enemy.GetComponent<Animator>();
                enemy.transform.SetParent(gameObject.transform);
                enemy.GetComponent<EnemyAI>().player = player;

                enemyCounter++;
            }else{
                yield return new WaitForSeconds(enemySpawnFrequency);
            }
        }
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 14;
        GUI.Label(new Rect(10, 10, 100, 20), "Enemies: " + enemyCounter);
        GUI.Label(new Rect(10, 30, 100, 20), "Killed: " + enemiesKilled);
    }

    public void DecrementEnemyCounter()
    {
        enemiesKilled++;
        enemyCounter--;
    }
}
