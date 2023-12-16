using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string URL = "https://github.com/jn0w/Project2_create_with_code";

    public void Play()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

        public void loadUrl()
        {
        Application.OpenURL(URL);
        }

    public void SetDifficulty(string difficulty)
    {
        // Set the selected difficulty in PlayerPrefs
        PlayerPrefs.SetString("SelectedDifficulty", difficulty);
        PlayerPrefs.Save();

        // Load the "My Game" scene after setting the difficulty
        SceneManager.LoadScene("My Game");
    }

    // Existing buttons (Easy, Medium, Hard) will call SetDifficulty with their respective difficulty
    public void Easy()
    {
        SetDifficulty("Easy");
    }

    public void Medium()
    {
        SetDifficulty("Medium");
    }

    public void Hard()
    {
        SetDifficulty("Hard");
    }
    
}
