using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicalMovement : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

     void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continually growing overtime

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau); // goes from -1 to 1

        movementFactor = rawSineWave;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
