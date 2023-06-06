using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCameraToObject : MonoBehaviour
{
    CameraController cameraController;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger"))
        {
            Debug.Log("Camera Triggered");
            Debug.Log(collision.gameObject.ToString());
            Vector3 targetPosition = collision.gameObject.transform.position;
            targetPosition.z = -10; // so its always front
            cameraController.Settle(targetPosition); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Camera Unsettled");
        cameraController.Unsettle();   
    }


}
