using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    [Header("Player Cfg")]
    private int health;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float rotationSpeed = 180f;
    private bool Alive;
    private float speed;

    [Header("Player Effects")]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Image HealthBar;
    

    [Header("Screen Limit")]
    [SerializeField] private float xMin = -35.5f;
    [SerializeField] private float xMax = 73.5f;
    [SerializeField] private float yMin = -33.20f;
    [SerializeField] private float yMax = 13f;

    void Start()
    {
        Alive = true;
        health = maxHealth;
        speed = maxSpeed;
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
            Die();
            maxSpeed = 0;
            rotationSpeed = 0;
            Expolosion();
        }
        var healthTrigger1 = ((float) maxHealth / 1.5f);
        if(health <= healthTrigger1)
        {
            anim.SetTrigger("FirstDamage");
        }
        var healthTrigger2 = ((float) maxHealth / 3f);
        if(health <= healthTrigger2)
        {
            anim.SetTrigger("SecondDamage");
        }
        HealthBar.fillAmount = ((float) health / (float) maxHealth);
        HealthBar.color = new Color32(190, (byte) (HealthBar.fillAmount * 255), 54, 255);
    }

    private void Movement()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
    }
    
    private void ScreenLock()
    {
        float myX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float myY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(myX, myY, transform.position.z);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    private void Die()
    {
        anim.SetTrigger("Dead");
        Destroy(gameObject, 2f);
        Alive = false;
    }

    private void Expolosion()
    {
        if (!Alive)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
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
            speed -= 2 * Time.deltaTime;
            if (speed <= 0)
            {
                Die();
                Expolosion();
            }
        }
        else if(collision.gameObject.CompareTag("Fort"))
        {
            speed -= speed;
            if (speed <= 0)
            {
                Die();
                Expolosion();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            speed = maxSpeed;
        }
    }

}
