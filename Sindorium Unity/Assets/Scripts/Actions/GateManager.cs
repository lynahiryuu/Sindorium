using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

    private GameObject PivotGate;
    private bool DoorFound = false;
    private bool DoorOpened = false;
    private float DoorAngleRotation = 90f;

    public void Start()
    {
        //Looking for the GameObjet tagged PivotGate which turns correctly the gate
        PivotGate = GameObject.FindGameObjectWithTag("PivotGate");

    }

    public void Update()
    {
        //Open the door, DoorState has the 1 value
        if(Input.GetButtonDown("Interact") && DoorFound && !DoorOpened)
        {
            MoveDoor(1);
            DoorOpened = true;
        }

        //Close the door, DoorState has the -1 value to invert the rotation
        else if (Input.GetButtonDown("Interact") && DoorFound && DoorOpened)
        {
            MoveDoor(-1);
            DoorOpened = false;
        }
    }

    private void MoveDoor(int DoorState)
    {
        //Rotation of the door until 90° rotation, to open or close the door
        float YawDoor = DoorState * DoorAngleRotation;
        PivotGate.transform.Rotate(0.0f, YawDoor, 0.0f);

        //Smooth Door Rotation with interpolation
        //float newRotation = DoorState * Mathf.SmoothDampAngle(0, DoorAngleRotation, ref DoorSpeedAngle, InterpolationFactor);
        //PivotGate.transform.Rotate(0.0f, newRotation, 0.0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Looking for the object in the Player components which contains the Body Player collider. 
        // WARNING This component is tagged "PlayerBody", not "Player"
        if (other.gameObject.tag == "PlayerBody")
        {
            //Debug.Log("Player has touched the door");
            DoorFound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerBody")
        {
            //Debug.Log("Player has quitted the door");
            DoorFound = false;
        }
    }

    
}
