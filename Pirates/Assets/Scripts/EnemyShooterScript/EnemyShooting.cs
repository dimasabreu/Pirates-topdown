using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Enemy Shooting cfg")]
    [SerializeField] public float fireDelay = 0.5f;
    [SerializeField] public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    float cooldownTimer = 0;
    Transform player;

    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerObject");
            if (go != null)
            {
                player = go.transform;
            }
        }
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 7)
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
