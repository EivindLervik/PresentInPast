using UnityEngine;
using System.Collections;

public class CorridorCamera : MonoBehaviour {

    public Transform target;

    public bool followX;
    public bool followY;
    public bool followZ;
    public float damping;

    public bool lookAt;

	void Start () {
	    
	}

	void FixedUpdate () {

        Vector3 targetPos = transform.position;

        if (followX)
        {
            targetPos.x = target.position.x;
        }

        if (followY)
        {
            targetPos.y = target.position.y;
        }

        if (followZ)
        {
            targetPos.z = target.position.z;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, damping * Time.fixedDeltaTime);
	}

    public void SetSettings(bool followX, bool followY, bool followZ, bool lookAt)
    {
        this.followX = followX;
        this.followY = followY;
        this.followZ = followZ;
        this.lookAt = lookAt;
    }
}
