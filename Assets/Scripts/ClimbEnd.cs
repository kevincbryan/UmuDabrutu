using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbEnd : MonoBehaviour
{

    public FreeClimb myClimb;
    public ThirdPersonCharacterController myController;
    public ThirdPersonCameraController myCamera;
    public Transform swimTarget;
    private CapsuleCollider myCollider;
    private Rigidbody myBody;
    public float swimSpeed = 10f;
    public bool isSwimming = false;
    public bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwimming)
        {

            if (Vector3.Distance(myClimb.gameObject.transform.position, swimTarget.position) > 0)
            {
                myClimb.gameObject.transform.position = Vector3.MoveTowards(myClimb.gameObject.transform.position, swimTarget.position, swimSpeed * Time.deltaTime);
            }
            else
            {
                isSwimming = false;
                myClimb.isClimbing = false;
                myController.isClimbing = false;
                myCamera.isClimbing = false;
                myCollider.enabled = true;
                myBody.useGravity = true;                            
            }
            
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (doOnce == false)
        {

            if (other.tag == "Player")
            {
                myClimb = other.gameObject.GetComponent<FreeClimb>();
                myController = other.gameObject.GetComponent<ThirdPersonCharacterController>();
                myCamera = other.gameObject.GetComponentInChildren<ThirdPersonCameraController>();
                myCollider = other.gameObject.GetComponentInChildren<CapsuleCollider>();
                myBody = other.gameObject.GetComponentInChildren<Rigidbody>();
                myCollider.enabled = false;
                isSwimming = true;
                Debug.Log("Swimming should begin");
                doOnce = true;
            }

        }

       
    }
}
