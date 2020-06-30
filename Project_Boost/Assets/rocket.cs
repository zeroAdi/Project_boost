using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }
    private void processInput(){
        if (Input.GetKey(KeyCode.Space)){
            if(!audioSource.isPlaying){
                 audioSource.Play();
            }
            else{
                audioSource.Stop();
            }
           
            rigidbody.AddRelativeForce(Vector3.up);
        }
         if (Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward);
        }

    }
}
