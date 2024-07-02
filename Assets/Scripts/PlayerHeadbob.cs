using UnityEngine;

public class PlayerHeadbob : MonoBehaviour
{
    public PlayerMovementAdvanced movementScript; // Referenz auf das PlayerMovementAdvanced Skript
    public float bobbingAmount = 0.1f; // Betrag der Rotation
    public float bobbingSpeed = 10f; // Geschwindigkeit der Rotation

    private float originalYRotation; // Ursprüngliche Y-Rotation des Spielers

    void Start()
    {
        originalYRotation = transform.localRotation.eulerAngles.y; // Speichern der ursprünglichen Rotation
    }

    void Update()
    {
        float targetBobAmount = 0f;

        // Je nach Bewegungsstatus den Ziel-Headbob-Betrag festlegen
        switch (movementScript.state)
        {
            case PlayerMovementAdvanced.MovementState.walking:
                targetBobAmount = bobbingAmount;
                break;
            case PlayerMovementAdvanced.MovementState.sprinting:
                targetBobAmount = bobbingAmount * 1.2f; // Sprinten hat etwas mehr Headbob
                break;
            case PlayerMovementAdvanced.MovementState.crouching:
                targetBobAmount = bobbingAmount * 0.8f; // Kriechen hat etwas weniger Headbob
                break;
            default:
                targetBobAmount = 0f;
                break;
        }

        // Lerp zur Ziel-Rotation
        Quaternion targetRotation = Quaternion.Euler(0f, originalYRotation + targetBobAmount, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, bobbingSpeed * Time.deltaTime);
    }
}
