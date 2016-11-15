using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    public Transform target;
    public float distance;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        //transform.position = Vector3.Lerp(transform.position, ((transform.position - target.position).normalized * distance) + target.position, Time.deltaTime);
	}
}
