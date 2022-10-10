using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    void Awake()
    {
        int qnt = FindObjectsOfType<ExplosionController>().Length;
        if (qnt > 1)
        {
            Destroy(gameObject);
        }
    }
    public void Die()
    { 
        Destroy(gameObject);
    }
        
}
