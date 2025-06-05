using Rnd = System.Random;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn References")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject groundAndr;
    [SerializeField] private GameObject ground;

    [Header("Spawn Timings")]
    [SerializeField] private float timeBetweenSpawnsSec = 3f;
    [SerializeField] private float minTimeBetweenSpawnsSec = 0.1f;
    [SerializeField] private float timeGapDecrMod = 0.03f;

    [Header("Spawn Quantity")]
    [SerializeField] private float obstaclesPerSpawn = 1;
    [SerializeField] private float obstaclesIncrTimeMod = 0.1f;
    private int maxObstaclesPerSpawn;

    [Header("Obstacle Force")]
    [SerializeField] private Vector3 constForce = new Vector3(0, -40, -30);
    [SerializeField] private Vector3 constForceIncrPerSpawn = new Vector3(0, -2, -2);
    [SerializeField] private Vector3 maxConstForce = new Vector3(0, -70, -60);

    private void Awake()
    {
        ground.SetActive(Application.platform != RuntimePlatform.Android);
        groundAndr.SetActive(Application.platform == RuntimePlatform.Android);
    }

    private void Start()
    {
        maxObstaclesPerSpawn = Mathf.CeilToInt(spawnPoints.Length * 0.7f);
        // maxObstaclesPerSpawn = 2;
        StartCoroutine(spawnObstacles());
    }

    private void Update()
    {
        if (timeBetweenSpawnsSec >= minTimeBetweenSpawnsSec)
            timeBetweenSpawnsSec -= (timeGapDecrMod * Time.deltaTime);

        if (obstaclesPerSpawn < maxObstaclesPerSpawn)
            obstaclesPerSpawn += (obstaclesIncrTimeMod * Time.deltaTime);
    }

    private IEnumerator spawnObstacles() 
    {
        while (true)
        {
            GameObject obstacleGroup = new GameObject("Obstacle Group");
            int[] spawns = new int[Mathf.FloorToInt(obstaclesPerSpawn)];
            for (int i = 0; i < spawns.Length; i++) spawns[i] = -1;

            for (int i = 0; i < spawns.Length; i++)
            {
                GameObject obstacle = Instantiate(obstaclePrefab);

                int random = new Rnd().Next(0, spawnPoints.Length);
                for (int j = 0; j < spawns.Length; j++)
                {
                    while (random == spawns[j])
                    {
                        random = new Rnd().Next(0, spawnPoints.Length);
                        j = 0;
                    }
                }

                spawns[i] = random;

                if (Application.platform == RuntimePlatform.Android)
                {
                    while ((spawns[Mathf.FloorToInt(spawns.Length / 2.1f)] == 1 && spawns[Mathf.FloorToInt(spawns.Length / 2.1f) + 1] == 2)
                        || (spawns[Mathf.FloorToInt(spawns.Length / 2.1f)] == 2 && spawns[Mathf.FloorToInt(spawns.Length / 2.1f) + 1] == 1))
                    {
                        random = new Rnd().Next(0, spawnPoints.Length);
                        spawns[Mathf.FloorToInt(spawns.Length / 2.1f) + 1] = random;

                        for (int j = 0; j < spawns.Length; j++)
                        {
                            while (random == spawns[j])
                            {
                                random = new Rnd().Next(0, spawnPoints.Length);
                                spawns[Mathf.FloorToInt(spawns.Length / 2.1f) + 1] = random;
                                j = 0;
                            }
                        }
                    }

                    obstacle.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                }

                obstacle.transform.position = spawnPoints[random].transform.position;
                obstacle.transform.SetParent(obstacleGroup.transform);
                obstacle.GetComponent<ConstantForce>().force = constForce;

                if (Mathf.Abs(constForce.y) < Mathf.Abs(maxConstForce.y) && Mathf.Abs(constForce.z) < Mathf.Abs(maxConstForce.z))
                    constForce += constForceIncrPerSpawn;
            }

            obstacleGroup.transform.SetParent(transform);
            StartCoroutine(destroyObstacle(obstacleGroup));

            yield return new WaitForSeconds(timeBetweenSpawnsSec);
        }
    }


    private IEnumerator destroyObstacle(GameObject gObj)
    {
        yield return new WaitForSeconds(6.5f);
        Destroy(gObj);
        UIManager.instance.incrScore();
    }
}
