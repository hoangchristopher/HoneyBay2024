using UnityEngine;

public class testHandflip : MonoBehaviour
{
    public Transform rightHandAnchor; // Right hand anchor
    public BoatController boatController; // Reference to BoatController

    private bool isRightFlipped = false; // Tracks if the right hand is flipped
    public int flipCount = 0; // Count of flips

    public bool prevHand = false;

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
        bool handUp;
        
        if (rightHandAnchor.localRotation.eulerAngles.x < 90 && rightHandAnchor.localRotation.eulerAngles.x > 50) {
            handUp = true;
        }
        else {
            handUp = false;
        }

        if (prevHand != handUp) {

            boatController.OnHandFlip();
            prevHand = handUp;
        }

        else {
            boatController.stopMoving();
        }

        

    }

}
