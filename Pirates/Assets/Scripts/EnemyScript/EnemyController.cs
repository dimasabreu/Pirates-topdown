using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] float rotationSpeed = 90f;
    [SerializeField] float maxSpeed = 2f;
    [SerializeField] GameObject explosion;
    [SerializeField] private Animator anim;
    Transform player;
    
    private bool Alive = true;
    
    void Update()
    {
        if (health < 1)
        {
            anim.SetTrigger("Dead");
            Die();
        }
        if(health == 2)
        {
            anim.SetTrigger("FirstDamage");
        }
        if(health == 1)
        {
            anim.SetTrigger("SecondDamage");
        }

        LookAtPlayer();
        ChasePlayer();
    }


    private void ChasePlayer()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
    private void LookAtPlayer()
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
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
    }



    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    public void Die()
    {
        Destroy(gameObject);
        Alive = false;
        if (!Alive)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

        private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            maxSpeed -= 2 * Time.deltaTime;
            if (maxSpeed <= 0)
            {
                Die();
            }
        }
        else if(collision.gameObject.CompareTag("Fort"))
        {
            maxSpeed -= maxSpeed;
            if (maxSpeed <= 0)
            {
                Die();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            maxSpeed = 5;
        }
    }
}
