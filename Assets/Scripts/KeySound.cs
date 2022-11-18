using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeySound : MonoBehaviour
{
    public AudioSource key;

    public Rigidbody rig; //cuerpo rigido 
    public float speed;

    public float minimumPitch = 2f;
    public float maximumPitch = 10f;

    public float engineSpeed;
    // Start is called before the first frame update
    void Start()
    {
        key.pitch = minimumPitch;
    }

    // Update is called once per frame
    void Update()
    {
        speed = rig.velocity.magnitude; //velocidad cuerpo rigido
        engineSpeed = speed;

        if (engineSpeed < minimumPitch){
            key.pitch = minimumPitch;
        }
        else if (engineSpeed > maximumPitch){
            key.pitch = maximumPitch;
        }
        else{
            key.pitch = engineSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) )
        {
            key.Play();
        }

        /*if (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.S))
        {
            key.Stop();
        }
        */
    }
}
