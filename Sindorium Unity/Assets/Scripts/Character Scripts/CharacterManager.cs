using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    // Used to manage character

    [SerializeField]
    private float speed = 5f;
    //private float jump = 0.5f;
    [SerializeField]
    private float rotationSpeed;

	// Use this for initialization
	void Start ()
    {
        rotationSpeed = 10 * speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
        TurnPlayer();
	}

    private void MovePlayer()
    {
        /* Update the character position when he walks, transform.forward is the forward vector of the character
        and Input.GetAxis manages buttons in the Input settings of Unity.*/
        transform.position += new Vector3(transform.forward.x * Input.GetAxis("Vertical")* Time.deltaTime * speed, 0.0f, transform.forward.z * Input.GetAxis("Vertical") * Time.deltaTime * speed); 
    }

    /* Used to turn the player, the camera will automatically follow this turning. Input.getAxis is managed in the Input Settings of Unity
     where buttons are associated. */
    private void TurnPlayer()
    {
        float yaw = Input.GetAxis("Yaw") * rotationSpeed * Time.deltaTime;

        transform.Rotate(0.0f, yaw, 0.0f);
    }


}
