using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    public Transform targetCamera;

    public float maxMoveSpeed;
    public float acceleration;
    public float deacceleration;

    private Rigidbody body;
    private Vector3 moveDirection;

	void Start () {
        body = GetComponent<Rigidbody>();
    }

    void Update () {
	    // None
	}

    void FixedUpdate()
    {
        Vector3 appliedForce = new Vector3();

        appliedForce += moveDirection.z * targetCamera.forward;
        appliedForce += moveDirection.x * targetCamera.right;
        print(targetCamera.forward + " - " + targetCamera.right);
        //Vector3.

        if (appliedForce != Vector3.zero)
        {
            body.AddForce(appliedForce * acceleration * Time.fixedDeltaTime);
        }

        
    }

    public void UpdateMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }
}
