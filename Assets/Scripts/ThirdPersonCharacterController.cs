using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float speed = 1f;
    public bool isClimbing = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Player speed is : " + speed);
    }

    // Update is called once per frame
    void Update()
    {
      if(isClimbing == false) PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
