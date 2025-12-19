using UnityEngine;
// Example Script (Attach to the Child VCam or its Parent)
public class LockCameraPan : MonoBehaviour
{
    public Transform playerTarget; // Assign the player/parent
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    void LateUpdate()
    {
        // If it's a child, we often clamp localPosition
        // If it's the parent, we clamp transform.position
        Vector3 clampedPos = transform.localPosition; // Or transform.position for parent
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        clampedPos.z = Mathf.Clamp(clampedPos.z, minZ, maxZ);
        transform.localPosition = clampedPos; // Or transform.position = clampedPos;
    }
}
