using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorMoverX : MonoBehaviour
{
    public float moveDistance = 1.0f;
    public float moveSpeed = 2.0f;
    private bool isMoving = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(moveDistance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }

            customEvent.Invoke();
        }
    }

    public void OpenDoor()
    {
        isMoving = true;
    }
}
