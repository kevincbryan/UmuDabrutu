using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaController : MonoBehaviour
{

    public AudioManager myAudio;
    public float time = 0f;
    private bool voiceOnce_01 = false;
    private bool voiceOnce_02 = false;
    private bool voiceOnce_03 = false;
    public Animator animation01;
    public Animator animation02;
    public Animator animation03;
    public Animator animation04;
    private bool animOnce_01 = false;
    private bool animOnce_02 = false;
    private bool animOnce_03 = false;
    private bool animOnce_04 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2f && !voiceOnce_01)
        {
            myAudio.Play(0);
            voiceOnce_01 = true;
        }

        if (time >= 2f && !animOnce_01)
        {
            animation01.SetBool("ShatterMe", true);
            animOnce_01 = true;
        }

        if (time >= 6f && !voiceOnce_02)
        {
            myAudio.Play(1);
            voiceOnce_02 = true;
        }
        if (time >= 6f && !animOnce_02)
        {
            animation02.SetBool("ShatterMe", true);
            animOnce_02 = true;
        }

        if (time >= 10f && !voiceOnce_03)
        {
            myAudio.Play(2);
            voiceOnce_03 = true;
        }

        if (time >= 10f && !animOnce_03)
        {
            animation03.SetBool("ShatterMe", true);
            animOnce_03 = true;
        }

        if (time >= 15f && !animOnce_04)
        {
            animation04.SetBool("ShatterMe", true);
            animOnce_04 = true;
        }
    }
}
