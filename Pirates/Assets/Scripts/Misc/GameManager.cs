using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    private void Awake() 
    {
        // garantindo q só tem 1
        int qnt = FindObjectsOfType<GameManager>().Length;
        if (qnt > 1)
        {
            Destroy(gameObject);
        }
        // nao destruindo quando trocar de cena
        DontDestroyOnLoad(gameObject);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator DeathSceneDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
    public void DeathScene()
    {
        StartCoroutine(DeathSceneDelay());
    }
    
}
