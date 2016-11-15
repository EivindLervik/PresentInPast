using UnityEngine;
using System.Collections;

public class CameraMaster : MonoBehaviour {

    public CameraMovementType type;

    private CorridorCamera corridorCam;
    private UnityStandardAssets.Cameras.AutoCam autoCam;
    public Transform pivot;

    void Start () {
        corridorCam = GetComponent<CorridorCamera>();
        autoCam = GetComponent<UnityStandardAssets.Cameras.AutoCam>();
    }

    public void SetCameraType(CameraTrigger cT, Vector3 playerPosition)
    {
        CameraMovementType cmt = cT.GetCameraType(playerPosition);
        type = cmt;
        //print(cmt);

        if (cT.UseStandardPR(playerPosition))
        {
            pivot.localPosition = cT.GetPosition(playerPosition);
            Vector3 rot = cT.GetRotation(playerPosition);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rot.y, transform.eulerAngles.z);
            pivot.eulerAngles = new Vector3(rot.x, pivot.eulerAngles.y, rot.z);
        }

        switch (type)
        {
            case CameraMovementType.CrashBandicoot:
                autoCam.enabled = false;
                corridorCam.enabled = true;
                corridorCam.SetSettings(false, false, true, false);

                break;
            case CameraMovementType.Follow:
                autoCam.enabled = true;
                corridorCam.enabled = false;

                break;
            case CameraMovementType.TopDown:
                autoCam.enabled = false;
                corridorCam.enabled = true;
                corridorCam.SetSettings(true, false, true, false);

                break;
            case CameraMovementType.SonicTheHedgehog:
                autoCam.enabled = false;
                corridorCam.enabled = true;
                corridorCam.SetSettings(true, true, false, false);

                break;
            case CameraMovementType.SuperMario:
                autoCam.enabled = false;
                corridorCam.enabled = true;
                corridorCam.SetSettings(true, false, false, false);

                break;
            case CameraMovementType.XYZ:
                autoCam.enabled = false;
                corridorCam.enabled = true;
                corridorCam.SetSettings(true, true, true, false);

                break;
            case CameraMovementType.None:
                autoCam.enabled = false;
                corridorCam.enabled = false;

                break;
            default:
                // None
                break;
        }
    }
}
