using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0f, 2f, -10f); 

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);

            // Set the Z position to a constant value to keep the camera in the 2D plane.
            smoothedPosition.z = -10f;

            transform.position = smoothedPosition;
        }
    }
}
