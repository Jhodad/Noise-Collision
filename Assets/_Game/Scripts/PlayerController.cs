using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Player player;
    Stats stats;
    InventoryTabs inventory;
    MovesetHandler movesetHandler;
    
    bool stopInput;

    // for combat recovery
    bool canCountCombatPhase;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<Player>();
        inventory = GetComponent<InventoryTabs>();
        movesetHandler = GetComponent<MovesetHandler>();
        stats = GetComponent<Stats>();
        stopInput = false;
        canCountCombatPhase = true;
    }


    private void Update()
    {

        // Actions if Alive
        if (stats.isAlive)
        {
            // List of constant actions
            actionHandler();

            /*
            if (movesetHandler.stateCombat & !(movesetHandler.statePerformingAttack))
            {
                if (canCountCombatPhase)
                {
                    StartCoroutine(OnCombatDuration());
                }
                
            }
            */
        }
    }
    
    

    private void actionHandler()
    {
        // Actions always active
        player.Movement();

        // ==================================== //
        // ======       Attacks         ====== //
        // ================================== //

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            movesetHandler.Perform(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            movesetHandler.Perform(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            movesetHandler.Perform(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            movesetHandler.Perform(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            movesetHandler.Perform(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            movesetHandler.Perform(7);
        }

        if (Input.GetKey(KeyCode.Alpha7))
        {
            movesetHandler.Perform(8);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            movesetHandler.Perform(9);
        }

        
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("======================= INICIO HORIZ TODO =======================");
            stopInput = true;
            Debug.Log("ME APRETARON");
            attackHandler.Attack("Ground Horizontal");
            Debug.Log("======================= FIN HORIZ TODO =======================");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("======================= INICIO VERTICAL TODO=======================");
            //stopInput = true;
            attackHandler.Attack("Ground Vertical");
            Debug.Log("======================= FIN VERTICAL TODO =======================");
        }

         */




        // XP TEST
        if (Input.GetKeyDown(KeyCode.Z))
        {
            stats.AddXP(150);
        }

        // Battery Recovery Test
        if (Input.GetKeyDown(KeyCode.Period))
        {
            stats.currentBattery = stats.currentBattery - 10;
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            stats.currentBattery = stats.currentBattery + 10;
        }


        // Player is grounded
        if (stats.isGrounded)
        {
            // if Space then Jump
            if (Input.GetKeyDown(KeyCode.Space) && stats.isGrounded)
            {
                player.Jump();
            }

        }

        // Player is airborne
        if (stats.isGrounded == false)
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

    /* IEnumerator OnCombatDuration()
    {
        // onRecovery_Wait = Seconds to wait onCombat before onRecovery

        canCountCombatPhase = false;

        while (player.anim.GetInteger("onRecovery_Elapsed") < player.anim.GetInteger("onRecovery_Wait"))
        {
            Debug.Log("Entered the while");
            Debug.Log("Begin Waiting...");
            yield return new WaitForSecondsRealtime(1);
            player.anim.SetInteger("onRecovery_Elapsed", (player.anim.GetInteger("onRecovery_Elapsed") + 1));

            Debug.Log("End Waiting...");
            Debug.Log("El valor de segundos esperados es: " + player.anim.GetInteger("onRecovery_Elapsed"));

            if (player.anim.GetBool("performingAction"))
            {
                Debug.Log("LEFT IDLE combat, so dont count anynmore");
                player.anim.SetInteger("onRecovery_Elapsed",(player.anim.GetInteger("onRecovery_Wait") + 1));
            }

            if (player.anim.GetInteger("onRecovery_Elapsed") == player.anim.GetInteger("onRecovery_Wait"))
            {
                Debug.Log("OnCombat idle timeout, so recovery");
                movesetHandler.StateRecovery(true);
                Debug.Log("Se acaba la combat phase, entra recovery");
            }
            
        }
        player.anim.SetInteger("onRecovery_Elapsed", 0);
        canCountCombatPhase = true;
    }
    */
}
