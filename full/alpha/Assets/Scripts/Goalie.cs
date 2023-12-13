using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalie : MonoBehaviour
{
    public float moveDistance = 5f;
    public float defaultMoveSpeed = 2f;
    
    private Vector3 startPos;
    private bool movingRight = true;

    

    public void Awake()
    {
        Debug.Log("Awake - Initial Goalie Speed: " + defaultMoveSpeed);
        SetDifficultySettings();
    }

      private void SetDifficultySettings()
    {
        string selectedDifficulty = PlayerPrefs.GetString("SelectedDifficulty");

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


    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        float currentMoveSpeed = movingRight ? defaultMoveSpeed : -defaultMoveSpeed;

        transform.Translate(Vector3.right * currentMoveSpeed * Time.deltaTime);

        // Check if the object has moved the desired distance
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            // Change direction
            movingRight = !movingRight;
        }
    }


}





