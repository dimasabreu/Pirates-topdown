using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int health = 3;
    private bool Alive = true;
    
    void Update()
    {
        if (health < 1)
        {
            Die();
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    public void Die()
    {
        Destroy(gameObject);
        Alive = false;
    }
}
