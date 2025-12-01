using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject healthPrefab;
    // set up for Object Pooling
    public GameObject[] healthInstances; // array that will contain object instances
    public int numberOfInstances = 5;
    public int instanceIndex = 0;

    public float timeToSpawnMin = 10f;
    public float timeToSpawnMax = 20f;
    public float spawnTime;

    bool moreHealth = true;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        healthInstances = new GameObject[numberOfInstances];

        for (int i = 0; i < numberOfInstances; i++)
        {
            healthInstances[i] = Instantiate(healthPrefab);
            healthInstances[i].transform.position = transform.position;
            healthInstances[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime < 0.0f)
        {
            SpawnHealth();
            spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        }

    }
    void SpawnHealth()
    {
        if (moreHealth)
        {
            healthInstances[instanceIndex].SetActive(true);
            healthInstances[instanceIndex].transform.position = transform.position;
            instanceIndex++;
            if (instanceIndex == numberOfInstances)
            {
                instanceIndex = 0;
                moreHealth = false;
            }
        }

    }
}


