using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemyPrefab;
    // set up for Object Pooling
    public GameObject[] enemyInstances; // array that will contain object instances
    public int numberOfInstances = 10;
    public int instanceIndex = 0;

    public float timeToSpawnMin = 1f;
    public float timeToSpawnMax = 5f;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        ReloadEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime < 0.0f)
        {
            SpawnEnemy();
            spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        }

    }

    void ReloadEnemy()
    {
        spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        enemyInstances = new GameObject[numberOfInstances];

        for (int i = 0; i < numberOfInstances; i++)
        {
            enemyInstances[i] = Instantiate(enemyPrefab);
            enemyInstances[i].transform.position = transform.position;
            enemyInstances[i].SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        enemyInstances[instanceIndex].SetActive(true);
        enemyInstances[instanceIndex].transform.position = transform.position;
        instanceIndex++;
        if (instanceIndex == numberOfInstances)
        {
            instanceIndex = 0;
            ReloadEnemy();
        }
    }
}
