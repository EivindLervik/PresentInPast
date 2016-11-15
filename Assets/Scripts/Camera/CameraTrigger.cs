using UnityEngine;
using System.Collections;

public enum CameraMovementType
{
    Follow, CrashBandicoot, TopDown, SonicTheHedgehog, SuperMario, XYZ, None
}

public class CameraTrigger : MonoBehaviour {

    [Header("Forwards")]
    public CameraMovementType typeForward;
    public bool useStandardPositionAndRotationForwards;
    public Vector3 positionForwards;
    public Vector3 rotationForwards;

    [Header("Backwards")]
    public CameraMovementType typeBackward;
    public bool useStandardPositionAndRotationBackwards;
    public Vector3 positionBackwards;
    public Vector3 rotationBackwards;

    public CameraMovementType GetCameraType(Vector3 position)
    {
        if (CalculateSendback(position))
        {
            return typeForward;
        }
        else
        {
            return typeBackward;
        }
    }

    public Vector3 GetPosition(Vector3 position)
    {
        if (CalculateSendback(position))
        {
            return positionForwards;
        }
        else
        {
            return positionBackwards;
        }
    }

    public Vector3 GetRotation(Vector3 position)
    {
        if (CalculateSendback(position))
        {
            return rotationForwards;
        }
        else
        {
            return rotationBackwards;
        }
    }

    public bool UseStandardPR(Vector3 position)
    {
        if (CalculateSendback(position))
        {
            return useStandardPositionAndRotationForwards;
        }
        else
        {
            return useStandardPositionAndRotationBackwards;
        }
    }

    public bool CalculateSendback(Vector3 position)
    {
        return Vector3.Dot(transform.forward, position - transform.position) >= 0.0f;
    }
}
