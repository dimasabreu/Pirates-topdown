using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject cannonShoot;
    [SerializeField] private GameObject cannonShoot2;
    [SerializeField] private Transform frontalShoot;
    [SerializeField] private Transform leftShoot1;
    [SerializeField] private Transform leftShoot2;
    [SerializeField] private Transform leftShoot3;
    [SerializeField] private Transform rightShoot1;
    [SerializeField] private Transform rightShoot2;
    [SerializeField] private Transform rightShoot3;
    [SerializeField] public float fireDelay = 1f;
    private float cooldownTimer = 0;
    
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            Instantiate(cannonShoot, frontalShoot.position, transform.rotation);
            cooldownTimer = fireDelay;
        }
        if (Input.GetKeyDown(KeyCode.Q) && cooldownTimer <= 0)
        {
            Instantiate(cannonShoot, leftShoot1.position, leftShoot1.rotation);
            Instantiate(cannonShoot, leftShoot2.position, leftShoot2.rotation);
            Instantiate(cannonShoot, leftShoot3.position, leftShoot3.rotation);
            cooldownTimer = fireDelay;
        }
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0)
        {
            Instantiate(cannonShoot2, rightShoot1.position, rightShoot1.rotation);
            Instantiate(cannonShoot2, rightShoot2.position, rightShoot2.rotation);
            Instantiate(cannonShoot2, rightShoot3.position, rightShoot3.rotation);
            cooldownTimer = fireDelay;
        }
    }
}
