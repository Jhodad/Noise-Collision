using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Player player;
    InventoryTabs inventory;
    AttackHandler attackHandler;
    bool stopInput;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<Player>();
        inventory = GetComponent<InventoryTabs>();
        attackHandler = GetComponent<AttackHandler>();
        stopInput = false;
    }


    private void Update()
    {

    // Actions if Alive
    actionHandler();

    if (player.IsPlayingName("AttackPhase"))
        {
            stopInput = false;
        }
        else
        {
            stopInput = true;
        }
    }

    private void actionHandler()
    {
        // Actions always active
        player.Movement();

        // ==================================== //
        // ======       Attacks         ====== //
        // ================================== //
        

        if (Input.GetKeyDown(KeyCode.Y) && !player.anim.GetBool("isPlayingAttack")) //!stopInput)
        {
            Debug.Log("======================= INICIO HORIZ TODO =======================");
            stopInput = true;
            Debug.Log("ME APRETARON");
            attackHandler.Attack("Ground Horizontal");
            Debug.Log("======================= FIN HORIZ TODO =======================");
        }

        if (Input.GetKeyDown(KeyCode.U) && !player.anim.GetBool("isPlayingAttack")) //!stopInput)
        {
            Debug.Log("======================= INICIO VERTICAL TODO=======================");
            stopInput = true;
            attackHandler.Attack("Ground Vertical");
            Debug.Log("======================= FIN VERTICAL TODO =======================");
        }


        // Player is grounded
        if (player.isGrounded)
        {
            // if Space then Jump
            if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
            {
                player.Jump();
            }

        }

        // Player is airborne
        if (player.isGrounded == false)
        {

            // STUFF WHILE JUMPING
            if (player.rb.velocity.y > 0)
            {

            }

            // STUFF WHILE FALLING
            if (player.rb.velocity.y < 0)
            {
                
            }

        }

        
           
        

    }
    

}
