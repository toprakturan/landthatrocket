using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f; //Speed actually 
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        

        
    }

    private void FixedUpdate()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau); // value between -1,1
        movementFactor = (rawSineWave + 1f) / 2f; //recalcute to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
        
    }
}
