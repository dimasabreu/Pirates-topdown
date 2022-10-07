using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject cannonShoot;
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
    }
}
