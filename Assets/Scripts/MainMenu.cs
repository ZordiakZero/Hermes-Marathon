using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public struct Level
{
    public string Name;
    public string Path;
    public Sprite Image;
    public bool Locked;
}

public class MainMenu : MonoBehaviour
{
    
    public GameObject LevelDisplayPrefab;
    public GameObject LevelsPanel;
    public Level[] levels;

    
    public void Play()
    {
        PlayerDataSaveObject loadedPlayerData = DataManager.LoadPlayerData();
        int MaxLevelUnlocked = loadedPlayerData.MaxLevelUnlocked;
        for (int i = 0; i <= MaxLevelUnlocked; i++)
        {
            levels[i].Locked = false;
        }
        RenderLevels();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerDataSaveObject loadedPlayerData = DataManager.LoadPlayerData();
        loadedPlayerData.MaxLevelUnlocked = 0;
        DataManager.SavePlayerData(loadedPlayerData);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void RenderLevels()
    {
        int row = 0;
        int col = 0;
        for (int i = 0; i < levels.Length; i++)
        {
            
            GameObject Level = Instantiate(LevelDisplayPrefab, LevelsPanel.transform, false);
            Level.transform.localPosition += new Vector3(col * 300, row * -200);
            Image[] LevelImages = Level.GetComponentsInChildren<Image>();
            LevelImages[0].sprite = levels[i].Image;
            Level.GetComponentInChildren<TextMeshProUGUI>().text = levels[i].Name;
            string LevelPath = levels[i].Path;
            bool LevelLocked = levels[i].Locked;
            Button LevelButton = Level.GetComponentInChildren<Button>();
            LevelButton.onClick.AddListener(() => { if (!LevelLocked) SceneManager.LoadScene(LevelPath); });
            if (LevelLocked)
            {
                LevelImages[1].enabled = true;
                LevelButton.enabled = false;
            }
            col++;
            if ((i+1) % 4 == 0)
            {
                col = 0;
                row++;
            }
        }
    }
}
