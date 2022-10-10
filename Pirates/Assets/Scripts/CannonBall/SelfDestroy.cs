using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
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
