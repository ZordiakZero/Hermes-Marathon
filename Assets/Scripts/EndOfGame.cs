using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [Range(1f, 6f)]
    public float endOfGameDelay;
    public int scoreNeeded = 20;

    void Start() 
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Player")
        {
            //Player Score is enough to win
            if (other.gameObject.GetComponent<MailScore>().finalScore >= scoreNeeded)
            {
                Debug.Log("End of the game! Delaying for " + endOfGameDelay + " seconds!");
                PlayerDataSaveObject loadedPlayerData = DataManager.LoadPlayerData();
                string currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                char levelNum = currentLevel[currentLevel.Length - 1];
                switch (levelNum)
                {
                    case '1':
                        loadedPlayerData.MaxLevelUnlocked = 1;
                        break;
                    case '2':
                        loadedPlayerData.MaxLevelUnlocked = 2;
                        break;
                    case '3':
                        loadedPlayerData.MaxLevelUnlocked = 0;
                        break;
                    default:
                        Debug.LogError("Invalid level index.");
                        break;
                }
                DataManager.SavePlayerData(loadedPlayerData);
                StartCoroutine(DelayEnd(endOfGameDelay));
            }
            //Otherwise notify player
            else 
            {
                Debug.Log("Not enough points, " + scoreNeeded + " points needed.");
            }
        }
    }

    IEnumerator DelayEnd(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenuScene");
    }
}
