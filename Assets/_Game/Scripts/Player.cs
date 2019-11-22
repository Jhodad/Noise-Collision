
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Serialzied Fields
    public Animator anim;

    // Objects
    public Rigidbody rb;
    public Stats stats;



    // Booleans
    public bool orientacionU = false;
    public bool onRangeForTrade;

    // Vectors
    public Vector3 horiz;
    public Vector3 verti;

    private float perspective; // -1 to use back camera

    // Movement
    public float x;
    public float z;

    // Idle Check
    public bool flag;
    int seconds = 0;


    // ========================================================================================================= //

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<Stats>();

        perspective = 1f;

        anim.SetTrigger("isNeutral");
    }

    // Fixed for rigid body stuff
    
    void FixedUpdate()
    {
        CheckLanding();
        CheckFalling();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        perspective = gameObject.GetComponent<CameraSwitch>().perspectiveValue;



        //Debug.Log("Normal" + IsPlaying("AttackPhase"));
        //Debug.Log("Name" + IsPlayingName("AttackPhase"));

        if (Input.anyKey)
        {
            //Debug.Log("Se apreto una tecla, segunods y flag reseteada");
            flag = false;
            seconds = 0;
        }
        else
        {
            flag = true;
        }


        /*

        if (IsPlaying("Neutral"))
        {
            StartCoroutine(CheckIdle());
        }
        */

        //Debug.Log("Modifier: " + currentAirModifier);
    }




    // =============================================================== METHODS / FUNCTIONS ===============================================================

    bool RotateLeft(bool orientacion)
    {
        if (orientacion)
        {
            //Debug.Log("Ya estaba viendo a la izq");
        }
        else
        {
            transform.Rotate(Vector3.up * 180);
            orientacion = true;
            //Debug.Log("Giro a la izq");
        }
        return orientacion;
    }

    bool RotateRight(bool orientacion)
    {
        if (orientacion)
        {
            transform.Rotate(Vector3.up * 180);
            //Debug.Log("Giro a la der");
            orientacion = false;
        }
        else
        {
            //Debug.Log("Ya estaba viendo a la der");
        }
        return orientacion;
    }

    public void Movement()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * stats.currentSpeed * stats.currentModifierSpeed * perspective;
        z = Input.GetAxis("Vertical") * Time.deltaTime * stats.currentSpeed * stats.currentModifierSpeed * perspective;
        horiz = new Vector3(x, 0, 0);
        verti = new Vector3(0, 0, z);

        if ((x != 0 || z != 0) && (IsPlayingName("Neutral") || IsPlayingName("Run")) || IsPlayingName("Idle") || IsPlayingName("Landing") || IsPlayingName("Jump") || IsPlayingName("Falling"))
        {
            anim.SetBool("isRunning", true);

            if (stats.isGrounded)
            {
                if (x > 0)
                {
                    orientacionU = RotateRight(orientacionU);
                }
                else if (x < 0)
                {
                    orientacionU = RotateLeft(orientacionU);
                }
                else // x = 0
                {

                }
            }

            //rb.MovePosition(horiz);
            //rb.MovePosition(verti);
            transform.Translate(horiz, Space.World);
            transform.Translate(verti, Space.World);
        }
        else if (x == 0 && z == 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isNeutral");

        }
    }

    public void Jump()
    {

        if (IsPlayingName("Neutral") || IsPlayingName("Run") || IsPlayingName("Idle"))
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector3.up * (stats.currentJump * stats.currentModifierJump), ForceMode.Impulse);
        }
    }

    public void CheckFalling()
    {
        if (rb.velocity.y < 0 && !stats.isGrounded)
        {
            anim.SetBool("isFalling", true);
        }
    }

    public void CheckLanding()
    {
        if (rb.velocity.y == 0 && anim.GetBool("isFalling"))
        {
            anim.SetBool("isFalling", false);
            anim.SetTrigger("isLanding");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    }

    private void OnCollisionStay(Collision collision)
    {
    }

    private void OnCollisionExit(Collision collision)
    {
    }

    /*
        IEnumerator CheckIdle()
        {
            if (flag)
            {
                yield return new WaitForSecondsRealtime(1);
                seconds++;
                Debug.Log("Han pasado: " + seconds);

                if (seconds == 5 && flag)
                {
                    Debug.Log("Si pasaron 5 segundos!");
                    anim.SetTrigger("isIdle");
                }
                else
                {
                    Debug.Log("NMo han pasado 5 segundso!");
                    StartCoroutine(CheckIdle());
                }
            }


        }
        */
    public bool IsPlaying(string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    public bool IsPlayingName(string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
            return true;
        else
            return false;
    }

    bool CanDoAction(string stateName)
    {
        /*
        switch (stateName)
        {
            case "Neutral":
                if (anim.GetBool(""))
                {
                    return true;
                }
                
                return true;

            case "Idle":
                break;

            case "Run":
                break;

            case "Jump":
                break;

            case "Falling":
                break;

            case "Landing":
                break;

            case "Basic_Horizontal_1":
                break;
                return true;

        }
                */

        return true;
    }

    /*
    public void PickUpItem(Item item, int itemType)
    {
        if (inventory.AddItem(item, itemType))
        {
            itemPickedUp.gameObject.SetActive(false);
            itemPickedUp = null;
            inventory.itemAdded = false;
            itemEnteredCollision = false;
        }
        else
        {
            Debug.Log("Item: " + itemPickedUp + " cannot be picked up");
            itemPickedUp = null;
            inventory.itemAdded = false;
            itemEnteredCollision = false;
        }
    }
    */


}
