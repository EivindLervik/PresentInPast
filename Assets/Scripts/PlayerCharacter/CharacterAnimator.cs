using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {

    public float minSpeedThreshold;
    public float maxSpeedThreshold;

    private Animator anim;
    private PlayerController pC;

	void Start () {
        anim = GetComponent<Animator>();
        pC = GetComponentInParent<PlayerController>();
	}




    public void DoAction()
    {
        pC.DoAction();
    }

    public void SetControlable(int cC)
    {
        if(cC == 1)
        {
            pC.SetCanControl(true);
        }
        else if (cC == 0)
        {
            pC.SetCanControl(false);
        }
    }

    public void SetGrounded(bool g)
    {
        anim.SetBool("Grounded", g);
    }

    public void setIsMoving(bool moving)
    {
        anim.SetBool("Moving", moving);
    }

    public void doYes()
    {
        anim.SetTrigger("YES");
    }

    public void doSprint(bool s)
    {
        anim.SetBool("Sprinting", s);
    }

    public void doWalk(bool w)
    {
        anim.SetBool("Walking", w);
    }

    public void doJump()
    {
        anim.SetTrigger("Jump");
    }

    public void CancelJump()
    {
        anim.ResetTrigger("Jump");
    }

    public void AirChange()
    {
        anim.SetTrigger("Airchange");
    }

    public void CancelAirChange()
    {
        anim.ResetTrigger("Airchange");
    }

    public void Landed()
    {
        anim.SetTrigger("Landed");
    }

    public void PressButton()
    {
        anim.SetTrigger("PressButton");
    }
}
