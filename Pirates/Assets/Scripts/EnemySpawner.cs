using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefab;
    [SerializeField] public float enemyRate = 5;
    [SerializeField] private int points = 0;
    float nextEnemy = 1;
    float spawnDistance = 20f;
    
    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if(nextEnemy <= 0)
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
