using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoutRadii : MonoBehaviour
{
    public SpoutRadii upR;
    public SpoutRadii downR;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = gameObject.GetComponent<CapsuleCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
