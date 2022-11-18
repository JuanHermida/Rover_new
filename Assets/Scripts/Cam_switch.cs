using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_switch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    public Canvas CanvasObject; // Assign in inspector

    // Start is called before the first frame update
    void Start()
    {
        CanvasObject = GameObject.Find("Canvas").GetComponent<Canvas>();    
        CanvasObject.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            CanvasObject.GetComponent<Canvas>().enabled = false; //desactivado 
        }

        if (Input.GetButtonDown("Fire2"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            CanvasObject.GetComponent<Canvas>().enabled = true;
        }
    }
}
