using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip walkFootstepClip;
    public AudioClip sprintFootstepClip;
    public AudioClip crouchFootstepClip;
    public float walkStepDistance = 2.0f; // Distanz für Schritte im Gehen
    public float sprintStepDistance = 1.5f; // Distanz für Schritte im Sprinten
    public float crouchStepDistance = 3.5f; // Distanz für Schritte im Kriechen
    public float minPitch = 0.95f; // Minimale Pitch-Variation
    public float maxPitch = 1.05f; // Maximale Pitch-Variation
    public float walkVolume = 1.0f; // Lautstärke für Gehen
    public float sprintVolume = 1.2f; // Lautstärke für Sprinten
    public float crouchVolume = 0.8f; // Lautstärke für Kriechen

    private float accumulatedDistance;
    private Vector3 lastPosition;

    private PlayerMovementAdvanced playerMovement; // Referenz zum PlayerMovement-Skript

    void Start()
    {
        playerMovement = GetComponent<PlayerMovementAdvanced>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (playerMovement.grounded)
        {
            float distance = Vector3.Distance(transform.position, lastPosition);
            accumulatedDistance += distance;

            switch (playerMovement.state)
            {
                case PlayerMovementAdvanced.MovementState.walking:
                    if (accumulatedDistance >= walkStepDistance)
                    {
                        PlayFootstep(walkFootstepClip, walkVolume);
                        accumulatedDistance = 0;
                    }
                    break;
                case PlayerMovementAdvanced.MovementState.sprinting:
                    if (accumulatedDistance >= sprintStepDistance)
                    {
                        PlayFootstep(sprintFootstepClip, sprintVolume);
                        accumulatedDistance = 0;
                    }
                    break;
                case PlayerMovementAdvanced.MovementState.crouching:
                    if (accumulatedDistance >= crouchStepDistance)
                    {
                        PlayFootstep(crouchFootstepClip, crouchVolume);
                        accumulatedDistance = 0;
                    }
                    break;
            }

            lastPosition = transform.position;
        }
    }

    void PlayFootstep(AudioClip clip, float volume)
    {
        footstepAudioSource.pitch = Random.Range(minPitch, maxPitch);
        footstepAudioSource.PlayOneShot(clip, volume);
    }
}
