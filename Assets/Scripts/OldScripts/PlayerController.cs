using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float yRotSpeed;
    public float currentYRot;
    public float currentCamRoat;
    public float jumpForce = 2f;
    public float mouseX;

    

    public float fireSpeed = 1f;
    private float timeUntilFire = 0;
   

    public bool isMoving = false;

    //private InWater selfInWater;
    private Rigidbody rb;

    


  //  public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //selfInWater = GetComponent<InWater>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
            float moveForward = 0;
            float moveRight = 0;
            moveForward += Input.GetAxis("Vertical");
            moveRight += Input.GetAxis("Horizontal");

            Vector3 moveVector = (transform.forward * moveForward) + (transform.right * moveRight);

            moveVector.Normalize();
            moveVector *= speed * Time.deltaTime;
            transform.position += moveVector;
        }
        else
        {
            isMoving = false;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
           
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            
        }

 

        if (Input.GetAxis ("Jump") != 0)
        {

            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            Debug.Log("Jump is called");

         
        }

        //mouseX = Input.GetAxis("Mouse X");
        //transform.rotation *= Quaternion.Euler(0, mouseX, 0);


    }
   

  

    

}
