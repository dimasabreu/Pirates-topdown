using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [Header("CannonBall Self-Destroy timer")]
    [SerializeField] public float timer = 5f;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
