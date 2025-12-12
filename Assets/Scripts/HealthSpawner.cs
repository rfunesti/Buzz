using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSpawner : MonoBehaviour
{    
    public GameObject healthPrefab;
    // set up for Object Pooling
    public GameObject[] healthInstances; // array that will contain object instances
    public int numberOfInstances = 5;
    public int instanceIndex = 0;

    public float timeToSpawnMin = 10f;
    public float timeToSpawnMax = 20f;

    [SerializeField]
    private float spawnTime;

    public bool moreHealth = true;
    public Text noMoreHealth;

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
        if (moreHealth)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0.0f)
            {
                SpawnHealth();
                spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
            }
        }
    }
    void SpawnHealth()
    {
            healthInstances[instanceIndex].SetActive(true);
            healthInstances[instanceIndex].transform.position = transform.position;
            instanceIndex++;
            if (instanceIndex == numberOfInstances)
            {
                instanceIndex = 0;
                moreHealth = false;
                ShowNoHealthMessage();
        }
    }
    public void ShowNoHealthMessage()
    {
        if (noMoreHealth == null) return;

        noMoreHealth.text = "You're out of health packs!!";            
        StartCoroutine(HideMessage());         
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSecondsRealtime(2f);
        noMoreHealth.text = "";
    }
}


