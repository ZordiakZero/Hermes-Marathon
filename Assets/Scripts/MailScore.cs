using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailScore : MonoBehaviour
{
    [HideInInspector]
    public int finalScore;

    void Start() {
        finalScore = 0;
    }


    public int AddScore(int mailWorth) {
        if (mailWorth < 0 ^ mailWorth > 20) {
            Debug.Log("Mail score was not valid, score not adjusted. Attempted mail score: " + mailWorth);
            return 0;
        }
        finalScore += mailWorth;
        GameObject scoreNum = GameObject.Find("ScoreNumber");
        scoreNum.GetComponent<TMPro.TextMeshProUGUI>().text = finalScore.ToString();
        return 1;

    }
}