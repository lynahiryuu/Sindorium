using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
  
    [SerializeField]
    float rotationSpeedCamera = 50f;
   

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
    // Camera calculation must be made after all the updates
	void LateUpdate ()
    {
        TurnCamera();

	}
    // Up and Down are modified but not the other because it's already modified in CharacterManager with move and Forward
    // which modifies the position/rotation of the camera's parent
    private void TurnCamera()
    {
        float pitch = Input.GetAxis("Pitch") * rotationSpeedCamera * Time.deltaTime;

        transform.Rotate(-pitch, 0.0f, 0.0f);
    }
}
