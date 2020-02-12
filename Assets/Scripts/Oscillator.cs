using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    float speed;
    float radius;
    float revolution;
    public ThirdPersonCharacterController pCon;
    public GameObject climbable;
    private CapsuleCollider climbCap;
    bool isBound = false;


    float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        pCon = GetComponent<ThirdPersonCharacterController>();
        Debug.Log(pCon.speed);
        speed = pCon.speed;
        climbCap = climbable.GetComponent<CapsuleCollider>();
        Debug.Log(climbCap.radius);
        radius = climbCap.radius;
        //speed = 1;
        //width = 4;
        //height = 7;

    }

    // Update is called once per frame
    void Update()
    {
       
        float hor = Input.GetAxis("Horizontal");
        timeCounter += Time.deltaTime * speed * hor;
        float x = Mathf.Cos(timeCounter) *radius;
        float y = 3;
        float z = Mathf.Sin(timeCounter) * radius;
        transform.position = new Vector3(x, y, z);
    }
}
