using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoleGoal : MonoBehaviour
{
    [SerializeField] UnityEvent onHoleGoal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            onHoleGoal.Invoke();
        }
    }
}
