using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerCountDown : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] public int Duration;
    private int remainingDuration;
    void Start()
    {
        Being(Duration);
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
        print("end");
    }
}
