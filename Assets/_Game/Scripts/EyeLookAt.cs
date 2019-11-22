using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLookAt : MonoBehaviour
{

    public GameObject rightEye;
    public GameObject leftEye;

    public GameObject target;

    public Transform rightPupil;
    public Transform leftPupil;

    //public float angleZ;

    public float distanceR;
    public float distanceL;

    Vector2 centerL;
    Vector2 centerR;

    Vector3 directionL;
    Vector3 directionLR;

    public float origSpeed;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        centerL = leftPupil.position;
        centerR = rightPupil.position;

        EyeDistanceFromCenter(distanceR, distanceL);
    }

    // Update is called once per frame
    void Update()
    {
        EyeRotator();
    }

    public void EyeDistanceFromCenter(float distanceR, float distanceL)
    {
        rightPupil.position = new Vector2(centerR.x + distanceR / 2, rightPupil.position.y);
        leftPupil.position = new Vector2(centerL.x + distanceL / 2, leftPupil.position.y);
    }


    public void EyeRotator()
    {
        //rightEye.transform.Rotate(0, 0, angleR);
        //leftEye.transform.Rotate(0, 0, angleL);
        //rightEye.transform.Rotate(new Vector3(0, 0, 1), 45);

        // The step size is equal to speed times frame time.

        /*
                Debug.Log("Distance: " + Vector2.Distance(target.transform.position, rightEye.transform.position));
        if (Vector2.Distance(target.transform.position, rightEye.transform.position) <= 2.2f || Vector2.Distance(target.transform.position, leftEye.transform.position) <= 2.2f)
        {
            speed = origSpeed *10 ;
            Debug.Log("distance is too close!");
        }
        else
        {
            speed = origSpeed;
        }
        
         */



        float step = origSpeed * Time.deltaTime;


        //Right
        Vector2 targetDirR = target.transform.position - rightEye.transform.position;
        //Left
        Vector2 targetDirL = target.transform.position - leftEye.transform.position;

        /*if ((Mathf.Abs(rightEye.transform.localRotation.x) <= 0.05 || Mathf.Abs(leftEye.transform.localRotation.x) <= 0.05) 
            && (Mathf.Abs(target.transform.position.x - rightEye.transform.position.x) <= 2 || Mathf.Abs(target.transform.position.x - leftEye.transform.position.x) <= 2))
        {
            Debug.Log("IM LERPING");
                //Debug.Log("Yep: " + rightEye.transform.localRotation.x + "-- Dist: " + Vector2.Distance(target.transform.position, rightEye.transform.position));
                Debug.Log("Yep: " + Mathf.Abs(target.transform.position.x - rightEye.transform.position.x));
            Vector2 targetDir = Vector2.Lerp(targetDirR, targetDirL, 0.5f);

            Debug.Log("Distance: " + Vector2.Distance(target.transform.position, rightEye.transform.position));
            Vector3 newDirR = Vector3.RotateTowards(rightEye.transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(rightEye.transform.position, newDirR, Color.red);
            // Move our position a step closer to the target.
            rightEye.transform.rotation = Quaternion.LookRotation(newDirR);

            Vector3 newDirL = Vector3.RotateTowards(leftEye.transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(leftEye.transform.position, newDirL, Color.red);
            // Move our position a step closer to the target.
            leftEye.transform.rotation = Quaternion.LookRotation(newDirL);

        }
        */

        //Vector2 targetDir = Vector2.Lerp(targetDirR, targetDirL, 0.5f);

        if (Vector2.Distance(target.transform.position, rightEye.transform.position) <= 1.5 || Vector2.Distance(target.transform.position, leftEye.transform.position) <= 1.5)
        //&& (Vector2.Distance(target.transform.position, rightEye.transform.position) >= 0.5 || Vector2.Distance(target.transform.position, leftEye.transform.position) <= 0.5))
        {
            //Debug.Log("THEY ARE TOO CLOSE");
            //Debug.Log("IM LERPING");
            //Debug.Log("Yep: " + rightEye.transform.localRotation.x + "-- Dist: " + Vector2.Distance(target.transform.position, rightEye.transform.position));
            //Debug.Log("Yep: " + Mathf.Abs(target.transform.position.x - rightEye.transform.position.x));
            Vector2 targetDir = Vector2.Lerp(targetDirR, targetDirL, 0.5f);

            //Debug.Log("Distance: " + Vector2.Distance(target.transform.position, rightEye.transform.position));
            Vector3 newDirR = Vector3.RotateTowards(rightEye.transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(rightEye.transform.position, newDirR, Color.red);
            // Move our position a step closer to the target.
            rightEye.transform.rotation = Quaternion.LookRotation(newDirR);

            Vector3 newDirL = Vector3.RotateTowards(leftEye.transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(leftEye.transform.position, newDirL, Color.red);
            // Move our position a step closer to the target.
            leftEye.transform.rotation = Quaternion.LookRotation(newDirL);
        }
        else
        {
            //Debug.Log("IM NOT LERPING");


            //Debug.Log("Distance: " + Vector2.Distance(target.transform.position, rightEye.transform.position));
            Vector3 newDirR = Vector3.RotateTowards(rightEye.transform.forward, targetDirR, step, 0.0f);
            Debug.DrawRay(rightEye.transform.position, newDirR, Color.red);
            // Move our position a step closer to the target.
            rightEye.transform.rotation = Quaternion.LookRotation(newDirR);

            Vector3 newDirL = Vector3.RotateTowards(leftEye.transform.forward, targetDirL, step, 0.0f);
            Debug.DrawRay(leftEye.transform.position, newDirL, Color.red);
            // Move our position a step closer to the target.
            leftEye.transform.rotation = Quaternion.LookRotation(newDirL);
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Looking at: ");
        if (collision.tag == "")
        {

        }
        
    }





}
