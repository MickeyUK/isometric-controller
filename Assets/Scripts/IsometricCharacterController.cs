using UnityEngine;
using System.Collections;

public class IsometricCharacterController : MonoBehaviour {

    public float walkSpeed = 4f;

    Vector3 forward, right;
    private float moveSpeed;

	// Use this for initialization
	void Start () {

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        // -45 degrees from the world x axis
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;

        // Initial speed
        moveSpeed = walkSpeed;
	    
	}
	
	// Update is called once per frame
	void Update () {

        // Movement
        if (Input.anyKey) {
            Move();
        }

	}

    void Move() {

        // Movement speed
        Vector3 rightMovement = right * moveSpeed * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Input.GetAxis("Vertical");

        // Calculate what is forward
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Set new position
        Vector3 newPosition = transform.position;
        newPosition += rightMovement;
        newPosition += upMovement;

        // Smoothly move the new position
        transform.forward = heading;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);

    }
}
