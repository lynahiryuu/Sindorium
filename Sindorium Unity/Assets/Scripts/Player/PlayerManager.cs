using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    // Used to manage character

    // For Jumping and Moving
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed;
    private float jump;
    private int jumpNumber = 2;
    private Rigidbody playerRigidBody;

    // For Casting a Fireball
    [SerializeField] private GameObject FireBallPrefab;
    private GameObject FireBall;


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

        if (Input.GetButtonDown("Jump") && jumpNumber > 0)
        {
            JumpPlayer();
        }

        if (Input.GetButtonDown("Fire"))
        {
            CastFire();
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

    // The player Jump when this function is called
    private void JumpPlayer()
    {
 
        playerRigidBody.AddForce(new Vector3(0, jump, 0));
        jumpNumber--;
        
    }

    // Called when you press E, cast a fireball
    private void CastFire()
    {
        // Instantiating
        Vector3 InitPosition = this.transform.position + 0.5f * transform.forward;
        Quaternion InitRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        FireBall = Instantiate(FireBallPrefab, InitPosition, InitRotation);
        FireBall.transform.parent = null;

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
