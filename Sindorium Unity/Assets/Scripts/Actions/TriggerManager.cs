using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    [SerializeField]
    private GameObject GateTriggered;
    private GameObject Trigger;
    private bool GateOpened;

    [SerializeField]
    private int IDGate;


    // Use this for initialization
    void Start () {
        
        
       // Looking for the Lever which is in child of the current Gameobject 
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Trigger")
            {
                Trigger = child.gameObject;
                //Debug.Log("Child found");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
