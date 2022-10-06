using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject cannonShoot;
    [SerializeField] private Transform frontalShoot;
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
    }
}
