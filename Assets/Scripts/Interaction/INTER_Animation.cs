using UnityEngine;
using System.Collections;

public class INTER_Animation : InteractionController {

    public bool toggle;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Up", toggle);
    }

    public override void ButtonPress()
    {
        toggle = !toggle;
        anim.SetBool("Up", toggle);
    }
}
