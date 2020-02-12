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
        
    }

    void MoveToRadius ()
    {
        Vector2 dir = new Vector2 (climbable.transform.position.x, climbable.transform.position.z) - new Vector2 (gameObject.transform.position.x, gameObject.transform.position.z);
        Vector3 endPos;
        if (dir.magnitude > radius)
        {
            endPos = gameObject.transform.position + new Vector3 (dir.x, 0, dir.y).normalized * radius;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);
        }


    }

    void HorizontalClimb ()
    {
        transform.RotateAround(climbable.transform.position, Vector3.up, Time.deltaTime * speed * Input.GetAxis("Horizontal"));
    }
   
}
