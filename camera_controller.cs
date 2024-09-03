using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera_controller : MonoBehaviour
{
    private string current_mode = "orbit"; 
    void Start() {
        #if !UNITY_EDITOR && UNITY_WEBGL
        // disable WebGLInput.captureAllKeyboardInput so elements in web page can handle keyboard inputs
        WebGLInput.captureAllKeyboardInput = false;
        #endif
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            
        }
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKey(KeyCode.F)) {
            current_mode = "flying";
            // enable flying
            transform.Find("fps_component").gameObject.SetActive(true);
            transform.Find("movement_component").gameObject.SetActive(true);
            // disable orbit
            transform.Find("orbit_component").gameObject.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.B)) {
            current_mode = "orbit";
            // enable orbit
            transform.Find("orbit_component").gameObject.SetActive(true);
            // disable flying
            transform.Find("fps_component").gameObject.SetActive(false);
            transform.Find("movement_component").gameObject.SetActive(false);
        }
            
    }
    void OnApplicationFocus(bool hasFocus) {
        if (!hasFocus) {
            transform.Find("fps_component").gameObject.SetActive(false);
            transform.Find("orbit_component").gameObject.SetActive(false);
            transform.Find("movement_component").gameObject.SetActive(false);
        }
        else {
            switch (current_mode) {
            case "orbit":
                transform.Find("fps_component").gameObject.SetActive(false);
                transform.Find("orbit_component").gameObject.SetActive(true);
                transform.Find("movement_component").gameObject.SetActive(false);
                break;
            case "flying":
                transform.Find("fps_component").gameObject.SetActive(true);
                transform.Find("orbit_component").gameObject.SetActive(false);
                transform.Find("movement_component").gameObject.SetActive(true);
                break;
            }
        }
    }
}
