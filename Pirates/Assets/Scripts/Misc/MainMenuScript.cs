using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private void Awake() 
    {
        // garantindo q só tem 1
        int qnt = FindObjectsOfType<Canvas>().Length;
        if (qnt > 1)
        {
            Destroy(gameObject);
        }
        // nao destruindo quando trocar de cena
        DontDestroyOnLoad(gameObject);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
