using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour //From github.com/jiankaiwang
{
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public Transform character;
    private Vector2 mouseLook;
    private Vector2 smoothV;
    
    // Start is called before the first frame update
    void Start()
    {
        //character = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;

        if (Input.GetAxisRaw("Mouse X")!= 0)
        {
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            //character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }
        


    }
}
