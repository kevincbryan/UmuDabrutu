﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform target, player;
    //public ClimbJuggle myClimb;
    public bool isClimbing = false;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        /*
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        
       
            if (isClimbing == false)
            {
                player.rotation = Quaternion.Euler(0, mouseX, 0);
            }


       

    }
}
