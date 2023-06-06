using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    private bool isSettled = false;
    private Vector3 targetPosition;
    private void LateUpdate()
    {
        if (!isSettled)
        {
            // Follow the player
            targetPosition = playerTransform.position;
            targetPosition.z = -10;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

    }

    public void Settle(Vector3 v)
    {
        //TODO: handle mutliple settle points
        isSettled = true;
        targetPosition = v;
    }

    public void Unsettle()
    {
        isSettled = false;
    }
}
