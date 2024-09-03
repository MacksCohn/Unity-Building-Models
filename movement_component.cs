using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_component : MonoBehaviour
{
    public new Camera camera;
    [Range(3f,10f)]
    public float move_speed = 5f;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 to_move = new Vector3(
            Input.GetAxis("Horizontal"),
            (Input.GetKey(KeyCode.Space) ? 1:0) - (Input.GetKey(KeyCode.LeftShift) ? 1:0),
            Input.GetAxis("Vertical"));
        to_move *= move_speed;
        camera.transform.Translate(to_move * Time.deltaTime);
    }
}
