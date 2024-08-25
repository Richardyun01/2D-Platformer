using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    public Transform GetDestination()
    {
        customEvent.Invoke();
        return destination;
    }
}
