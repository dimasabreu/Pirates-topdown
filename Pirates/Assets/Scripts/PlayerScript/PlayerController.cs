using UnityEngine;


public class PlayerController : MonoBehaviour
{   
    [Header("Player Cfg")]
    [SerializeField] public int health = 3;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float rotationSpeed = 180f;
    private bool Alive = true;

    [Header("Player Effects")]
    [SerializeField] private Animator anim;
    [SerializeField] GameObject explosion;
    

    [Header("Screen Limit")]
    [SerializeField] private float xMin = -35.5f;
    [SerializeField] private float xMax = 73.5f;
    [SerializeField] private float yMin = -33.20f;
    [SerializeField] private float yMax = 13f;

    void Start()
    {

    }

    void Update()
    {
        if(maxSpeed > 0)
        {
            Movement();
        }
        ScreenLock();
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
    }

    private void Movement()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
    }
    
    private void ScreenLock()
    {
        float myX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float myY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(myX, myY, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Enemy"))
        {
            health--;
            collider.GetComponent<EnemyController>().Die();
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

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    private void Die()
    {
        Destroy(gameObject, 2f);
        Alive = false;
        if (!Alive)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

}
