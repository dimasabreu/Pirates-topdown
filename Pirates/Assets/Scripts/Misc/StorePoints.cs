using UnityEngine.UI;
using UnityEngine;

public class StorePoints : MonoBehaviour
{
    public Text pointsText;

    void Update()
    {
        int recievedPoints = EnemySpawner.totalScore;
        pointsText.text = recievedPoints.ToString();
    }
}
