using System.Collections.Generic;
using UnityEngine;

public class AttackListGuitar : MonoBehaviour
{

    [SerializeField] private Animator anim;

    int atkToCall;

    private Stats stats;

    
    public Dictionary<string, int> attacksList_Name;
    public Dictionary<int, char> attacksList_AttackType;   // Physical, Musical
    public Dictionary<int, bool> attacksList_Unlocked;
    public Dictionary<int, bool> attacksList_Assigned;
    public Dictionary<int, int> attacksList_Phases;

    public string atkName;
    public float atkDamage;
    int atkPos;
    int phase;

    //private Instrument instrument;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<Stats>();
        // instrument = GetComponentInChildren<Instrument>();

        atkName = "No Attack";
        atkDamage = 0;
        phase = 1;

        attacksList_Name =new Dictionary<string, int>();
        attacksList_Unlocked = new Dictionary<int, bool>();
        attacksList_AttackType = new Dictionary<int, char>();
        attacksList_Phases = new Dictionary<int, int>();

        attacksList_Name["Ground Horizontal"]   = 0;
        attacksList_Name["Ground Vertical"]     = 1;
        //attacksList_Name["Ground Music"]        = 2;

        attacksList_Phases[0] = 3;
        attacksList_Phases[1] = 2;
        //attacksList_Phases[2] = 1;
    }

    void Update()
    {
        //Debug.Log(atkName);
    }

    

    public void AttackCall(string atkCalled, int phaseCalled)
    {
        Debug.Log("atkCalled in list: " + atkCalled);
        Debug.Log("phaseCalled in list: " + phaseCalled);
        atkPos = attacksList_Name[atkCalled];
        Debug.Log("atkPos in list: " + atkPos);
        // IF Unlocked & Assigned, then call
        AttackSelected(atkPos,phaseCalled);


        /*
         * 
         * 
         for (int i = 0; i < attackList.Length; i++)
          {
              if (atkCalled == attackList[i])
              {
                  Debug.Log("Llame a: " + atkCalled + " phase " + phase);
                  AttacksSelected(i, phase);
                  i = attackList.Length;
              }
          }        
          */
    }

    public void AttackSelected(int atkCalled, int phaseCalled)
    {
        switch (atkCalled)
        {
            case 0:
                Default_Ground_Horizontal(phaseCalled);
                break;

            case 1:
                Default_Ground_Vertical(phaseCalled);
                break;
        }
    }


    public bool CheckPhases(string atkToCheck, int currentPhase)
    {
        Debug.Log("--- Inicia check phases");
        Debug.Log("--- entro:");
        Debug.Log("--- atkToCheck " + atkToCheck);
        Debug.Log("--- currentPhase " + currentPhase);

        int phases = 1;
        int atkPos = 1;
        bool canCombo;

        atkPos = attacksList_Name[atkToCheck];
        phases = attacksList_Phases[atkPos];

        Debug.Log("--- atkPos, Phases");
        Debug.Log(atkPos);
        Debug.Log(phases);

        if (currentPhase < phases)
        {
            canCombo = true;
        }
        else
        {
            canCombo = false;
        }
        Debug.Log("--- canCombo: " + canCombo);
            return canCombo;
    }


    // ======================== //
    // =====    List     ===== //
    // ====================== //

    public void Default_Ground_Horizontal(int phaseToPlay)
    {
        atkName = "Default_Ground_Horizontal";
        switch (phaseToPlay)
        {
            case 1:
                anim.SetTrigger("Atk_Ground_Default_Horizontal_1");
                break;

            case 2:
                anim.SetTrigger("Atk_Ground_Default_Horizontal_2");
                break;

            case 3:
                anim.SetTrigger("Atk_Ground_Default_Horizontal_3");
                break;
        }
        
    }

    public void Default_Ground_Vertical(int phaseToPlay)
    {
        switch (phaseToPlay)
        {
            case 1:
                anim.SetTrigger("Atk_Ground_Default_Vertical_1");
                break;

            case 2:
                anim.SetTrigger("Atk_Ground_Default_Vertical_2");
                break;
        }

    }


































    /*

    public void atkHorizontalBasic()
    {
        attackName = "Horizontal Attack";
        anim.SetTrigger("isAttacking_BasicHorizontal");

        if (anim.GetBool("isAttacking_BasicHorizontal"))
        {
            damageMade = true;
        //    damage = stats.currentAtk * instrument.currentModifier;
        }
        else
        {
            damageMade = false;
            damage = 0;
        }
    }
    
    public void atkVerticalBasic()
    {
        attackName = "Vertical Attack";
        anim.SetTrigger("isAttacking_BasicVertical");

        if (anim.GetBool("isAttacking_BasicVertical"))
        {
            damageMade = true;
       //     damage = stats.currentAtk * instrument.currentModifier;
        }
        else
        {
            damageMade = false;
            damage = 0;
        }
    }

    public void atkAirBasic()
    {
        attackName = "Air Attack";
        anim.SetTrigger("isAttacking_BasicAir");

        if (anim.GetBool("isAttacking_BasicAir"))
        {
            damageMade = true;
        //    damage = stats.currentAtk * instrument.currentModifier;
        }
        else
        {
            damageMade = false;
            damage = 0;
        }
    }

    public void atkRiffTremolo()
    {
        attackName = "Tremolo Riff";
        anim.SetTrigger("isAttacking_TremoloRiff");

        if (anim.GetBool("isAttacking_TremoloRiff"))
        {
            damageMade = true;
        //    damage = stats.currentAtk + (25 * instrument.currentModifier);
        }
        else
        {
            damageMade = false;
            damage = 0;
        }
    }

    public void atkRiffHammerOn()
    {
        attackName = "Hammer-On Riff";
        anim.SetTrigger("isAttacking_HammerOnRiff");

        if (anim.GetBool("isAttacking_HammerOnRiff"))
        {
            damageMade = true;
         //   damage = stats.currentAtk + (10 * instrument.currentModifier);
        }
        else
        {
            damageMade = false;
            damage = 0;
        }
    }
    */


}


