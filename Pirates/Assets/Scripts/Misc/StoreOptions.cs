using UnityEngine.UI;
using UnityEngine;

public class StoreOptions : MonoBehaviour
{
    public static string SpawnRate;
    public static string TimerCountDown;
    public GameObject inputFieldSR;
    public GameObject inputFieldTC;

    public void StoreSpawnRate()
    {
        SpawnRate = inputFieldSR.GetComponent<Text>().text;
    }
    

    public void StoreTimerCD()
    {
        TimerCountDown = inputFieldTC.GetComponent<Text>().text;
    }
}
