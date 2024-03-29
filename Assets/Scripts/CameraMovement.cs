using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //not in use currently
    public Camera mainCamera;
    public Vector3 offset;

    public void moveCameraToTarget(Transform target) {
        Debug.Log("Moved to " + target.name);
        mainCamera.transform.position = target.position + offset;
        mainCamera.orthographicSize = 3.5f;
    }

    public void moveCameraBack() {
        Debug.Log("Moved back");
        mainCamera.transform.position = new Vector3((float)-4, 0, -10);
        mainCamera.orthographicSize = 11f;
    }
}
