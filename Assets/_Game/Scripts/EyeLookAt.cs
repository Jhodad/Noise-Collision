using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLookAt : MonoBehaviour
{

    public GameObject rightEye;
    public GameObject leftEye;

    public Transform rightPupil;
    public Transform leftPupil;

    //public float angleZ;

    public float distanceR;
    public float distanceL;

    Vector2 centerL;
    Vector2 centerR;

    public float origSpeed;

    public List<GameObject> touchingObjects;
    private bool hasObservable;
    private GameObject observableTarget;
    public GameObject defaultTarget;

    public Animator anim;
    private int blinkRandomizer;
    
    private int blinkCount;
    private int secondsWithoutBlink = 0;


    // Start is called before the first frame update
    void Start()
    {
        //origRotation = rightEye.transform.rotation.;


        anim = GetComponent<Animator>();

        touchingObjects = new List<GameObject>();
        
        observableTarget = new GameObject();
        observableTarget = null;
        
        centerL = leftPupil.position;
        centerR = rightPupil.position;
        hasObservable = false;
        
        EyeDistanceFromCenter(distanceR, distanceL);

        StartCoroutine(WaitSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        

        if (hasObservable)
        {
            EyeRotator();
        }
        else
        {
            Debug.Log("There are no observables");
            EyeDefaultRotator();

        }
        Debug.Log("Cpacidad: " + touchingObjects.Capacity);

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
        Vector2 targetDirR = observableTarget.transform.position - rightEye.transform.position;
        //Left
        Vector2 targetDirL = observableTarget.transform.position - leftEye.transform.position;

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

        if (true) //Vector2.Distance(observableTarget.transform.position, rightEye.transform.position) <= 1.5 || Vector2.Distance(observableTarget.transform.position, leftEye.transform.position) <= 1.5
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


    public void EyeDefaultRotator()
    {
        float step = origSpeed * Time.deltaTime * 10;


        //Right
        Vector2 targetDirR = defaultTarget.transform.position - rightEye.transform.position;
        //Left
        Vector2 targetDirL = defaultTarget.transform.position - leftEye.transform.position;

       

        if (Vector2.Distance(defaultTarget.transform.position, rightEye.transform.position) <= 1.5 || Vector2.Distance(defaultTarget.transform.position, leftEye.transform.position) <= 1.5)
        {
            
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

    IEnumerator WaitSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            secondsWithoutBlink++;
            BlinkRandomizer();
        }
    }
    private void BlinkRandomizer()
    {
        blinkRandomizer = Random.Range(0, 10);
        


        if (blinkRandomizer <= 5)
        {
            blinkRandomizer = 1;
        }
        else 
        {
            blinkRandomizer = 0;
        }

        switch (blinkRandomizer)
        {
            case 0:
                anim.SetBool("isBlinking",true);
                break;

            case 1:
                anim.SetBool("isBlinking", false);
                break;

            default:
                anim.SetBool("isBlinking", false);
                break;
        }

        if (secondsWithoutBlink > 5)
        {
            secondsWithoutBlink = 0;
            anim.SetBool("isBlinking", true);
        }

        Debug.Log("BLINK: " + blinkCount);
        if (blinkCount > 3)
        {
            anim.SetBool("isBlinking", false);
            blinkCount = 0;
        }
        else
        {
            blinkCount++;
        }
    }

    // List Handler
    private void ListAdd(GameObject objectToAdd)
    {
        if (!touchingObjects.Contains(objectToAdd))
        {
            touchingObjects.Add(objectToAdd);
            Debug.Log(objectToAdd.name + " was added");
            //observableTarget = touchingObjects.Find(objectToAdd => objectToAdd.CompareTag("Observable"));
            hasObservable = true;
            Debug.Log("Called Search Assign: " + objectToAdd);
            SearchAssign(objectToAdd);

        }
        else
        {
            Debug.Log("LIST: OBJECT WAS ALREADY ADDED");
        }
    }

    private void ListRemove(GameObject objectToRemove)
    {
        if (touchingObjects.Contains(objectToRemove))
        {
            touchingObjects.Remove(objectToRemove);
            Debug.Log(objectToRemove.name + " was removed");

        }

        SearchAssignNext();
    }

    private void SearchAssign(GameObject objectToFind) //Assigns when added
    {
        int pos = 0;
        while (pos < touchingObjects.Count)
        {
            Debug.Log("Entre a search");
            if (touchingObjects[pos].name == objectToFind.name)
            {
                Debug.Log("Que segun si");
                observableTarget = touchingObjects[pos];
                pos = touchingObjects.Count;
            }
            else
            {
                Debug.Log("Que segun no, ent: pos = " + pos);
                pos++;
            }
        }
    }

    private void SearchAssignNext() //Adds the first target in list
    {
        if (touchingObjects.Count == 0)
        {
            Debug.Log("List is empty!");
            hasObservable = false;
            EyeDefaultRotator();
            Debug.Log("Aqui hace la rotacion");

           /* //rightEye.transform.rotation.Set(0,0,90,1);
             
            float step = origSpeed * Time.deltaTime;
            //Right
            Vector2 targetDirR = new Vector2(rightEye.transform.position.x + 10, rightEye.transform.position.y);
            //Left
            Vector2 targetDirL = new Vector2(leftEye.transform.position.x + 10, leftEye.transform.position.y);

            Vector3 newDirR = Vector3.RotateTowards(rightEye.transform.forward, targetDirR, step*100, 0.0f);
            rightEye.transform.rotation = Quaternion.LookRotation(newDirR);

            Vector3 newDirL = Vector3.RotateTowards(leftEye.transform.forward, targetDirL, step*100, 0.0f);            
            leftEye.transform.rotation = Quaternion.LookRotation(newDirL);
        */


        }
        else
        {
            observableTarget = touchingObjects[0];

        }
    }

public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Observable")
        {
            ListAdd(collision.gameObject); // Adds to list and assigns added item
            
        }   
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Observable")
        {
            ListRemove(collision.gameObject);

            //Debug.Log("Capacity before " + touchingObjects.Capacity);
            //touchingObjects.Remove(collision.gameObject);
            //Debug.Log("Capacity after " + touchingObjects.Capacity);
        }
    }



}
