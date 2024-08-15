using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fps_component : MonoBehaviour
{
    public new Camera camera;
    public float mouse_sensitivity = 1200;
    public float scroll_sensitivity = 2000;

    private bool AngleIsValid(float angle) {
        // angle is between 280 and 360, and 0 and 60
        if (angle > 60 && angle < 280)
            return false;
        return true;
    }

    void Start()
    {
        mouse_sensitivity = 1200;
        scroll_sensitivity = 2000;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float spin_amount = Input.GetAxis("Mouse X");
        float pitch_amount = Input.GetAxis("Mouse Y");
        camera.transform.RotateAround(camera.transform.position, Vector3.up, spin_amount * mouse_sensitivity * Time.deltaTime);
        if (AngleIsValid(camera.transform.localEulerAngles.x - pitch_amount * mouse_sensitivity * Time.deltaTime))
            camera.transform.RotateAround(
                camera.transform.position,
                -Vector3.Cross(Vector3.up, camera.transform.forward),
                pitch_amount * mouse_sensitivity * Time.deltaTime);

        camera.fieldOfView -= Input.mouseScrollDelta.y * scroll_sensitivity * Time.deltaTime;
    }
}