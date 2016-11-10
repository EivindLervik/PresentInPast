using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool canControl;

    private CharacterMove characterMove;
    private CharacterAnimator animator;

    void Start () {
        characterMove = GetComponent<CharacterMove>();
        animator = GetComponent<CharacterAnimator>();
	}
	
	void Update () {
        if (canControl)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            characterMove.UpdateMoveDirection(move);
            animator.setIsMoving(move != Vector3.zero);
        }
	}  
}
