using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Conducir : MonoBehaviour
{
    //llantas 
    public WheelCollider Llanta1;
    public WheelCollider Llanta2;
    public WheelCollider Llanta3;
    public WheelCollider Llanta4;

    //Rotacion llantas 
    public Transform Neumatico_1;
    public Transform Neumatico_2;
    public Transform Neumatico_3;
    public Transform Neumatico_4;

    //aceleracion 
    public int desAceleracion = 50;

    public int aceleracion = 90;
    public int velMaxima = 200;
    public float velocidad;

    public Texture Medidor;
    public Texture Mapa;

    public GameObject centerOfMass;
    public Rigidbody rigidbody;
    public float speed;
    public float speedf;
    public string Planeta;
    public string gravity;
    public string temp;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = centerOfMass.transform.localPosition;
    }

    void Update(){

        velocidad = (2 * Mathf.PI * Llanta1.radius) * Llanta1.rpm * 60/1000;
        velocidad = Mathf.Round(velocidad);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        speed = rigidbody.velocity.magnitude;
        speedf = Mathf.Abs(speed);

        //Rotacion de ruedas
        Neumatico_1.Rotate(new Vector3(Llanta1.rpm / 60 * 360 * Time.deltaTime, 0, 0));
        Neumatico_2.Rotate(new Vector3(Llanta2.rpm / 60 * 360 * Time.deltaTime, 0, 0));
        Neumatico_3.Rotate(new Vector3(0, 0, Llanta3.rpm / 60 * 360 * Time.deltaTime));
        Neumatico_4.Rotate(new Vector3(Llanta4.rpm / 60 * 360 * Time.deltaTime, 0, 0));


        Neumatico_1.localEulerAngles = new Vector3(Neumatico_1.localEulerAngles.x + (Llanta1.rpm / 60 * 360 * Time.fixedDeltaTime), Llanta1.steerAngle, Neumatico_1.rotation.z);
        Neumatico_2.localEulerAngles = new Vector3(Neumatico_2.localEulerAngles.x + (Llanta2.rpm / 60 * 360 * Time.fixedDeltaTime), Llanta2.steerAngle, Neumatico_2.rotation.z);


        //Aceleracion
        if (Mathf.Abs(velocidad) < velMaxima)
        {
            Llanta1.motorTorque = aceleracion * Input.GetAxis("Vertical");
            Llanta2.motorTorque = aceleracion * Input.GetAxis("Vertical");
        } else {
            Llanta1.motorTorque = 0;
            Llanta2.motorTorque = 0;
        }

        //Si no hay input 
        if (Input.GetAxis("Vertical") == 0)
        {
            //Se desaceleran las dos llantas 
            Llanta1.brakeTorque = desAceleracion;
            Llanta2.brakeTorque = desAceleracion;
        }
        else
        {
            //La llanta rompe torque
            Llanta1.brakeTorque = 0;
            Llanta2.brakeTorque = 0;
        }
        //rotacion y angulo 
        Llanta1.steerAngle = 10 * Input.GetAxis("Horizontal");
        Llanta2.steerAngle = 10 * Input.GetAxis("Horizontal");
    }

    float NuevoAxis(string direccion)
    {
        return (Input.GetAxis(direccion));
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(20,Screen.height - 150, 250, 150), Medidor);
        float Angulo = Mathf.Abs(velocidad) * 180 / 320;
        GUI.Label(new Rect(195, Screen.height - 70 , 300, 300), string.Format("{0:0.0}  km/h" , speedf ));
        GUI.Label(new Rect(90, Screen.height - 40, 300, 300), string.Format("MARS ROVER STATUS"));
        GUI.Label(new Rect(40, Screen.height - 100, 300, 300), string.Format("GRAVEDAD:"));
        GUI.Label(new Rect(40, Screen.height - 80, 300, 300), string.Format(gravity));
        GUI.Label(new Rect(40, Screen.height - 60, 300, 300), string.Format(Planeta));
        GUI.Label(new Rect(40, Screen.height - 40, 300, 300), string.Format(temp));
        GUI.Label(new Rect(40, 20, 300, 300), string.Format("ALTERNAR CAMARA CLICK IZQUIERDO/CLICK DERECHO"));

        GUI.DrawTexture(new Rect(Screen.width - 150 , Screen.height - 150, 150, 150), Mapa);
    }

}
