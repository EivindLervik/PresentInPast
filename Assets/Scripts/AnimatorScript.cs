using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour {
    public CameraFader mainCamera;
    public bool changeScenesOnEnd;

    public void FadeOut()
    {
        if (changeScenesOnEnd)
        {
            mainCamera.FadeOut(true);
        }
        else
        {
            mainCamera.FadeOut();
        }
    }

    public void FadeIn()
    {
        mainCamera.FadeIn();
    }
}
