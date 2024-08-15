using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKey(KeyCode.F)) {
            // enable flying
            transform.Find("fps_component").gameObject.SetActive(true);
            transform.Find("movement_component").gameObject.SetActive(true);
            // disable orbit
            transform.Find("orbit_component").gameObject.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.O)) {
            // enable orbit
            transform.Find("orbit_component").gameObject.SetActive(true);
            // disable flying
            transform.Find("fps_component").gameObject.SetActive(false);
            transform.Find("movement_component").gameObject.SetActive(false);
        }
            
    }
}
