using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPressure : MonoBehaviour
{
    public float moveDistance = 3.0f; 
    public float moveSpeed = 3.0f;

    private Vector3 initialPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    void Start()
    {
        initialPosition = transform.position;
        openPosition = initialPosition + new Vector3(0, moveDistance, 0);
    }

    void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, moveSpeed * Time.deltaTime);
            if (transform.position == openPosition)
            {
                isOpening = false;
            }

            customEvent.Invoke();
        }
        else if (isClosing)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
            if (transform.position == initialPosition)
            {
                isClosing = false;
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    public void CloseDoor()
    {
        isClosing = true;
        isOpening = false;
    }
}
