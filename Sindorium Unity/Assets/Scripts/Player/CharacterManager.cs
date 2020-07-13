using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
    // Used to manage character

    [SerializeField]
    private float speed = 5f;
    private float jump;
    private int jumpNumber = 2;
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody playerRigidBody;
  

	// Use this for initialization
	void Start ()
    {
        rotationSpeed = 10 * speed;
        jump = 50 * speed;
        playerRigidBody = GetComponent<Rigidbody>();
 
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
        TurnPlayer();
        if (Input.GetButtonDown("Jump") && jumpNumber >= 0)
        {
            JumpPlayer();
        }
        
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

    private void JumpPlayer()
    {
 
        //if(jumpNumber >= 0)
        //{
            //Debug.Log(Input.GetAxis("Jump"));
            //transform.position += new Vector3(0, jump * Time.deltaTime, 0);
            playerRigidBody.AddForce(new Vector3(0, jump, 0));
            jumpNumber--;
            
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Ground")
        {
            //Debug.Log("Player has touched the ground");
            jumpNumber = 2;
        }
    }


}
