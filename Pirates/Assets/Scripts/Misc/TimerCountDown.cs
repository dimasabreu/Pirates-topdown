using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class TimerCountDown : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] public int Duration = 60;
    private int remainingDuration;
    private string TimeFromOptions;
    private int TimeFromOptionsINT;
    private bool TimeCheck;
    
    void Start()
    {
        TimeFromOptions = StoreOptions.TimerCountDown;
        TimeCheck = int.TryParse(TimeFromOptions, out TimeFromOptionsINT);
        if (TimeCheck)
        {
            Being(TimeFromOptionsINT);
        }
        else
        {
            Being(Duration);
        }
        
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        
    }
}
