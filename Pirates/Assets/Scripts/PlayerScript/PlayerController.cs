using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Player Cfg")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

   

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
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            speed -= 2 * Time.deltaTime;
            if (speed <= 0)
            {
                Destroy(gameObject);
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
