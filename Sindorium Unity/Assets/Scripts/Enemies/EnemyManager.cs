using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private int PV = 3;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shot" && PV > 0)
        {
            PV -= 1;
        }

        else if(collision.gameObject.tag == "Shot" && PV <= 0)
        {
            Destroy(this.gameObject);
        }
    }



}
