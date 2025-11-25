using UnityEngine;

public class BuzzSawSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject buzzLgPrefab;
    
    // set up for Object Pooling
    [Header("Objects Loaded")]
    public GameObject[] buzzInstances; // array that will contain object instances
    public int numberOfInstances = 10;
    public int instanceIndex = 0;

    public float timeToSpawnMin = 1f;
    public float timeToSpawnMax = 5f;
    public float spawnTime;

    [Header("Vertical Movement Range")]
    public float minY = -3f;
    public float maxY = 3f;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;      // how fast the spawner moves between points
    public float waitTime = 0.4f;     // how long it waits before choosing next spot

    private float targetY;
    private float waitTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        buzzInstances = new GameObject[numberOfInstances];
        ReloadBuzzSaw();
        targetY = transform.position.y;
        PickNewTargetY();
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

        // get current position
        Vector3 pos = transform.position;

        // move from current pos.y towards the target y at speed * delta
        pos.y = Mathf.MoveTowards(pos.y, targetY, moveSpeed * Time.deltaTime);
        transform.position = pos;

        // If we've reached the target, start waiting
        if (Mathf.Approximately(pos.y, targetY))
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                PickNewTargetY();
            }
        }

    }
    void SpawnBuzzLg()
    {
        buzzInstances[instanceIndex].SetActive(true);
        buzzInstances[instanceIndex].transform.position = transform.position;
        instanceIndex++;
        if (instanceIndex == numberOfInstances) 
        {
            if (instanceIndex == numberOfInstances)
            {
                instanceIndex = 0;
                ReloadBuzzSaw();
            }
        }
    }
    void ReloadBuzzSaw()
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
    void PickNewTargetY()
    {
        targetY = Random.Range(minY, maxY);
    }
}
