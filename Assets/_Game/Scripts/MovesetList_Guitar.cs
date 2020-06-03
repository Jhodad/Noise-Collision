using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesetList_Guitar : MonoBehaviour
{
    public Stats stats;
    private Animator anim;
    private Player player;

    public string test;

    private bool isGrounded;

    // Attacks
    public Atk_Gtr_BasicSwing basicSwing;
    public Atk_Gtr_BasicSwingHeavy basicSwingHeavy;
    public Atk_Gtr_PowerChordStrum powerChordStrum;
    public Atk_Gtr_PowerChordStinger powerChordStinger;
    public Atk_Gtr_HammerOn hammerOn;
    public Atk_Gtr_PullOff pullOff;
    public Atk_Gtr_Block block;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        stats = GetComponent<Stats>();
        player = GetComponent<Player>();

        // Attacks
        basicSwing = GetComponent<Atk_Gtr_BasicSwing>();
        Debug.Log("En Movesetlist: " + basicSwing.atkName);
        basicSwingHeavy = GetComponent<Atk_Gtr_BasicSwingHeavy>();
        powerChordStrum = GetComponent<Atk_Gtr_PowerChordStrum>();
        powerChordStinger = GetComponent<Atk_Gtr_PowerChordStinger>();
        hammerOn = GetComponent<Atk_Gtr_HammerOn>();
        pullOff = GetComponent<Atk_Gtr_PullOff>();
        block = GetComponent<Atk_Gtr_Block>();

        isGrounded = true;

        test = "haha";
    }

    void Update()
    {
        Debug.Log("En MOVESETLIST UPDATE: " + basicSwing.atkName);
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
                basicSwing.Perform(phaseToCall, isGrounded);
                break;

            case "Basic Swing Heavy":
                basicSwingHeavy.Perform(phaseToCall, isGrounded);
                break;
            
            case "Basic Strike":
                BasicStrike(phaseToCall, isGrounded);
                break;

            case "Basic Spin":
                BasicSpin(phaseToCall, isGrounded);
                break;
            
            case "Power Chord Strum":
                powerChordStrum.Perform(phaseToCall, isGrounded);
                break;
            
            case "Simple Power Stance":
                SimplePowerStance(phaseToCall, isGrounded);
                break;
            
            case "Power Chord Strum Slide":
                PowerChordStrumSlide(phaseToCall, isGrounded);
                break;

            case "Music Super 2":
                break;
           
            case "Power Chord Stinger":
                powerChordStinger.Perform(phaseToCall, isGrounded);
                break;
           
            case "Music Super Air 1":
                break;

            case "Hammer On":
                hammerOn.Perform(phaseToCall, isGrounded);
                break;

            case "Pull Off":
                pullOff.Perform(phaseToCall, isGrounded);
                break;

            case "Block":
                block.Perform(phaseToCall, isGrounded);
                break;
            
            case "Default Launcher":
                break;
            
            case "Default Slammer":
                break;
            
            case "Default Block1":
                break;
            
            case "Default Solo":
                break;
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
        if (state) // Ground
        {
            anim.SetTrigger("Guit_Atk_StrapSpin(Ground)");
        }
        else    // Air
        {
         
        }
    }
    // ==================================================== //
    // Basic
    // ==================================================== //




    // ==================================================== //
    // Music
    // ==================================================== //


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


