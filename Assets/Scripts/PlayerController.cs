using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool canControl;

    private CharacterMove characterMove;

	void Start () {
        characterMove = GetComponent<CharacterMove>();
	}
	
	void Update () {
        if (canControl)
        {
            characterMove.UpdateMoveDirection(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")));
        }
	}  
}
