using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbJuggle : MonoBehaviour
{
    float speed;
    float radius;
    public ThirdPersonCharacterController pCon;
    public GameObject climbable;
    //public CapsuleCollider climbCap;
    
    // Start is called before the first frame update
    void Start()
    {
        pCon = GetComponent<ThirdPersonCharacterController>();
        speed = pCon.speed;
        //radius = climbCap.radius;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        transform.RotateAround(climbable.transform.position, Vector3.up, Time.deltaTime * speed * Input.GetAxis("Horizontal"));
    }
}
