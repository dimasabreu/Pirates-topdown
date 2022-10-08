using UnityEngine;

public class CannonBallControllerRight : MonoBehaviour
{
    [SerializeField] private int dmg = 1;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private GameObject explosion;
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, -maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerController>().TakeDamage(dmg);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if(collider.CompareTag("Enemy"))
        {
            collider.GetComponent<EnemyController>().TakeDamage(dmg);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        } 
    }
}