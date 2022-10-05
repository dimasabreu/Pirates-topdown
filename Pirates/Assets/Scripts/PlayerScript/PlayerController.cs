using UnityEngine;


public class PlayerController : MonoBehaviour
{   
    [Header("Player Cfg")]
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float rotationSpeed = 180f;

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

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Island"))
        {
            maxSpeed -= 2 * Time.deltaTime;
            if (maxSpeed <= 0)
            {
                Destroy(gameObject, 1f);
            }
        }
        else if(collision.gameObject.CompareTag("Fort"))
        {
            maxSpeed -= maxSpeed;
            if (maxSpeed <= 0)
            {
                Destroy(gameObject, 1f);
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
