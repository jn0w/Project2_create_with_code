using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // URL to be opened when loadUrl() is called
    public string URL = "https://github.com/jn0w/Project2_create_with_code";

    // Loads the "Difficulty" scene
    public void Play()
    {
        SceneManager.LoadScene("Difficulty");
    }

    // Loads the "Instructions" scene
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    // Returns to the main menu scene
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Opens the URL specified in the public string URL
    public void loadUrl()
    {
        Application.OpenURL(URL);
    }

    // Sets the game difficulty based on the parameter passed and loads the "My Game" scene
    public void SetDifficulty(string difficulty)
    {
        // Set the selected difficulty in PlayerPrefs for later retrieval
        PlayerPrefs.SetString("SelectedDifficulty", difficulty);
        PlayerPrefs.Save();

        // Load the "My Game" scene after setting the difficulty
        SceneManager.LoadScene("My Game");
    }

    // These methods are called when the respective buttons (Easy, Medium, Hard) are clicked
    // They, in turn, call SetDifficulty with their respective difficulty levels
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
