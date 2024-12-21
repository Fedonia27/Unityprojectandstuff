using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetTransform;
    public Camera sideCam;
    public Camera backCam;
    public bool keyPress = false;


    //public GameObject car;
    private Vector3 offset = new Vector3(0, 2, -12);
    // Start is called before the first frame update
    void Start()
    {
        //targetTransform = car.transform;    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            keyPress = true;

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            keyPress = false;

        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
       // Vector3 desiredPos = transform.TransformPoint(offset);
        //This will allow my cammera to folow car by some offset Vakue
        //transform.position = car.transform.position + offset;
        //
        void ShowOverheadVeiw()
        {
            sideCam.enabled = true; 
            backCam.enabled = false;
        }
        void ShowFirstPersonVeiw()
        {
            sideCam.enabled = false;
            backCam.enabled = true;
        }
        if (keyPress)
        {
            ShowOverheadVeiw();
        }
        else
        {
            ShowFirstPersonVeiw();
        }
    }


}
