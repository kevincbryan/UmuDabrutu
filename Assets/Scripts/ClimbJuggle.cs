using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbJuggle : MonoBehaviour
{
    float speed;
    float radius;
    public ThirdPersonCharacterController pCon;
    public GameObject climbable;
    private CapsuleCollider climbCap;
    
    // Start is called before the first frame update
    void Start()
    {
        pCon = GetComponent<ThirdPersonCharacterController>();
        speed = pCon.speed;
        climbCap = climbable.GetComponent<CapsuleCollider>();
        radius = climbCap.radius;
        //radius = climbCap.radius;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToRadius();
        HorizontalClimb();
        VerticalClimb();
        
    }

    void MoveToRadius ()
    {
        Vector3 dir = new Vector3 (climbable.transform.position.x, gameObject.transform.position.y, climbable.transform.position.z) - gameObject.transform.position;
        Vector3 endPos;
        if (dir.magnitude > radius)
        {
            endPos = gameObject.transform.position + new Vector3 (dir.x, gameObject.transform.position.y, dir.z).normalized * radius;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);
        }


    }

    void HorizontalClimb ()
    {
        transform.RotateAround(climbable.transform.position, Vector3.up, Time.deltaTime * speed * -Input.GetAxis("Horizontal"));
    }

    void VerticalClimb ()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(0f, ver, 0f) * .5f * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
   
}
