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
    Mesh climbableMesh;
    private Vector3 normalTarget;

    public Climbable myClimb;
    public bool isClimbing = false;

    Vector3 nearestVertex;
    
    // Start is called before the first frame update
    void Start()
    {

        //if (myClimb) myClimb.isClimbed = true;

        pCon = GetComponent<ThirdPersonCharacterController>();
        speed = pCon.speed;
        climbCap = climbable.gameObject.GetComponent<CapsuleCollider>();
        radius = climbable.radius;
        nextRadii = climbable.upR;
        //NearestVertex();
        //radius = climbCap.radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            myClimb = other.gameObject.GetComponent<Climbable>();
            isClimbing = true;
            if (myClimb) myClimb.isClimbed = true;
            //Debug.Log("myClimb is " + myClimb);
            climbableMesh = myClimb.myMesh;
            //NearestVertex();
            //Debug.Log("climbableMesh = " + climbableMesh);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //NearestVertex();
        DiscoverRadius();
        MoveToRadius();
        HorizontalClimb();
        VerticalClimb();
        
    }

    void DiscoverRadius()
    {
        float radius00 = 12f;
        float radius10 = 10f;
        float radius20 = 10f;
        float radius30 = 11f;
        float radius40 = 12f;
        float radius50 = 13f;
        float radius60 = 16f;
        float radius70 = 22f;
        float radius80 = 32.5f;

       

        //Vector3 temp = myClimb.gameObject.transform.localPosition;
        //NearestVertex();
        //Vector3 target = new Vector3(myClimb.gameObject.transform.localPosition.x, 0, myClimb.gameObject.transform.localPosition.z);
        //Vector3 outsideVertex = new Vector3(nearestVertex.x, 0, nearestVertex.z);

        //radius = Vector3.Distance(target, outsideVertex) / 2;
        //Debug.Log("Radius is " + radius);

        if (pCon.gameObject.transform.position.y <= 0)
        {
            radius = radius00;
        }
        else if (pCon.gameObject.transform.position.y <= 10)
        {
            radius = radius10;
        }
        else if (pCon.gameObject.transform.position.y <= 20)
        {
            radius = radius20;
        }
        else if (pCon.gameObject.transform.position.y <= 30)
        {
            radius = radius30;
        }
        else if (pCon.gameObject.transform.position.y <= 40)
        {
            radius = radius40;
        }
        else if (pCon.gameObject.transform.position.y <= 50)
        {
            radius = radius50;
        }
        else if (pCon.gameObject.transform.position.y <= 60)
        {
            radius = radius60;
        }
        else if (pCon.gameObject.transform.position.y <= 70)
        {
            radius = radius70;
        }
        else 
        {
            radius = radius80;
        }



        //if (transform.position.y >= climbable.gameObject.transform.position.y)
        //{
        //    nextRadii = climbable.upR;
        //    distance = nextRadii.gameObject.transform.position.y - climbable.gameObject.transform.position.y;
        //    myDistance = gameObject.transform.position.y - climbable.gameObject.transform.position.y;
        //    lerpSource = myDistance / distance;
        //    //Debug.Log(lerpSource);
        //    if (nextRadii == climbable)
        //        radius = climbable.radius;
        //    else
        //    {
        //        radius = Mathf.Lerp(nextRadii.radius, climbable.radius, lerpSource);
        //        Debug.Log("Current Radius: " + climbable + "Next Radius: " + nextRadii + "Radius up is " + radius + "Target Y level is " + climbable.gameObject.transform.position.y);
        //        //Debug.Log("Climbable Y is " + climbable.gameObject.transform.position.y);
        //    }

        //}
        //else
        //{
        //    nextRadii = climbable.downR;
        //    distance = climbable.gameObject.transform.position.y - nextRadii.gameObject.transform.position.y;
        //    myDistance = transform.position.y - nextRadii.gameObject.transform.position.y;
        //    lerpSource = myDistance / distance;
        //    //Debug.Log(lerpSource);

        //    if (nextRadii == climbable)
        //        radius = climbable.radius;
        //    else
        //    {
        //        radius = Mathf.Lerp(climbable.radius, nextRadii.radius, lerpSource);
        //        Debug.Log("Current Radius: " + climbable + "Next Radius: " + nextRadii + "Radius down is " + radius);
        //        //Debug.Log("Climbable Y is " + climbable.gameObject.transform.position.y);
        //    }
        //}




    }

    void MoveToRadius ()
    {
        float inOrOut = 1;

        if (Vector3.Distance (new Vector3 (climbable.gameObject.transform.position.x, transform.position.y, climbable.gameObject.transform.position.z), transform.position) > radius)
        {
           inOrOut = 1;
        }
        else if (Vector3.Distance(new Vector3(climbable.gameObject.transform.position.x, transform.position.y, climbable.gameObject.transform.position.z), transform.position) < radius)
        {
            inOrOut = -1;
        }

        transform.position = Vector3.MoveTowards(transform.position, climbable.gameObject.transform.position, speed * .5f * Time.deltaTime * inOrOut);

        //Vector3 endPos = new Vector3(climbable.gameObject.transform.position.x, transform.position.y, climbable.gameObject.transform.position.z);
        //Vector3 dir = climbable.transform.position - transform.position;
        //Vector3 reverseDir = transform.position - climbable.transform.position;

        //if (reverseDir.magnitude > radius)
        //{
        //    endPos = transform.position + dir.normalized * radius;
        //}

        //Vector3 dir = new Vector3 (climbable.gameObject.transform.position.x, gameObject.transform.position.y, climbable.gameObject.transform.position.z) - gameObject.transform.position; 
        //Vector3 endPos;
        //Vector3 newDir = dir.normalized * radius;
        ////endPos = gameObject.transform.position + new Vector3 (newDir.x, 0, newDir.z);

        //if (dir.magnitude > radius)
        //    endPos = gameObject.transform.position + new Vector3(dir.x, 0, dir.z).normalized * radius;
        //else
        //transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);

        //if (dir.magnitude > radius)
        //{
        //    endPos = gameObject.transform.position + new Vector3 (dir.x, gameObject.transform.position.y, dir.z).normalized * radius;
        //    transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);
        //}

        //if (dir.magnitude < climbable.radius)
        //{
        //    endPos = gameObject.transform.position + new Vector3(dir.x, gameObject.transform.position.y, dir.z).normalized * radius;
        //    transform.position = Vector3.MoveTowards(transform.position, endPos, speed * .5f * Time.deltaTime);
        //}


    }

    void NearestVertex ()
    {
        float minDistanceSqr = Mathf.Infinity;
        nearestVertex = Vector3.zero;
        int vertexValue = 0;

        if (climbableMesh)
        {

            for (int i = 0; i < climbableMesh.vertices.Length; i++)
            {
                Vector3 diff = pCon.gameObject.transform.position - climbableMesh.vertices[i];
                float distSqr = diff.sqrMagnitude;

                if (distSqr < minDistanceSqr)
                {
                    minDistanceSqr = distSqr;
                    nearestVertex = climbableMesh.vertices[i];
                    vertexValue = i;
                }
            }

            //Debug.Log("NearestVertex is " + nearestVertex);
            //Debug.Log("Vertex Position is " + vertexValue);

            normalTarget = climbableMesh.normals[vertexValue];
            normalTarget = Vector3.Cross(normalTarget, Vector3.left);
            //Debug.Log("Vertex normal is " + normalTarget);
            //pCon.playerObject.rotation = Quaternion.FromToRotation(Vector3.forward, normal);

        }





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
        if (transform.position.y < climbable.gameObject.transform.position.y - climbable.radius) climbable = climbable.downR;

        //Debug.Log(climbable);
        

        Vector3 playerMovement = new Vector3(0f, ver, 0f) * .5f * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        //NearestVertex();
        Quaternion newRotation = Quaternion.FromToRotation(Vector3.up, normalTarget);
        pCon.playerObject.localRotation = Quaternion.RotateTowards(pCon.playerObject.localRotation, newRotation, speed * Time.deltaTime);
        
    }
   
}
