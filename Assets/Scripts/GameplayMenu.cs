using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : MonoBehaviour
{
    public TMPro.TMP_InputField jumpInputField;
    public char defaultJumpKey = 'W';

    void Start()
    {
        jumpInputField.characterLimit = 1;
        JumpInput = defaultJumpKey;
    }

    public void MapJumpInput(String jumpInputFieldText)
    {

        if (string.IsNullOrEmpty(jumpInputFieldText))
        {
            JumpInput = defaultJumpKey;
        }
        else
        {
            char jumpKey = Char.ToUpper(jumpInputFieldText[0]);
            if (Char.IsLetter(jumpKey))
            {
                JumpInput = jumpKey;
            }
            else
            {
                JumpInput = defaultJumpKey;
            }
        }
        
        jumpInputField.text = JumpInput.ToString();
    }

    public char JumpInput { get; set; }
}
