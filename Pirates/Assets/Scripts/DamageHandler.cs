
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    
    int health = 1;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            health--;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
