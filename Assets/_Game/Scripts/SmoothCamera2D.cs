using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2D : MonoBehaviour
{

    private float interpVelocity;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    public float interpVelocityModif;
    public float maxSpeed;
    public float smoothTime;
    public Vector3 currentVelVect = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        Vector3 cameraPosition = target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        cameraPosition.x = target.transform.position.x;
        updateOffset();
        cameraPosition.z = zDistanceToTarget;
        transform.position = Vector3.Slerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
        */
         
            if (target)
           {
               Vector3 posNoZ = transform.position;
               posNoZ.z = target.transform.position.z;

               Vector3 targetDirection = (target.transform.position - posNoZ);


               interpVelocity = targetDirection.magnitude * interpVelocityModif;

               targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

               //transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
               transform.position = Vector3.SmoothDamp(transform.position, targetPos + offset, ref currentVelVect, smoothTime, maxSpeed);
        }
       
        
    }
}