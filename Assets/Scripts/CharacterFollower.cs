using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    public Transform Target; //To set the target for the camera
    public float SmoothSpeed = 0.125f; //A smoothing factor for the camera's movement
    public Vector3 Offset; //Setting an offset from the character's position

    void LateUpdate()
    {
        if (Target != null)
        {
            //Setting the desired position of the camera
            Vector3 desiredPosition = Target.position + Offset;

            //Interpolate the desired position smoothly
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);

            //To update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
