using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexClimb : MonoBehaviour
{
    public FreeClimb myClimb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myClimb = other.gameObject.GetComponent<FreeClimb>();
            if (myClimb)
            {
                myClimb.Init();
            }
        }
    }
}
