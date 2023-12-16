using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalie : MonoBehaviour
{
    // Public variables accessible and modifiable in Unity Inspector
    public float moveDistance = 5f; // Distance the goalie can move
    public float defaultMoveSpeed = 2f; // Default movement speed of the goalie
    
    // Private variables accessible only within this script
    private Vector3 startPos; // Initial position of the goalie
    private bool movingRight = true; // Direction flag for goalie movement
    

    // This method is called when the script instance is being loaded
    public void Awake()
    {
        // Display initial goalie speed in the console when the game starts
        Debug.Log("Awake - Initial Goalie Speed: " + defaultMoveSpeed);

        // Set difficulty settings for the goalie movement speed
        SetDifficultySettings();
    }

    // This method sets the difficulty settings based on the player's choice
    private void SetDifficultySettings()
    {
        // Get the selected difficulty level from player preferences
        string selectedDifficulty = PlayerPrefs.GetString("SelectedDifficulty");

        // Set goalie's movement speed based on selected difficulty
        switch (selectedDifficulty)
        {
            case "Easy":
                // Adjust settings for Easy difficulty
                defaultMoveSpeed = 5f; // Change as needed
                break;
            case "Medium":
                // Adjust settings for Medium difficulty
                defaultMoveSpeed = 10f; // Change as needed
                break;
            case "Hard":
                // Adjust settings for Hard difficulty
                defaultMoveSpeed = 20f; // Change as needed
                break;
            default:
                // Use default settings if no difficulty is selected
                defaultMoveSpeed = 2f;
                break;
        }
    }

    // This method is called before the first frame update
    public void Start()
    {
        // Store the initial position of the goalie when the game starts
        startPos = transform.position;
    }

    // This method is called once per frame
    public void Update()
    {
        // Calculate the current movement speed based on the direction
        float currentMoveSpeed = movingRight ? defaultMoveSpeed : -defaultMoveSpeed;

        // Move the goalie horizontally based on the calculated speed and frame rate
        transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);

        // Check if the goalie has moved the desired distance
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            // Change the direction of movement when the desired distance is reached
            movingRight = !movingRight;
        }
    }
}
