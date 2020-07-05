using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;  
    [SerializeField] float upThrust = 100f;
    [SerializeField]float rcsThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip success;
    enum State  {Alive, tonextlevel, dead};
    State state = State.Alive;
    
    
      // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update(){
         if (state == State.Alive){
            Thrust();
            Rotate();

        }
    }
   
    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive){
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "friend":
                
            break;
            case "Finish":
                state = State.tonextlevel;
                audioSource.Stop();
                audioSource.PlayOneShot(success);
                Invoke("loadNextlvl" ,1f);
            break;
            default:
                state = State.dead;
                audioSource.Stop();
                audioSource.PlayOneShot(death);
                Invoke("deadlvl", 1f);
                break;
        }
    }
    
    private void loadNextlvl(){
        SceneManager.LoadScene(1);
    }

    private void deadlvl(){
        SceneManager.LoadScene(0);
    }
    private void Thrust(){
        
        float upThrustForce = upThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * upThrustForce);
            audioSource.PlayOneShot(mainEngine);
        }
        /*if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }*/
        else{
            audioSource.Stop();
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
