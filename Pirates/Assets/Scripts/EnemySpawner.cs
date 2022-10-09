using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefab;
    [SerializeField] public float enemyRate = 5;
    [SerializeField] private int points;
    [SerializeField] private Text pointsText;
    float nextEnemy = 1;
    float spawnDistance = 15f;
    Transform player;
    
    void Start()
    {
        pointsText.text = points.ToString();
    }

    void Update()
    {
        pointsText.text = points.ToString();
        SpawnEnemy();
    }

    public void GetPoints(int points)
    {
        this.points += points;
    }

    private void SpawnEnemy()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerObject");
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null)
        {
            return;
        }
        if (player != null)
        {
            nextEnemy -= Time.deltaTime;
            if (nextEnemy <= 0)
            {
                Vector3 offset = Random.onUnitSphere;
                offset.z = 0;
                offset = offset.normalized * spawnDistance;
                GameObject enemyCreated;
                float chance = Random.Range(1f, 4f);
                if (chance < 2f)
                {
                    enemyCreated = enemyPrefab[0];
                }
                else
                {
                    enemyCreated = enemyPrefab[1];
                }
                Instantiate(enemyCreated, transform.position + offset, Quaternion.identity);
                nextEnemy = enemyRate;
            }
        }
    }
}
