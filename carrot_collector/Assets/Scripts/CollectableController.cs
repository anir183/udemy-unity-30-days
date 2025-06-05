using Rnd = System.Random;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public int score { get; private set; }
    public static CollectableController instance { get; private set; }

    [SerializeField] private GameObject collectible;
    [SerializeField] private Vector2 spawnQuantity = new Vector2(17, 32);
    [SerializeField] private Vector2 spawnBounds = new Vector2(30, 15);

    private int spawned;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        score = 0;
    }

    private void Start()
    {
        spawned = new Rnd().Next(Mathf.FloorToInt(spawnQuantity.x), Mathf.CeilToInt(spawnQuantity.y));
        for (int i = 0; i < spawned; i++)
        {
            GameObject newCollectible = Instantiate(collectible);
            float randomX = Random.Range(-spawnBounds.x, spawnBounds.x);
            float randomY = Random.Range(-spawnBounds.y, spawnBounds.y);
            newCollectible.transform.position = new Vector2(randomX, randomY);
            newCollectible.transform.SetParent(transform);
        }
    }

    public void incrScore()
    {
        score++;

        if (score >= spawned)
        {
            UIController.instance.showWinScreen();
        }
    }
}
