using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class orbit_component : MonoBehaviour
{
    public new Camera camera;
    public float sensitivity = 1200;
    public float max_angle = 60f;
    public float min_angle = 0f;

    void Start()
    {
        sensitivity = 1200;
        max_angle = 60f;
        min_angle = 0f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float orbit_spin_amount = Input.GetAxis("Mouse X");
        float orbit_height_amount = Input.GetAxis("Mouse Y");
        camera.transform.RotateAround(Vector3.zero, Vector3.up, orbit_spin_amount * sensitivity * Time.deltaTime);
        // NEED TO rotate up and down axis independent somehow locally
        Vector3 away = -camera.transform.position;
        Vector3 axis = Vector3.Cross(away, Vector3.up);
        // print(camera.transform.localEulerAngles.x);
        if (orbit_height_amount > 0)
            print("up " + (camera.transform.localEulerAngles.x).ToString());
        else if (orbit_height_amount < 0)
            print ("down " + (camera.transform.localEulerAngles.x).ToString());
        // Don't have easy way to lookahead for rotate around
        if ((orbit_height_amount > 0 && camera.transform.localEulerAngles.x  - orbit_height_amount * sensitivity * Time.deltaTime > min_angle) && // up moves cam up and view down
            !(orbit_height_amount > 0 && camera.transform.localEulerAngles.x - orbit_height_amount * sensitivity * Time.deltaTime > max_angle) ||
            (orbit_height_amount < 0 && camera.transform.localEulerAngles.x -  orbit_height_amount * sensitivity * Time.deltaTime < max_angle)) 
            camera.transform.RotateAround(Vector3.zero, axis, orbit_height_amount * sensitivity * Time.deltaTime);
    }
}
