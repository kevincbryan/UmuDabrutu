using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbJuggle : MonoBehaviour
{
    float speed;
    float radius;
    public ThirdPersonCharacterController pCon;
    public SpoutRadii climbable;
    public SpoutRadii nextRadii;
    private CapsuleCollider climbCap;
    public bool atBottom = false;
    public bool atTop = false;
    private float lerpSource;
    float distance;
    float myDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        pCon = GetComponent<ThirdPersonCharacterController>();
        speed = pCon.speed;
        climbCap = climbable.gameObject.GetComponent<CapsuleCollider>();
        radius = climbable.radius;
        nextRadii = climbable.upR;
        //radius = climbCap.radius;
    }

    // Update is called once per frame
    void Update()
    {
        DiscoverRadius();
        MoveToRadius();
        HorizontalClimb();
        VerticalClimb();
        
    }

    void DiscoverRadius()
    {
        if (transform.position.y >= climbable.gameObject.transform.position.y)
        {
            nextRadii = climbable.upR;
            distance = nextRadii.gameObject.transform.position.y - climbable.gameObject.transform.position.y;
            myDistance = gameObject.transform.position.y - climbable.gameObject.transform.position.y;
            lerpSource = myDistance / distance;
            //Debug.Log(lerpSource);
            if (nextRadii == climbable)
                radius = climbable.radius;
            else
            {
                radius = Mathf.Lerp(nextRadii.radius, climbable.radius, lerpSource);
                Debug.Log("Current Radius: " + climbable + "Next Radius: " + nextRadii + "Radius up is " + radius);
            }

        }
        else
        {
            nextRadii = climbable.downR;
            distance = climbable.gameObject.transform.position.y - nextRadii.gameObject.transform.position.y;
            myDistance = transform.position.y - nextRadii.gameObject.transform.position.y;
            lerpSource = myDistance / distance;
            //Debug.Log(lerpSource);

            if (nextRadii == climbable)
                radius = climbable.radius;
            else
            {
                radius = Mathf.Lerp(climbable.radius, nextRadii.radius, lerpSource);
                Debug.Log("Current Radius: " + climbable + "Next Radius: " + nextRadii + "Radius down is " + radius);
            }
        }
            

        

       
    }

    void MoveToRadius ()
    {
        Vector3 dir = new Vector3 (climbable.gameObject.transform.position.x, gameObject.transform.position.y, climbable.gameObject.transform.position.z) - gameObject.transform.position;
        Vector3 endPos;
        if (dir.magnitude > radius)
        {
            endPos = gameObject.transform.position + new Vector3 (dir.x, gameObject.transform.position.y, dir.z).normalized * radius;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);
        }
        /*
        if (dir.magnitude < climbable.radius -1)
        {
            endPos = gameObject.transform.position + new Vector3(-dir.x, gameObject.transform.position.y, -dir.z).normalized * radius;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);
        }
        */

    }

    void HorizontalClimb ()
    {
        transform.RotateAround(climbable.gameObject.transform.position, Vector3.up, Time.deltaTime * speed * -Input.GetAxis("Horizontal"));
    }

    void VerticalClimb ()
    {
                    

        if (climbable == climbable.downR) atBottom = true;
        else atBottom = false;

        if (climbable == climbable.upR) atTop = true;
        else atTop = false;

       

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        if (atBottom == true && transform.position.y <= climbable.gameObject.transform.position.y && ver < 0)
        {
            ver = 0;
            //Disengage from climb?
        }

        if (atTop == true && transform.position.y >= climbable.gameObject.transform.position.y && ver > 0)
        {
            ver = 0;
            //Disengage from climb?
        }

        if (transform.position.y >= climbable.gameObject.transform.position.y + climbable.radius) climbable = climbable.upR;
        if (transform.position.y <= climbable.gameObject.transform.position.y - climbable.radius) climbable = climbable.downR;

        //Debug.Log(climbable);
        

        Vector3 playerMovement = new Vector3(0f, ver, 0f) * .5f * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
   
}
