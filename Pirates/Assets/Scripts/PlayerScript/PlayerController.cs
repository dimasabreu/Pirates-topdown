using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Player Cfg")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private Transform point;
    private Rigidbody2D rb;

   

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        Moving();
    }

    private void Moving()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.rotation -= rotationSpeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.rotation += rotationSpeed;
        }
        
        

        float myX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float myY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(myX, myY, transform.position.z);

    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            speed -= 2 * Time.deltaTime;
            if (speed <= 0)
            {
                Destroy(gameObject, 2f);
            }
        }
        else if(collision.gameObject.CompareTag("Fort"))
        {
            speed -= speed;
            if (speed <= 0)
            {
                Destroy(gameObject, 2f);
            }
        }
    }

   private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            speed = 5;

        }
    }
}
