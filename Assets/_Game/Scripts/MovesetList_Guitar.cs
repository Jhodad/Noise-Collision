using System.Collections.Generic;
using UnityEngine;

public class MovesetList_Guitar : MonoBehaviour
{
    private Stats stats;
    [SerializeField] private Animator anim;

    // Use this for initialization
    void Start()
    {
     
    }

    void Update()
    {
     
    }

    

    public void ActionCall(string actionCalled,int phaseToCall)
    {
        switch (actionCalled)
        {
            // ==================================================== //
            // Basic
            case "Basic Swing (Ground)":
                BasicSwing(phaseToCall, true);
                break;

            case "Basic Swing Heavy (Ground)":
                BasicSwingHeavy(phaseToCall, true);
                break;
            
            case "Basic Strike (Air)":
                BasicStrike(phaseToCall, false);
                break;

            case "Basic Spin (Air)":
                BasicSpin(phaseToCall, false);
                break;
            // Basic
            // ==================================================== //




            // ==================================================== //
            // Music
            case "Power Chord Strum (Ground)":
                PowerChordStrum(phaseToCall, true);
                break;

            case "Power Chord Strum (Air)":
                PowerChordStrum(phaseToCall, false);
                break;
            // Music
            // ==================================================== //

            


            // ==================================================== //
            // Stance
            case "Simple Power Stance (Ground)":
                SimplePowerStance(phaseToCall, true);
                break;

            case "Simple Power Stance (Air)":
                SimplePowerStance(phaseToCall, false);
                break;
            // Stance
            // ==================================================== //




            // ==================================================== //
            // Music Super
            case "Power Chord Strum Slide":
                PowerChordStrumSlide(phaseToCall, true);
                break;

            case "Music Super 2":
                break;
           
            case "Power Chord Stinger (Ground)":
                PowerChordStinger(phaseToCall, true);
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
                    anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_2");
                    break;

                case 3:
                    anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_3");
                    break;
            }
        }
        else    // Air
        {
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
                    anim.SetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_2");
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


