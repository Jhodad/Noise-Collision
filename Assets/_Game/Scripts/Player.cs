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
    public bool isGrounded;
    public bool orientacionU = false;
    public bool onRangeForTrade;

    // Vectors
    private Vector3 horiz;
    private Vector3 verti;

    // Floats
    private float defaultAirModifierGround;
    private float defaultAirModifierAir;

    private float currentAirModifier;

    private float speedModifier;
    private float jumpModifier;
    private float defaultSpeed;
    private float defaultJump;

    private float perspective; // -1 to use back camera

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

        speedModifier = stats.modifierSpeed;
        jumpModifier = stats.modifierJump;

        defaultSpeed = stats.defaultSpeed;
        defaultJump = stats.defaultJump;

        defaultAirModifierGround = stats.defaultAirModifierGround;
        defaultAirModifierAir = stats.defaultAirModifierAir;
        currentAirModifier = defaultAirModifierGround;

        anim.SetTrigger("isNeutral");
    }

    // Fixed for rigid body stuff
    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        perspective = gameObject.GetComponent<CameraSwitch>().perspectiveValue;
        speedModifier = stats.modifierSpeed;
        jumpModifier = stats.modifierJump;

        defaultSpeed = stats.defaultSpeed;
        defaultJump = stats.defaultJump;

        defaultAirModifierGround = stats.defaultAirModifierGround;
        defaultAirModifierAir = stats.defaultAirModifierAir;

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
        if (rb.velocity.y < 0 && !isGrounded)
        {
            //Debug.Log(rb.velocity.y);

            Debug.Log("Supuestamente aqui: "+ rb.velocity.y);
                anim.SetBool("isFalling", true);
                
            
            
        }
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
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * defaultSpeed * speedModifier * currentAirModifier * perspective;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * defaultSpeed * speedModifier * currentAirModifier * perspective;
        horiz = new Vector3(x, 0, 0);
        verti = new Vector3(0, 0, z);

        if ((x != 0 || z != 0) && (IsPlayingName("Neutral") || IsPlayingName("Run")) || IsPlayingName("Idle") || IsPlayingName("Landing") || IsPlayingName("Jump") || IsPlayingName("Falling"))
        {
            anim.SetBool("isRunning", true);


                if (x > 0)
                {
                    if (isGrounded)
                    {
                        orientacionU = RotateRight(orientacionU);
                    }
                }
                else if (x < 0)
                {
                    if (isGrounded)
                    {
                        orientacionU = RotateLeft(orientacionU);
                    }
                }

                transform.Translate(horiz, Space.World);
                transform.Translate(verti, Space.World);
            }
        else if (x == 0 && z == 0)
        {
            //StartCoroutine(CheckIdle());
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isNeutral");
            
        }

    }

    public void Jump()
    {

        if (IsPlayingName("Neutral") || IsPlayingName("Run") || IsPlayingName("Idle"))
        {
            Debug.Log("Que segun si");
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector3.up * (defaultJump * jumpModifier), ForceMode.Impulse);
            
        }
        
        
            
    }

    void OnCollisionEnter(Collision collision)
    {

        // Returns air modifier to default when colliding with the ground
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isFalling", false);
            anim.SetTrigger("isLanding");
            currentAirModifier = defaultAirModifierGround;
            isGrounded = true;
           
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            currentAirModifier = defaultAirModifierAir;
        }

    }

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
