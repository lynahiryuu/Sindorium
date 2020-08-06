using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    // Gate which will be opened with the lever
    [SerializeField] private GameObject GateTriggered;
    private GameObject Trigger;
    // Part of the gate which will be translated to open or close the door
    //private Rigidbody PartOfGateMoving;
    private GameObject PartOfGateMoving;

    private bool TriggerFound = false;
    private bool DoorOpened = false;

    private float TriggerAngleRotation = 90;

    private float GateTranslation = 2.5f;

    // Use this for initialization
    void Start () {
        
        
       // Looking for the Lever which is in child of the current Gameobject 
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Trigger")
            {
                Trigger = child.gameObject;
                Debug.Log("Trigger Child found");
            }
        }

        //Looking for the rigidBody of the attached door to move it later
        foreach(Transform child in GateTriggered.transform)
        {
            if(child.tag == "Trigger")
            {
                //PartOfGateMoving = child.gameObject.GetComponent<Rigidbody>();
                PartOfGateMoving = child.gameObject;
                Debug.Log("Gate Child Found");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        // If the player presses E when the door is opened, then we close the door
		if(TriggerFound && Input.GetButtonDown("Interact") && DoorOpened)
        {
            TriggerDoor(-1);
            DoorOpened = false;
        }

        // If the player presses E when the door is closed, then we open the door
        else if (TriggerFound && Input.GetButtonDown("Interact") && !DoorOpened)
        {
            TriggerDoor(1);
            DoorOpened = true;
        }
	}

    // Open or close the door when the player pushes the lever.
    // state parameter = 1 for opening and -1 for closing
    private void TriggerDoor(int TriggerState)
    {
        // Change the position of the lever
        float Xrotation = TriggerState * TriggerAngleRotation;
        Trigger.transform.Rotate(Xrotation, 0.0f, 0.0f);

        // Change the position of the gate
        float YTranslation = TriggerState * GateTranslation;
       // PartOfGateMoving.AddForce(0.0f, YTranslation, 0.0f);
        PartOfGateMoving.transform.position += new Vector3(0.0f, YTranslation , 0.0f); 
    }

    //Collision test to know whether or not the player is close to the lever.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBody")
        {
            TriggerFound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "PlayerBody")
        {
            TriggerFound = false;
        }
    }


}
