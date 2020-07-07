using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]

public class osillator_slider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);
    [SerializeField] float period = 2f;
    [Range (0,1)] [SerializeField] float movementFactor;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;*/
        if(period <= Mathf.Epsilon){
            return;
        }
        float cycle = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinwave = Mathf.Sin(cycle * tau);
        movementFactor = rawSinwave /2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;

    }
}
