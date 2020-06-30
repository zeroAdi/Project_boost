using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }
    private void processInput(){
        if (Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up);
        }
         if (Input.GetKey(KeyCode.A)){
            transform.Rotate(-Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward);
        }

    }
}
