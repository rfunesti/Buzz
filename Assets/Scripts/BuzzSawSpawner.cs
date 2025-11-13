using UnityEngine;

public class BuzzSawSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject buzzLgPrefab;
    // set up for Object Pooling
    public GameObject[] buzzInstances; // array that will contain object instances
    public int numberOfInstances = 10;
    public int instanceIndex = 0;

    public float timeToSpawnMin = 1f;
    public float timeToSpawnMax = 5f;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        buzzInstances = new GameObject[numberOfInstances];

        for (int i = 0; i < numberOfInstances; i++)
        {
            buzzInstances[i] = Instantiate(buzzLgPrefab);
            buzzInstances[i].transform.position = transform.position;
            buzzInstances[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime < 0.0f)
        {
            SpawnBuzzLg();
            spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        }

    }
    void SpawnBuzzLg()
    {
        buzzInstances[instanceIndex].SetActive(true);
        buzzInstances[instanceIndex].transform.position = transform.position;
        instanceIndex++;
        if (instanceIndex == numberOfInstances) instanceIndex = 0;
    }
}
