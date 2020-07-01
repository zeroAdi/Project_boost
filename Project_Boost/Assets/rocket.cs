using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;  
    [SerializeField] float upThrust = 100f;
    [SerializeField]float rcsThrust = 100f;
    
    
      // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "friend":
                print("ok");
            break;
            case "Finish":
                print("Finish");
            break;
            case "refuel":
                print("refuel");
            break;
            default:
                print("dead");
                break;
        }
    }
    
    private void Thrust(){
        
        float upThrustForce = upThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * upThrustForce);
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
       
    }
    private void Rotate(){
        
        float rotationSpeed = rcsThrust * Time.deltaTime;
        rigidbody.freezeRotation = true;
         if (Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward * rotationSpeed) ;
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidbody.freezeRotation = false;

    }
}
