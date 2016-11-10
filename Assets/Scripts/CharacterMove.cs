using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    public Transform targetCamera;
    public Transform character;

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
        /**
            Forces
        **/
        Vector3 appliedForce = new Vector3();

        appliedForce += moveDirection.z * targetCamera.forward;
        appliedForce += moveDirection.x * targetCamera.right;

        Vector3 nyBrems = body.velocity;
        nyBrems.x /= (deacceleration * Time.fixedDeltaTime);
        nyBrems.z /= (deacceleration * Time.fixedDeltaTime);
        body.velocity = nyBrems;
        if (appliedForce != Vector3.zero)
        {
            body.AddForce(appliedForce * acceleration * Time.fixedDeltaTime);
        }




        /**
            Facing-direction
        **/
        Vector3 nyFram = body.velocity;
        nyFram.y = 0.0f;
        if(nyFram != Vector3.zero)
        {
            character.forward = nyFram;
        }
    }

    public void UpdateMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }
}
