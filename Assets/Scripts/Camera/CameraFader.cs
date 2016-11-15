using UnityEngine;
using System.Collections;

public class CameraFader : MonoBehaviour {
    [Header("Fading")]
    public bool startAtBeginning;
    public bool blackAtBeginning;
    public Color fadeInColor;
    public Color fadeOutColor;
    public float fadeTime;

    [Header("CutsceneBorders")]
    public bool cutsceneBordersActive;
    public Color cutsceneBordersColor;

    [Header("Scenes")]
    public bool changeScenes;
    public string to;

    private bool isEnd;

    private GUIStyle m_BackgroundStyle = new GUIStyle();        // Style for background tiling
    private Texture2D m_FadeTexture;                // 1x1 pixel texture used for fading
    private Color m_CurrentScreenOverlayColor = new Color(0, 0, 0, 0);  // default starting color: black and fully transparrent
    private Color m_TargetScreenOverlayColor = new Color(0, 0, 0, 0);   // default target color: black and fully transparrent
    private Color m_DeltaColor = new Color(0, 0, 0, 0);     // the delta-color is basically the "speed / second" at which the current color should change
    private int m_FadeGUIDepth = -1000;             // make sure this texture is drawn on top of everything

    private Texture2D cutsceneBorders;
    private GUIStyle cutsceneBordersStyle = new GUIStyle();


    // initialize the texture, background-style and initial color:
    private void Awake()
    {
        // The fade color
        m_FadeTexture = new Texture2D(1, 1);
        m_BackgroundStyle.normal.background = m_FadeTexture;
        SetScreenOverlayColor(m_CurrentScreenOverlayColor);

        // Borders around the cutscene
        cutsceneBorders = new Texture2D(1, 1);
        cutsceneBordersStyle.normal.background = cutsceneBorders;
        cutsceneBorders.SetPixel(0, 0, cutsceneBordersColor);
        cutsceneBorders.Apply();

        if (blackAtBeginning)
        {
            SetScreenOverlayColor(fadeInColor);
        }

        if (startAtBeginning)
        {
            FadeIn();
        }
    }


    // draw the texture and perform the fade:
    private void OnGUI()
    {
        // if the current color of the screen is not equal to the desired color: keep fading!
        if (m_CurrentScreenOverlayColor != m_TargetScreenOverlayColor)
        {
            // if the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're pretty much done fading:
            if (Mathf.Abs(m_CurrentScreenOverlayColor.a - m_TargetScreenOverlayColor.a) < Mathf.Abs(m_DeltaColor.a) * Time.deltaTime)
            {
                m_CurrentScreenOverlayColor = m_TargetScreenOverlayColor;
                SetScreenOverlayColor(m_CurrentScreenOverlayColor);
                m_DeltaColor = new Color(0, 0, 0, 0);

                if (isEnd && changeScenes)
                {
                    GetComponent<SceneChanger>().ChangeScene(to);
                }
            }
            else
            {
                // fade!
                SetScreenOverlayColor(m_CurrentScreenOverlayColor + m_DeltaColor * Time.deltaTime);
            }
        }

        GUI.depth = m_FadeGUIDepth;

        // only draw the texture when the alpha value is greater than 0:
        if (m_CurrentScreenOverlayColor.a > 0)
        {
            GUI.Label(new Rect(-10, -10, Screen.width + 20, Screen.height + 20), m_FadeTexture, m_BackgroundStyle);
        }

        // Draw cutscene-borders
        if (cutsceneBordersActive)
        {
            GUI.Label(new Rect(-10, -10, Screen.width + 20, Screen.height / 5.0f), cutsceneBorders, cutsceneBordersStyle);
            GUI.Label(new Rect(-10, (Screen.height / 5.0f) * 4.0f, Screen.width + 20, Screen.height / 5.0f), cutsceneBorders, cutsceneBordersStyle);
        }
    }


    // instantly set the current color of the screen-texture to "newScreenOverlayColor"
    // can be usefull if you want to start a scene fully black and then fade to opague
    public void SetScreenOverlayColor(Color newScreenOverlayColor)
    {
        m_CurrentScreenOverlayColor = newScreenOverlayColor;
        m_FadeTexture.SetPixel(0, 0, m_CurrentScreenOverlayColor);
        m_FadeTexture.Apply();
    }


    // initiate a fade from the current screen color (set using "SetScreenOverlayColor") towards "newScreenOverlayColor" taking "fadeDuration" seconds
    public void StartFade(Color newScreenOverlayColor, float fadeDuration)
    {
        if (fadeDuration <= 0.0f)       // can't have a fade last -2455.05 seconds!
        {
            SetScreenOverlayColor(newScreenOverlayColor);
        }
        else                    // initiate the fade: set the target-color and the delta-color
        {
            m_TargetScreenOverlayColor = newScreenOverlayColor;
            m_DeltaColor = (m_TargetScreenOverlayColor - m_CurrentScreenOverlayColor) / fadeDuration;
        }
    }



    public void FadeOut()
    {
        StartFade(fadeOutColor, fadeTime);
    }

    public void FadeOut(bool isEnd)
    {
        this.isEnd = isEnd;
        FadeOut();
    }

    public void FadeIn()
    {
        SetScreenOverlayColor(fadeInColor);
        StartFade(new Color(0, 0, 0, 0), fadeTime);
    }
}
