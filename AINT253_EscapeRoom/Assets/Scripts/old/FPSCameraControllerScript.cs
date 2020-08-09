using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraControllerScript : MonoBehaviour
{
    private bool isMouseLocked;
    private Camera mainCamera;
    private CharacterControllerScript charControllerScript;

    public float lookSensitivity;

    private float rotationX;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        isMouseLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = Camera.main;
        charControllerScript = GetComponent<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = Input.GetAxis("Mouse X") * lookSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;

        //rotationY = Mathf.Clamp(rotationY, -75f, -75f);

        transform.Rotate(0.0f, rotationX, 0.0f, Space.Self);
        mainCamera.transform.localRotation = Quaternion.Euler(rotationY, 0.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMouseLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                isMouseLocked = !isMouseLocked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                isMouseLocked = !isMouseLocked;
            }
        }
        
    }
    //void OnGUI()
    //{
    //    Vector3 mousePoint = new Vector3();
    //    Event currentEvent = Event.current;
    //    Vector2 mousePosition = new Vector2();

    //    // Get the mouse position from Event.
    //    // Note that the y position from Event is inverted.
    //    mousePosition.x = currentEvent.mousePosition.x;
    //    mousePosition.y = mainCamera.pixelHeight - currentEvent.mousePosition.y;

    //    mousePoint = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));

    //    //transform.Rotate()
    //    charControllerScript.TurnToTarget(mousePoint);

    //    GUILayout.BeginArea(new Rect(20, 20, 250, 120));
    //    GUILayout.Label("Screen pixels: " + mainCamera.pixelWidth + ":" + mainCamera.pixelHeight);
    //    GUILayout.Label("Mouse position: " + mousePosition);
    //    GUILayout.Label("World position: " + mousePoint.ToString("F3"));
    //    GUILayout.EndArea();
    //}


}
