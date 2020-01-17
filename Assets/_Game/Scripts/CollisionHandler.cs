using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{


    //Player player;
    Stats stats;
    Player player;
    Animator anim;

    [SerializeField] private float OffsetCenterAxisX;
    [SerializeField] private float rayOffsetAxisX;
    [SerializeField] private float rayOffsetAxisY;
    [SerializeField] private float maxRayDistance;

    private int obstacleLayer;
    private RaycastHit objectHit;

    [SerializeField] private bool isGroundedRight;
    [SerializeField] private bool isGroundedLeft;

    Color leftColor;
    Color rightColor;

    void Start()
    {
        player = GetComponent<Player>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();

        obstacleLayer = 1 << LayerMask.NameToLayer("Obstacles");

        rightColor = Color.blue;
        leftColor = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FloorDetector();


    }

    public void FloorDetector()
    {
        Vector3 originRight = new Vector3(OffsetCenterAxisX + transform.position.x + rayOffsetAxisX, transform.position.y + rayOffsetAxisY, transform.position.z);
        Vector3 endRight = new Vector3(originRight.x, transform.position.y - maxRayDistance, transform.position.z);

        Vector3 originLeft = new Vector3(OffsetCenterAxisX + transform.position.x - rayOffsetAxisX, transform.position.y + rayOffsetAxisY, transform.position.z);
        Vector3 endLeft = new Vector3(originLeft.x, transform.position.y - maxRayDistance, transform.position.z);

        Debug.DrawLine(originRight, endRight, rightColor);
        Debug.DrawLine(originLeft, endLeft, leftColor);

        // Right RayCast
        if (Physics.Raycast(originRight, Vector3.down, out objectHit, maxRayDistance, obstacleLayer))
        {
           // Debug.Log("Right hit object: " + objectHit.collider.name);
            isGroundedRight = true;
            rightColor = Color.green;
        }
        else
        {
           // Debug.Log("Right didnt hit anything");
            isGroundedRight = false;
            rightColor = Color.blue;
        }

        // Left RayCast
        if (Physics.Raycast(originLeft, Vector3.down, out objectHit, maxRayDistance, obstacleLayer))
        { 
            //Debug.Log("Left hit object: " + objectHit.collider.name);
            isGroundedLeft = true;
            leftColor = Color.green;
        }
        else
        {
            //Debug.Log("Left didnt hit anything");
            isGroundedLeft = false;
            leftColor = Color.red;
        }

        // Notify isGrounded to Stats
        // If both, then grounded
        // If just one then check for Slope, otherwise it's a ledge
        
        if (isGroundedRight && isGroundedLeft)          // If both grounded
        {
            stats.isGrounded = true;
            stats.isGroundedSlope = false;
        } 
        else if (isGroundedRight && !isGroundedLeft)  // If Right grounded but not Left
        {
            
        }
        else if (!isGroundedRight && isGroundedLeft)    // If Left grounded but not Right
        {
            
        }
        else                                            // If both NOT grounded, then air            
        {
            
            stats.isGrounded = false;
            stats.isGroundedSlope = false;
        }
        
    }








}

