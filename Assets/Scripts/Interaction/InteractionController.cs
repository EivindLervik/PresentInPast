using UnityEngine;
using System.Collections;

public enum Interaction
{
    Button
}

public class InteractionController : MonoBehaviour {

    public Interaction interaction;

    public void DoAction()
    {
        switch (interaction)
        {
            case Interaction.Button:
                ButtonPress();
                break;
            default:
                // Nothing
                break;
        }
    }

    public virtual void ButtonPress()
    {
        // Override
    }
}
