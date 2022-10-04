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

   

    void Start() 
    {
        
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
