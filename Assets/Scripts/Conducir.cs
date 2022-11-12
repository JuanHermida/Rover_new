using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Conducir : MonoBehaviour
{

    public WheelCollider Llanta1;
    public WheelCollider Llanta2;
    public WheelCollider Llanta3;
    public WheelCollider Llanta4;

    public Transform Neumatico_1;
    public Transform Neumatico_3;
    public Transform Neumatico_2;
    public Transform Neumatico_4;

    public int desAceleracion = 50;


    public Rigidbody rb; //cuerpo rigido
    public Vector3 com; //centro de masa 

    public int aceleracion = 90;
    public int velMaxima = 200;
    public float velocidad;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = com;
    }

    void Update(){
        Neumatico_1.localEulerAngles = new Vector3 (Llanta1.rpm, Llanta1.steerAngle ,0);
        Neumatico_3.localEulerAngles = new Vector3 (Llanta2.rpm, Llanta2.steerAngle ,0);
        //Neumatico_2.localEulerAngles = new Vector3(Llanta3.rpm, 0, 0);
        //Neumatico_4.localEulerAngles = new Vector3(Llanta4.rpm, 0, 0);
        velocidad = (2 * Mathf.PI * Llanta1.radius) * Llanta1.rpm * 60/1000;
        velocidad = Mathf.Round(velocidad);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Aceleracion
        if (Mathf.Abs(velocidad) < velMaxima)
        {
            Llanta1.motorTorque = aceleracion * Input.GetAxis("Vertical");
            Llanta2.motorTorque = aceleracion * Input.GetAxis("Vertical");
        } else {
            Llanta1.motorTorque = 0;
            Llanta2.motorTorque = 0;
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            Llanta1.brakeTorque = desAceleracion;
            Llanta2.brakeTorque = desAceleracion;
        }
        else
        {
            Llanta1.brakeTorque = 0;
            Llanta2.brakeTorque = 0;
        }
        //rotacion
        Llanta1.steerAngle = 10 * Input.GetAxis("Horizontal");
        Llanta2.steerAngle = 10 * Input.GetAxis("Horizontal");

        //if (Input.GetButtonUp (KeyCode.UpArrow))

    }

    float NuevoAxis(string direccion)
    {
        return (Input.GetAxis(direccion));
    }

}
