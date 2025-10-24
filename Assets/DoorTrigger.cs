using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorFrame; // Reference to the door object
    public float slideDistance = 3f; // The distance the door will slide
    public float slideSpeed = 2f; // Speed of the sliding door
    private Vector3 closedPosition; // Original position of the door
    private Vector3 openPosition; // Target position when door is open
    private bool isOpening = false; // To track if the door is opening
    private bool isClosing = false; // To track if the door is closing
    private AudioSource audioSource;
    void Start()
    {
        // Store the original closed position of the door
        closedPosition = doorFrame.transform.position;
        // Calculate the open position (door slides along the X axis)
        openPosition = closedPosition + new Vector3(0, slideDistance, 0);
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player triggering the door
        {
            isOpening = true;
            isClosing = false;
            StopCoroutine("CloseDoor");
            StartCoroutine(OpenDoor());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player leaving the trigger
        {
            isOpening = false;
            isClosing = true;
            StopCoroutine("OpenDoor");
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        while (isOpening && doorFrame.transform.position != openPosition)
        {
            doorFrame.transform.position = Vector3.MoveTowards(doorFrame.transform.position, openPosition, slideSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }
    }

    IEnumerator CloseDoor()
    {
        while (isClosing && doorFrame.transform.position != closedPosition)
        {
            doorFrame.transform.position = Vector3.MoveTowards(doorFrame.transform.position, closedPosition, slideSpeed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }
    }
}