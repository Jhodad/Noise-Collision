using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesetHandler : MonoBehaviour
{

    private MovesetList_Guitar sMovesetList;
    private Stats sStats;
    private Player sPlayer;
    


    // LISTS
    // All Actions
    private List<string> actionList_Name;
    // All actions' is unlocked?
    private List<bool> actionList_isUnlocked;
    // ALL actions' phases
    private List<int> actionList_Phases;
    // ALL actions' type
    private List<int> actionList_Type;
    // ALL action' cost
    private List<float> actionList_Cost;
    // ALL action' damage
    private List<float> actionList_Damage;

    //Assigned Actions
    private List<string> actionList_Moveset;

    private string actionCalledName;
    private string lastAtk;

    // for Combat
    public bool isOnCombat;
    private bool canCountCombatCooldown;
    private bool canCountComboTimeout;
    public bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        sPlayer = GetComponent<Player>();
        sMovesetList = GetComponent<MovesetList_Guitar>();
        sStats = GetComponent<Stats>();

        Debug.Log("START ANTES DE LISTAS: " + sMovesetList.basicSwing.atkName);
        Debug.Log("START ANTES DE LISTAS DE MOVESET: " + sMovesetList.test);
        Debug.Log("SSTATS: " + sMovesetList.stats.maxBattery);

        actionList_Name = new List<string>();
        actionList_isUnlocked = new List<bool>();
        actionList_Moveset = new List<string>();
        actionList_Phases = new List<int>();
        actionList_Type = new List<int>();
        actionList_Cost = new List<float>();
        actionList_Damage = new List<float>();

        Debug.Log("START DESSPUES DE LISTAS: " + sMovesetList.basicSwing.atkName);

        lastAtk = "none";
        canCountCombatCooldown = true;
        canCountComboTimeout = true;

        isAttacking = false;

        PopulateActionLists();
        
        AttackSelector();
        Debug.Log("DESPUES ATKSELECT: " + sMovesetList.basicSwing.atkName);
    }

    private void Update()
    {
        Debug.Log("En MOVESETHANDLER UPDATE ANTES: " + sMovesetList.basicSwing.atkName);
        LastAtkUpdate();
        CombatTimeoutWatcher();
        InAttackWatcher();
        Debug.Log("En MOVESETHANDLER UPDATE DESPUES: " + sMovesetList.basicSwing.atkName);
        //Debug.Log(" LAST ACITON: " + lastAtk);       
        Debug.Log("3pull: " + sMovesetList.stats.maxBattery);

    }

    // For each Attack Slot open a DropDownList and select the attack to assign IF unlocked true
    public void AttackSelector()
    {
        // TEMPORARY
        actionList_Moveset.Add("PLACEHOLDER");
        actionList_Moveset.Add(actionList_Name[1]);
        actionList_Moveset.Add(actionList_Name[2]);
        actionList_Moveset.Add(actionList_Name[3]);
        actionList_Moveset.Add(actionList_Name[4]);
        actionList_Moveset.Add(actionList_Name[5]);
        actionList_Moveset.Add(actionList_Name[6]);
        actionList_Moveset.Add(actionList_Name[7]);
        actionList_Moveset.Add(actionList_Name[8]);
        actionList_Moveset.Add(actionList_Name[9]);

    }


    public void Perform(int actionCalledNum)
    {
        if (sPlayer.anim.GetBool("canAttack"))
        {

            switch (actionCalledNum)
            {
                // Atk - Basic 1
                case 1:
                    actionCalledName = actionList_Moveset[1];
                    break;

                // Atk - Basic 2
                case 2:
                    actionCalledName = actionList_Moveset[2];
                    break;

                // Atk - Special 1
                case 3:
                    actionCalledName = actionList_Moveset[3];
                    break;

                // Atk - Special 2
                case 4:
                    actionCalledName = actionList_Moveset[4];
                    break;

                // Atk - Special 3
                case 5:
                    actionCalledName = actionList_Moveset[5];
                    break;

                // Atk - Special 4
                case 6:
                    actionCalledName = actionList_Moveset[6];
                    break;

                // Atk - Stance
                case 7:
                    actionCalledName = actionList_Moveset[7];
                    break;

                // Atk - Stance Music
                case 8:
                    actionCalledName = actionList_Moveset[8];
                    break;

                // Atk - Solo
                case 9:
                    actionCalledName = actionList_Moveset[9];
                    break;

                // Atk - Block
                case 10:
                    actionCalledName = actionList_Moveset[10];
                    break;

                    /*
                case default:
                    actionCalledName = "recovery";
                    break;
                    */
            }
            // NOTE: THIS SHOULD ONLY HAPPEN WHEN ITS AN ATTACK

            Debug.Log("== ATTACK CALLED: " + actionCalledName);
            ActionHandler();
        }
        else
        {
            Debug.Log("CANT ATTACK");
        }

    }

    /*
     if (!(sPlayer.anim.GetBool("performingAction")))
    {
        canAttack = true;
        //Debug.Log("Im not performing an action");
    }
    else if(sPlayer.anim.GetBool("performingAction") & !(sPlayer.anim.GetBool("onCombat")))
    {
        canAttack = false;
        //Debug.Log("Lost combo, is currently on recovery");
    }
    else
    {
        canAttack = false;
        //Debug.Log("Performing an action so cant attack");
    }
     */

    // Call if an attack is pressed or when the player receives damage


    private void ActionHandler()
    {
        Debug.Log("======== START ======== ");
        int maxPhase, i;

        // Get index of the action
        i = actionList_Name.IndexOf(actionCalledName);
        Debug.Log("== " + actionCalledName + " index is: " + i);

        // Get max phases of the action
        maxPhase = actionList_Phases[i];
        Debug.Log("== " + actionCalledName + " phases are: " + maxPhase + ", " + " and current phase is: " + sPlayer.anim.GetInteger("atkPhase"));
        Debug.Log("==== CALLED: " + actionCalledName);
        Debug.Log("==== LAST: " + lastAtk);

        if (lastAtk == "none")
        { // First Attack
            sMovesetList.ActionCall(actionCalledName, sPlayer.anim.GetInteger("atkPhase"));
            lastAtk = actionCalledName;

        }
        else if (lastAtk == actionCalledName)
        { // ON A CHAIN

            if (sPlayer.anim.GetInteger("atkPhase") == 1)
            { // Initial attack
                //Debug.Log("No puedes repetir este ataque!!!!");
                sMovesetList.ActionCall(actionCalledName, 1);
            }
            else
            {
                // If the current phase is less than the max phases call the attack
                if (sPlayer.anim.GetInteger("atkPhase") <= maxPhase)
                {
                    Debug.Log("There is another phase");
                    Debug.Log("RIGHT HERE IMA CALL: " + actionCalledName + " - " + sPlayer.anim.GetInteger("atkPhase"));
                    sMovesetList.ActionCall(actionCalledName, sPlayer.anim.GetInteger("atkPhase"));
                    lastAtk = actionCalledName;
                }
                // else, exceeded phasess so force a combo losss
                else
                {
                    int test;
                    test = actionList_Name.IndexOf(lastAtk);
                    Debug.Log(" ------------ " + lastAtk + "pos in index is: " + test);
                    Debug.Log(" ------------ with type: " + actionList_Type[test]);
                    if (actionList_Type[test] == 1 && actionList_Type[i] == 1)
                    { // If its a music type, then its spammable
                        sPlayer.anim.SetInteger("atkPhase", 1);
                        sMovesetList.ActionCall(actionCalledName, sPlayer.anim.GetInteger("atkPhase"));
                        lastAtk = actionCalledName;
                    }
                    else
                    {
                        Debug.Log("Made a mistake, combo lost");
                        sPlayer.anim.SetBool("comboLost", true);
                        sPlayer.anim.SetInteger("atkPhase", 1);
                        sPlayer.anim.SetInteger("combatTimeoutCurrentTime", 1);
                        StartCoroutine(CombatCooldown());
                    }
                    
                }
            }

        }
        else // lastAtk =/= actionCalledName so just a new chain
        {
            int test;
            test = actionList_Name.IndexOf(lastAtk);
            Debug.Log(" ------------ " + lastAtk + "pos in index is: " + test);
            Debug.Log(" ------------ with type: " + actionList_Type[test]);

            if (actionList_Type[test] == 0 && actionList_Type[i] == 0) // it's a basic and the last one was a basic
            {
                Debug.Log("Combo loss, cant cycle through basics");
                sPlayer.anim.SetBool("comboLost", true);
                sPlayer.anim.SetInteger("atkPhase", 1);
                sPlayer.anim.SetInteger("combatTimeoutCurrentTime", 1);
                //sMovesetList.ActionCall(actionCalledName, sPlayer.anim.GetInteger("atkPhase"));
                //lastAtk = actionCalledName;
                StartCoroutine(CombatCooldown());
            }
            else
            {
                sPlayer.anim.SetInteger("atkPhase", 1);
                sMovesetList.ActionCall(actionCalledName, sPlayer.anim.GetInteger("atkPhase"));
                lastAtk = actionCalledName;
            }
            
        }
        Debug.Log("======== END ======== ");
    }

    private void LastAtkUpdate()
    {
        if (sPlayer.anim.GetBool("EnteredAction"))
        {
            lastAtk = actionCalledName;
        }

        if (sPlayer.IsPlayingName("Neutral"))
        { // Chain ended so lastAtk is none
            //lastAtk = "none";
        }
        else if (sPlayer.anim.GetBool("comboLost"))
        {
            sPlayer.anim.SetBool("canAttack", false);
            lastAtk = "none";
        }
    }


    IEnumerator CombatCooldown()
    {
        canCountCombatCooldown = false;
        sPlayer.anim.SetBool("canAttack", false);

        while (sPlayer.anim.GetInteger("onRecovery_Elapsed") < sPlayer.anim.GetInteger("onRecovery_Wait"))
        {
            Debug.Log("Entered the while");
            Debug.Log("Begin Waiting...");
            yield return new WaitForSecondsRealtime(1);
            sPlayer.anim.SetInteger("onRecovery_Elapsed", (sPlayer.anim.GetInteger("onRecovery_Elapsed") + 1));

            Debug.Log("End Waiting...");
            Debug.Log("El valor de segundos esperados es: " + sPlayer.anim.GetInteger("onRecovery_Elapsed"));

            // IF STATS.(RECEIVED DAMAGED) then CANCEL RECOVERY
        }
        sPlayer.anim.SetBool("comboLost", false);
        sPlayer.anim.SetBool("canAttack", true);
        sPlayer.anim.SetInteger("onRecovery_Elapsed", 0);
        canCountCombatCooldown = true;
    }

    private void CombatTimeoutWatcher()
    {
        if (sPlayer.anim.GetBool("combatTimeout"))
        {
            if (canCountComboTimeout)
            {
                Debug.Log("SI ENTRE!");
                StartCoroutine(CombatComboTimeout());
            }
            
        }
    }

    private void InAttackWatcher()
    {
        if (sPlayer.anim.GetInteger("combatTimeoutCurrentTime") > 0)
        { // IF there is a timeout for combat, then we're on atk
            isOnCombat = true;
            if (sPlayer.anim.GetBool("EnteredAction"))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        }
        else
        {
            isOnCombat = false;
        }

    }

    IEnumerator CombatComboTimeout()
    {
        canCountComboTimeout = false;
        while (!(sPlayer.anim.GetInteger("combatTimeoutCurrentTime") == 0))
        {

            yield return new WaitForSecondsRealtime(1);
            sPlayer.anim.SetInteger("combatTimeoutCurrentTime", (sPlayer.anim.GetInteger("combatTimeoutCurrentTime") - 1));
        }
        // LOSE ALL COMBO BUFFS
        lastAtk = "none";
        Debug.Log("COMBAT ENDED, BONUS LOST");
        canCountComboTimeout = true;
        sPlayer.anim.SetBool("combatTimeout", false);
    }




    private void PopulateActionLists()
    {

        Debug.Log("EMPEZANDO PPOPULATE: " + sMovesetList.basicSwing.atkName);
        // Position 0 is just a placeholder
        actionList_Name.Add("PLACEHOLDER");
        actionList_isUnlocked.Add(false);
        actionList_Phases.Add(1);
        actionList_Type.Add(0);
        actionList_Cost.Add(sMovesetList.powerChordStrum.cost);

        // Default Actions

        /* [1] */ // Basic Swing
        Debug.Log("smoveset list: " + sMovesetList.basicSwing.atkName);
        actionList_Name.Add(sMovesetList.basicSwing.atkName);
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.basicSwing.phases);
        actionList_Type.Add(sMovesetList.basicSwing.type);
        actionList_Cost.Add(sMovesetList.powerChordStrum.cost);

        /* [2] */ // Basic Swing Heavy
        actionList_Name.Add(sMovesetList.basicSwingHeavy.atkName);
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.basicSwingHeavy.phases);
        actionList_Type.Add(sMovesetList.basicSwingHeavy.type);
        actionList_Cost.Add(sMovesetList.powerChordStrum.cost);

        /* [3] */ // Power Chord Strum
        actionList_Name.Add(sMovesetList.powerChordStrum.atkName);
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.powerChordStrum.phases);
        actionList_Type.Add(sMovesetList.powerChordStrum.type);
        actionList_Cost.Add(sMovesetList.powerChordStrum.cost);

        /* [4] */ // Power Chord Stinger
        actionList_Name.Add(sMovesetList.powerChordStinger.atkName);
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.powerChordStinger.phases);
        actionList_Type.Add(sMovesetList.powerChordStinger.type);

        /* [5] */ // Power Stance
        actionList_Name.Add("Simple Power Stance");
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(1);
        actionList_Type.Add(1);

        /* [6] */ // Hammer On
        actionList_Name.Add(sMovesetList.hammerOn.atkName);
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.hammerOn.phases);
        actionList_Type.Add(sMovesetList.hammerOn.type);

        /* [7] */ // Pull Off
        actionList_Name.Add(sMovesetList.pullOff.atkName);
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.pullOff.phases);
        actionList_Type.Add(sMovesetList.pullOff.type);

        /* [8] */ // Block
        actionList_Name.Add(sMovesetList.block.atkName); // 
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(sMovesetList.block.phases);
        actionList_Type.Add(sMovesetList.block.type);

        /* [9] */ 
        actionList_Name.Add("Basic Spin");
        actionList_isUnlocked.Add(true);
        actionList_Phases.Add(1);
        actionList_Type.Add(1);


        /* [10] */
        actionList_Name.Add("Power Chord Strum Slide");
        actionList_isUnlocked.Add(true);

        /* [11] */
        actionList_Name.Add("Music Super 2"); //
        actionList_isUnlocked.Add(true);
        

        /* [12] */
        actionList_Name.Add("Music Super Air 1"); // 
        actionList_isUnlocked.Add(true);

        /* [13] */
        actionList_Name.Add("Default Launcher"); //
        actionList_isUnlocked.Add(true);

        /* [14] */
        actionList_Name.Add("Default Slammer"); //
        actionList_isUnlocked.Add(true);

        /* [15] */
        

        /* [16] */
        actionList_Name.Add("Default Solo"); //
        actionList_isUnlocked.Add(true);

        // Unlockables

        /* [17] */

        /* [18] */

        /* [19] */

        /* [20] */

        /* [21] */

        /* [22] */

        /* [23] */

        /* [24] */

        /* [25] */

        /* [26] */

        /* [27] */

        /* [28] */

        /* [29] */

        /* [30] */

        /* [31] */

        /* [32] */

        /* [33] */

        /* [34] */

        /* [35] */

        /* [36] */

        /* [37] */

        /* [38] */

        /* [39] */

        /* [40] */

        /* [41] */

        /* [42] */

        /* [43] */

        /* [44] */

        /* [45] */

        /* [46] */

        /* [47] */

        /* [48] */

        /* [49] */




    }

}