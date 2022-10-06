using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    void Start()
    {
        transform.localScale = new Vector3(1f, -1f, 1f);
        cannon.transform.localRotation = Quaternion.Euler(1,1,-90);
    }
    
    

}
