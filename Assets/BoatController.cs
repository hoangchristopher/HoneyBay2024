using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoatController : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Speed of the boat movement
    public float countdownTime = 60f; // Time limit in seconds
    public TextMeshProUGUI countdownText; // Countdown UI text
    public TextMeshProUGUI instructionText; // Instruction UI text

    private float remainingTime; // Time remaining
    private bool isMoving = false; // Boat moving state
    private int flipCount = 0; // Count of hand flips
    private float targetZPosition = -500f;

    void Start()
    {
        // Initialize variables
        remainingTime = countdownTime;
        instructionText.text = "Flip your hands to paddle to the island!";
        countdownText.text = "Time Left: " + Mathf.Ceil(remainingTime).ToString() + "s"; // Initial countdown text
    }

    void Update()
    {
        // Update countdown timer if time is remaining
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            countdownText.text = "Time Left: " + Mathf.Ceil(remainingTime).ToString() + "s";

        }
        else
        {
            // Time ran out
            EndGame(false);
        }

        // Move the boat if it is in moving state
        if (isMoving)
        {
            MoveBoat();
        }
    }

    // Triggered by hand flip in HandFlipController
    public void OnHandFlip()
    {
        if (remainingTime > 0)
        {
            isMoving = true; // Set the boat to moving state
            flipCount++; // Increase hand flip count
            Debug.Log("Flip Count: " + flipCount); // Log flip count for debugging
        }
    }

    // Moves the boat towards the target (island)
    private void MoveBoat()
    {
        // Increase the Z position of the boat
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * 1000f * Time.deltaTime);

        // Check if the boat has reached the target Z position
        if (transform.position.z >= targetZPosition)
        {
            EndGame(true); // Reached the target
        }
    }

    public void stopMoving() {
        isMoving = false;
    }

    // Ends the game and displays the result
    private void EndGame(bool reachedIsland)
    {
        isMoving = false;
        if (reachedIsland)
        {
            instructionText.text = "You reached the island! Well done!";


        }
        else
        {
            instructionText.text = "Time's up! You couldn't reach the island.";
        }
        Debug.Log("Game Over. Total Flips: " + flipCount); // Log total flip count
        StartCoroutine(NextScene());




    }

    private IEnumerator NextScene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage2");

    }
}
