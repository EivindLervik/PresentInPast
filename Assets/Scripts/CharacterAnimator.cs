using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {

    public float minSpeedThreshold;
    public float maxSpeedThreshold;

    private Animator anim;
    private Rigidbody body;

    private bool isMoving;

	void Start () {
        anim = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        Vector3 vel = body.velocity;
        bool moving = Mathf.Abs(vel.x) > minSpeedThreshold || Mathf.Abs(vel.z) > minSpeedThreshold;
        anim.SetBool("Moving", isMoving);
        /*
        if (moving)
        {
            Vector3 moveVel = vel;
            moveVel.y = 0.0f;
            anim.speed = Mathf.Clamp(moveVel.magnitude * 2, minSpeedThreshold, maxSpeedThreshold)/maxSpeedThreshold;
        }
        else
        {
            anim.speed = 1.0f;
        }
        */
	}

    public void setIsMoving(bool moving)
    {
        isMoving = moving;
    }
}
