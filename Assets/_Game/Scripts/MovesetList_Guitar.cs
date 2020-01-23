using System.Collections.Generic;
using UnityEngine;

public class MovesetList_Guitar : MonoBehaviour
{
    private Stats stats;
    private Animator anim;
    private Player player;

    private bool isGrounded;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        stats = GetComponent<Stats>();
        player = GetComponent<Player>();

        isGrounded = true;
    }

    void Update()
    {
        if (stats.isGrounded)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    

    public void ActionCall(string actionCalled, int phaseToCall)
    {
        Debug.Log("Performing: " + actionCalled + ", with phase: " + phaseToCall);
        
        switch (actionCalled)
        {
            // ==================================================== //
            // Basic
            case "Basic Swing":
                BasicSwing(phaseToCall, isGrounded);
                break;

            case "Basic Swing Heavy":
                BasicSwingHeavy(phaseToCall, isGrounded);
                break;
            
            case "Basic Strike":
                BasicStrike(phaseToCall, isGrounded);
                break;

            case "Basic Spin":
                BasicSpin(phaseToCall, isGrounded);
                break;
            // Basic
            // ==================================================== //




            // ==================================================== //
            // Music
            case "Power Chord Strum":
                PowerChordStrum(phaseToCall, isGrounded);
                break;
            // Music
            // ==================================================== //

            


            // ==================================================== //
            // Stance
            case "Simple Power Stance":
                SimplePowerStance(phaseToCall, isGrounded);
                break;
            // Stance
            // ==================================================== //




            // ==================================================== //
            // Music Super
            case "Power Chord Strum Slide":
                PowerChordStrumSlide(phaseToCall, isGrounded);
                break;

            case "Music Super 2":
                break;
           
            case "Power Chord Stinger":
                PowerChordStinger(phaseToCall, isGrounded);
                break;
           
            case "Music Super Air 1":
                break;
            // Music Super
            // ==================================================== //




            // ==================================================== //
            // Launcher
            case "Default Launcher":
                break;
            // Launcher
            // ==================================================== //




            // ==================================================== //
            // Slammer
            case "Default Slammer":
                break;
            // Slammer
            // ==================================================== //



            // ==================================================== //
            // Block
            case "Default Block":
                break;
            // Block
            // ==================================================== //




            // ==================================================== //
            // Solo
            case "Default Solo":
                break;
            // Solo
            // ==================================================== //







        }
    }




    // ======================== //
    // =====    List     ===== //
    // ====================== //
    // NOTE: 
    // State = true is Ground
    // State = false is Air


    // ==================================================== //
    // Basic
    // ==================================================== //
    public void BasicSwing(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            switch (phaseToPlay)
            {
                case 1:
                    anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_1");
                    break;

                case 2:
                    if (player.IsPlayingName("Guit_Atk_BasicSwing(Ground)_1"))
                    {
                        anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_2");
                    }
                    break;

                case 3:
                    if (player.IsPlayingName("Guit_Atk_BasicSwing(Ground)_2"))
                    {
                        anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_3");
                    }
                    break;
            }
        }
        else    // Air
        {
            Debug.Log("Thiss attack doesnt have air anims");
        }
    }

    public void BasicSwingHeavy(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            switch (phaseToPlay)
            {
                case 1:
                    anim.SetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_1");
                    break;

                case 2:
                    if (player.IsPlayingName("Guit_Atk_BasicSwingHeavy(Ground)_1"))
                    {
                        anim.SetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_2");
                    }
                    
                    break;
            }
        }
        else    // Air
        {
        }
    }

    public void BasicStrike(int phaseToPlay, bool state)
    {
        if (state)
        {

        }
        else
        {
            //call anim
        }
    }
    
    public void BasicSpin(int phaseToPlay, bool state)
    {
        if (state)
        {

        }
        else
        {
            //call anim
        }
    }
    // ==================================================== //
    // Basic
    // ==================================================== //




    // ==================================================== //
    // Music
    // ==================================================== //
    public void PowerChordStrum(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            anim.SetTrigger("Guit_Atk_PowerChordStrum(Ground)");
        }
        else    // Air
        {
            anim.SetTrigger("Guit_Atk_PowerChordStrum(Air)");
        }
    }

    // ==================================================== //
    // Music
    // ==================================================== //




    // ==================================================== //
    // Stance
    // ==================================================== //
    public void SimplePowerStance(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            anim.SetTrigger("Guit_Atk_SimplePowerStance(Ground)");
        }
        else    // Air
        {
            anim.SetTrigger("Guit_Atk_SimplePowerStance(Air)");
        }
    }
    // ==================================================== //
    // Stance
    // ==================================================== //




    // ==================================================== //
    // Music Super
    // ==================================================== //
    public void PowerChordStinger(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            anim.SetTrigger("Guit_Atk_PowerChordStinger(Ground)");
        }
        else    // Air
        {

        }
    }

    public void PowerChordStrumSlide(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            anim.SetTrigger("Guit_Atk_PowerChordStrumSlide(Ground)");
        }
        else    // Air
        {

        }
    }
    // ==================================================== //
    // Music Super
    // ==================================================== //




    // ==================================================== //
    // Launcher
    // ==================================================== //
    // ==================================================== //
    // Launcher
    // ==================================================== //




    // ==================================================== //
    // Slammer
    // ==================================================== //
    // ==================================================== //
    // Slammer
    // ==================================================== //



    // ==================================================== //
    // Block
    // ==================================================== //
    // ==================================================== //
    // Block
    // ==================================================== //




    // ==================================================== //            
    // Solo
    // ==================================================== //
    // ==================================================== //
    // Solo
    // ==================================================== //



 

}


