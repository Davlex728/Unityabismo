using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnTimer = 2f;
    public int maxEnemies = 5;
    public Transform Player;

    private float timer = 0f;
    private int enemiesSpawned = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned >= maxEnemies) return;
        
        timer += Time.deltaTime;

        if (timer > spawnTimer)
        {
            GameObject e = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Enemy2D enemyScript = e.GetComponent<Enemy2D>();
            if (enemyScript != null)
                enemyScript.target = Player;

            enemiesSpawned++;
            timer = 0f;
        }
    }
}
