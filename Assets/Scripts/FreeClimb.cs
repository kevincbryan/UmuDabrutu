﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class FreeClimb : MonoBehaviour
    {
        public Animator anim;
        public ThirdPersonCharacterController myController;
        public ThirdPersonCameraController myCamera;
        public bool isClimbing;
        public Rigidbody myBody;
        bool inPosition;
        bool isLerping;
        float t;
        Vector3 startPos;
        Vector3 targetPos;
        Quaternion startRot;
        Quaternion targetRot;
        public float positionOffset;
        public float offsetFromWall = 0.3f;
        public float speed_multiplier = 0.2f;
        public float climbSpeed = 3;
        public float rotateSpeed = 5;
        public float inAngleDis = 1;
        float delta;
        Transform helper;

        public float horizontal;
        public float vertical;

        // Start is called before the first frame update
        void Start()
        {
            //Init();
        }

        public void Init()
        {

       
            helper = new GameObject().transform;
            helper.name = "climb helper";
            CheckForClimb();
          
        }

        public void CheckForClimb()
        {
            Vector3 origin = transform.position;
            origin.y += 1.4f;
            Vector3 dir = transform.forward;
            RaycastHit hit;
            if (Physics.Raycast(origin,dir, out hit, 5))
            {
                helper.position = PosWithOffset(origin, hit.point);
            //Debug.Log("Climbable Area is Found");
                InitForClimb(hit);
            }
        }

        void InitForClimb(RaycastHit hit)
        {
            isClimbing = true;
            myController.isClimbing = true;
            myCamera.isClimbing = true;
            myBody = myController.gameObject.GetComponent<Rigidbody>();
            myBody.useGravity = false;
            
            helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
            startPos = transform.position;
            targetPos = hit.point + (hit.normal * offsetFromWall);
            t = 0;
            inPosition = false;
            Debug.Log("InitForClimb is called. We are InPosition? " + inPosition);
            if (anim) anim.CrossFade("climb_idle", 2);
        }

        void Update()
        {
        //Debug.Log("Update has been called");

        if (isClimbing)
        {
            delta = Time.deltaTime;
            Tick(delta);
        }

         
        }

        public void Tick (float delta)
        {
        //Debug.Log("Tick has been called delta is " + delta);
            if (!inPosition)
            {
                GetInPosition();
                return;
            }

            if (!isLerping)
            {
                
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

                Vector3 h = helper.right * horizontal;
                Vector3 v = helper.up * vertical;
                Vector3 moveDir = (h + v).normalized;

                bool canMove = CanMove(moveDir);
                if (!canMove || moveDir == Vector3.zero)
                    return;

                t = 0;
                isLerping = true;
                startPos = transform.position;
                //Vector3 tp = helper.position - transform.position;

                targetPos = helper.position;


            }
            else
            {
                t += delta * climbSpeed;
                if (t > 1)
                {
                    t = 1;
                    isLerping = false;
                }

                Vector3 cp = Vector3.Lerp(startPos, targetPos, t);
                transform.position = cp;
                transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);
            }

        }

        bool CanMove (Vector3 moveDir)
        {
            
            Vector3 origin = transform.position;
            float dis = positionOffset;
            Vector3 dir = moveDir;
            Debug.DrawRay(origin, dir * dis, Color.red);
            RaycastHit hit;

            
            if (Physics.Raycast (origin, dir, out hit, dis))
            {
                
                return false;
            }

            origin += moveDir * dis;
            dir = helper.forward;
            float dis2 = inAngleDis;

            Debug.DrawRay(origin, dir * dis2, Color.blue);
            if (Physics.Raycast (origin, dir, out hit, dis))
            {
                
                helper.position = PosWithOffset(origin, hit.point);
                helper.rotation = Quaternion.LookRotation(-hit.normal);
                return true;
            }
            origin += dir * dis2;
            dir = -Vector3.up;

            Debug.DrawRay(origin, dir, Color.yellow);
            if (Physics.Raycast(origin, dir, out hit, dis2))
            {
                float angle = Vector3.Angle(helper.up, hit.normal);
                if (angle < 60)
                {

                    helper.position = PosWithOffset(origin, hit.point);
                    helper.rotation = Quaternion.LookRotation(-hit.normal);
                    return true;

                }


                
            }

            Debug.DrawRay(origin, dir, Color.yellow);
            if (Physics.Raycast(origin, dir, out hit, dis2))
            {
                float angle = Vector3.Angle(helper.right, hit.normal);
                if (angle < 60)
                {

                    helper.position = PosWithOffset(origin, hit.point);
                    helper.rotation = Quaternion.LookRotation(-hit.normal);
                    return true;

                }



            }


            return false;

        }


        void GetInPosition()
        {

        Debug.Log("GetInPosition is called");
            t += delta;
            if (t > 1)
            {
                t = 1;
                inPosition = true;

            }

            Vector3 tp = Vector3.Lerp(startPos, targetPos, t);
            transform.position = tp;

        }

        Vector3 PosWithOffset(Vector3 origin, Vector3 target)
        {
            Vector3 direction = origin - target;
            direction.Normalize();
            Vector3 offset = direction * offsetFromWall;
            return target + offset;
        }
    }

