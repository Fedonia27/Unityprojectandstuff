using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f;
    private float upMovement;
    public float RotateVal;
    private float sideMovement;
    private float yaw;
    private float throttle;
    //public AudioSource sounding;
    public TMP_Text Xdisplay;
    public TMP_Text Ydisplay;
    public TMP_Text Zdisplay;
    private float SpeedOmeterX;
    private float SpeedOmeterY;
    private float SpeedOmeterZ;



    //these strings change the speed values into strings so we can put them in tmp text pro
    string Xstring;
    string Ystring;
    string Zstring;

    Rigidbody rb;
    //new stuff
    //public GameObject projectilePrefab;
    //GameObject BigBullet;
    //public float bullSpeed;
    public float minX, minY, maxX, maxY, minZ, maxZ;
    public AudioSource ThrustSound;
    private float SpeedSound;
    public AudioSource Decel;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddRelativeForce(Vector3.forward * 400);

    }

    // Update is called once per frame
    void Update()
    {
        upMovement = Input.GetAxis("Vertical");
        sideMovement = Input.GetAxis("Horizontal");
        throttle = Input.GetAxis("Fire1");
        yaw = Input.GetAxis("Fire2");
        //SpeedOmeter = rb.velocity.magnitude;
        //Vector3 dot compares how close one angle is along another angle or somethhing (search up documentation) 
        SpeedOmeterX = Vector3.Dot(rb.velocity, Vector3.forward);
        SpeedOmeterY = Vector3.Dot(rb.velocity, Vector3.up);
        SpeedOmeterZ = Vector3.Dot(rb.velocity, Vector3.left);


        //SpeedOmeter = Vector3.Dot(rb.velocity, Vector3.forward);

        Xstring = Mathf.Round(SpeedOmeterX).ToString();
        Ystring = Mathf.Round(SpeedOmeterY).ToString();
        Zstring = Mathf.Round(SpeedOmeterZ).ToString();

        //string spString = SpeedOmeter.ToString();
        Xdisplay.SetText("X: " + Xstring);
        Ydisplay.SetText("Y: " + Ystring);
        Zdisplay.SetText("Z: " + Zstring);





        rb.AddRelativeForce(Vector3.up * Time.deltaTime * speed * throttle, ForceMode.VelocityChange);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.up * Time.deltaTime * speed * upMovement);
        transform.Rotate(Vector3.forward * upMovement * Time.deltaTime * RotateVal, Space.Self); //rotates palane up or down
        transform.Rotate(Vector3.up * -sideMovement * Time.deltaTime * RotateVal, Space.Self); //rolls p-lane left to right
        transform.Rotate(Vector3.right * -yaw * Time.deltaTime * RotateVal, Space.Self);

        /*if (upMovement != 0 || sideMovement != 0 || throttle != 0 || yaw != 0)
        {
            sounding.Play();

        } */

        //new code below
        /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 offset = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
            BigBullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
            BigBullet.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Vector3.forward * bullSpeed;

        } */
        Vector3 newPos = transform.position;
        if (transform.position.x < minX) newPos.x = -minX; 
        if (transform.position.x > maxX) newPos.x = -maxX;
        if (transform.position.y > maxY) newPos.y = -maxY;
        if (transform.position.y < minY) newPos.y = -minY;
        if (transform.position.z < minZ) newPos.z = -minZ;
        if (transform.position.z > maxZ) newPos.z = -maxZ;

        transform.position = newPos;

        //if(upMovement > 0.2f || upMovement < -0.2f  || sideMovement > 0.2f || sideMovement < -0.2f || throttle > 0.2f || throttle < -0.2f || yaw > 0.2f || sideMovement < -0.2f)
        //{
        //ThrustSound.Play();
        //}
        //SpeedSound = rb.velocity.magnitude;
        //if(SpeedSound > 5.0f)
        //{
        //ThrustSound.Play();
        //} 
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            ThrustSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ThrustSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ThrustSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ThrustSound.Play();
        } */
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Decel.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ThrustSound.Play();
        }


    }
}
