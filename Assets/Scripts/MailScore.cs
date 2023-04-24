using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailScore : MonoBehaviour
{
    public int MailWorth = 2;
    [HideInInspector]
    public int FinalScore;

    void Start() {
        FinalScore = 0;
    }


    public void AddScore() {
        FinalScore += MailWorth;
        //For Testing
        Debug.Log("Current Points: " + FinalScore);
    }
}