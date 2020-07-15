using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager : MonoBehaviour {

    [SerializeField] private int FireBallSpeed = 50;

    //FireBall LifeTime
    [SerializeField] private float FireBallLifeTime = 60f;

    // Counter to count the cumulative time to know if the fireball exceed its lifetime
    private float CumulativeTime = 0.0f; 

    //Retrieve the Forward Player Vector to cast the spell towards the good direction
    private Vector3 PlayerForward;

	// Use this for initialization
    // When the Fireball is created, its speed is updated to move in front of the Player
	void Start ()
    {
        PlayerForward = GameObject.FindGameObjectWithTag("Player").transform.forward;
        gameObject.GetComponent<Rigidbody>().velocity = FireBallSpeed * PlayerForward;
	}

    private void Update()
    {
        CumulativeTime += 1;

        // If the time is up, then the Fireball is destroyed
        if(CumulativeTime > FireBallLifeTime)
        {
            //Debug.Log("Object destroyed by the time");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Object destroyed by enemy");

            // We wait a few time because otherwise, the fireball is destroyed too early
            //StartCoroutine(timeBeforeDeletion(0.15f, this.gameObject));
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "PlayerBody")
        {
            Debug.Log("Object destroyed by player");
            Destroy(this.gameObject);
        }
    }

    /*private IEnumerator timeBeforeDeletion (float time, GameObject ObjectToDelete)
    {
        yield return new WaitForSeconds(time);
        Destroy(ObjectToDelete);
    }*/
}
