using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// fps control scheme
// orbit control scheme
public class player_script : MonoBehaviour
{
    private CharacterController character_controller;
    // private GameObject head;
    public float SPEED = 5f;
    public float SENS = 1f;

    public GameObject myObj;

    void Start()
    {   
        
        character_controller = GetComponent<CharacterController>();
        // head = transform.Find("player_head").gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 turn = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));

        character_controller.Move(move * Time.deltaTime * SPEED);
        // head.transform.RotateAround (head.transform.position, Vector3.up, turn.x * SENS * Time.deltaTime);
        // head.transform.RotateAround (head.transform.position, -transform.right, turn.z * SENS * Time.deltaTime); 
    }
}
