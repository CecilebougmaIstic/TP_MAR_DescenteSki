using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDuJoueur : MonoBehaviour
{
    
    float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    //For camera occlusion and collision
    Vector3 cameraDirection;
    float camDistance;
    Vector2 cameraDistanceMinMax = new Vector2(0.5f, 5f);

    public Transform cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cameraDirection = cam.transform.localPosition.normalized;
        camDistance = cameraDistanceMinMax.y;
    }

    private void LateUpdate()
    {
        CamControl();
       // checkCameraOcclusionAndCollision(cam);

    }
   
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        cam.LookAt(Target);
       
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

     //For camera occlusion and collision
    /* public void checkCameraOcclusionAndCollision(Transform cam){
        Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
        RaycastHit hit;
        if(Physics.Linecast (transform.position, desiredCameraPosition, out hit)){
            camDistance = Mathf.Clamp(hit.distance, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
        }
        else{
            camDistance = cameraDistanceMinMax.y;
        }

        cam.localPosition = cameraDirection * camDistance;
    }*/
}
