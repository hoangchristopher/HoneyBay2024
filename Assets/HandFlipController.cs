using UnityEngine;

public class HandFlipController : MonoBehaviour
{
    public Transform rightHandAnchor; // Right hand anchor
    public BoatController boatController; // Reference to BoatController

    private bool isRightFlipped = false; // Tracks if the right hand is flipped
    private int flipCount = 0; // Count of flips

    void Start()
    {
        // Check if rightHandAnchor is assigned once at the start
        if (rightHandAnchor == null)
        {
            Debug.LogWarning("rightHandAnchor is not assigned in HandFlipController."); // Warning in console
        }
    }

    void Update()
    {
        if (rightHandAnchor == null) return; // Skip the rest of the update if rightHandAnchor is null

        CheckHandFlip(); // Check for hand flip
    }

    void CheckHandFlip()
    {
        // Detect flip for right hand
        if (rightHandAnchor != null)
        {
            // Check if the hand is flipped (palm up)
            if (!isRightFlipped && rightHandAnchor.localRotation.eulerAngles.x > 160 && rightHandAnchor.localRotation.eulerAngles.x < 200)
            {
                isRightFlipped = true; // Set the flip state to true
                flipCount++; // Increment flip count only once when flipped
                Debug.Log("Flip Count: " + flipCount); // Log the flip count for debugging

                // Optionally, you can trigger boat movement here if needed
                boatController.OnHandFlip();
            }
            // Check if the hand is returned to the original position (palm down)
            else if (isRightFlipped && (rightHandAnchor.localRotation.eulerAngles.x < 20 || rightHandAnchor.localRotation.eulerAngles.x > 340))
            {
                isRightFlipped = false; // Reset the flip state to detect the next flip
            }
        }
    }
}
