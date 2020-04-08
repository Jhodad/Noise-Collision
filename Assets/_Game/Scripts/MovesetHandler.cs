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
    private List<string> actionNameList;
    // All actions' is unlocked?
    private List<bool> actionNameList_isUnlocked;
    // ALL actions' phases
    private List<int> actionNameList_Phases;
    // ALL actions' type
    private List<int> actionNameList_Type;

    //Assigned Actions
    private List<string> actionNameList_moveset;

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

        actionNameList = new List<string>();
        actionNameList_isUnlocked = new List<bool>();
        actionNameList_moveset = new List<string>();
        actionNameList_Phases = new List<int>();
        actionNameList_Type = new List<int>();

        lastAtk = "none";
        canCountCombatCooldown = true;
        canCountComboTimeout = true;

        isAttacking = false;

        PopulateActionLists();
        AttackSelector();
    }

    private void Update()
    {
        LastAtkUpdate();
        CombatTimeoutWatcher();
        InAttackWatcher();
        //Debug.Log(" LAST ACITON: " + lastAtk);
    }

    // For each Attack Slot open a DropDownList and select the attack to assign IF unlocked true
    public void AttackSelector()
    {
        // TEMPORARY
        actionNameList_moveset.Add("PLACEHOLDER");
        actionNameList_moveset.Add(actionNameList[1]);
        actionNameList_moveset.Add(actionNameList[2]);
        actionNameList_moveset.Add(actionNameList[3]);
        actionNameList_moveset.Add(actionNameList[4]);
        actionNameList_moveset.Add(actionNameList[5]);
    }


    public void Perform(int actionCalledNum)
    {
        if (sPlayer.anim.GetBool("canAttack"))
        {

            switch (actionCalledNum)
            {
                // Atk - Basic 1
                case 1:
                    actionCalledName = actionNameList_moveset[1];
                    break;

                // Atk - Basic 2
                case 2:
                    actionCalledName = actionNameList_moveset[2];
                    break;

                // Atk - Special 1
                case 3:
                    actionCalledName = actionNameList_moveset[3];
                    break;

                // Atk - Special 2
                case 4:
                    actionCalledName = actionNameList_moveset[4];
                    break;

                // Atk - Special 3
                case 5:
                    actionCalledName = actionNameList_moveset[5];
                    break;

                // Atk - Special 4
                case 6:
                    actionCalledName = actionNameList_moveset[6];
                    break;

                // Atk - Stance
                case 7:
                    actionCalledName = actionNameList_moveset[7];
                    break;

                // Atk - Stance Music
                case 8:
                    actionCalledName = actionNameList_moveset[8];
                    break;

                // Atk - Solo
                case 9:
                    actionCalledName = actionNameList_moveset[9];
                    break;

                // Atk - Block
                case 10:
                    actionCalledName = actionNameList_moveset[10];
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
        i = actionNameList.IndexOf(actionCalledName);
        Debug.Log("== " + actionCalledName + " index is: " + i);

        // Get max phases of the action
        maxPhase = actionNameList_Phases[i];
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
                    test = actionNameList.IndexOf(lastAtk);
                    Debug.Log(" ------------ " + lastAtk + "pos in index is: " + test);
                    Debug.Log(" ------------ with type: " + actionNameList_Type[test]);
                    if (actionNameList_Type[test] == 1 && actionNameList_Type[i] == 1)
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
            test = actionNameList.IndexOf(lastAtk);
            Debug.Log(" ------------ " + lastAtk + "pos in index is: " + test);
            Debug.Log(" ------------ with type: " + actionNameList_Type[test]);

            if (actionNameList_Type[test] == 0 && actionNameList_Type[i] == 0) // it's a basic and the last one was a basic
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
        // Position 0 is just a placeholder
        actionNameList.Add("PLACEHOLDER");
        actionNameList_isUnlocked.Add(false);
        actionNameList_Phases.Add(1);
        actionNameList_Type.Add(0);

        // Default Actions

        /* [1] */
        actionNameList.Add("Basic Swing");
        actionNameList_isUnlocked.Add(true);
        actionNameList_Phases.Add(3);
        actionNameList_Type.Add(0);

        /* [2] */
        actionNameList.Add("Basic Swing Heavy");
        actionNameList_isUnlocked.Add(true);
        actionNameList_Phases.Add(2);
        actionNameList_Type.Add(0);

        /* [3] */
        actionNameList.Add("Power Chord Strum");
        actionNameList_isUnlocked.Add(true);
        actionNameList_Phases.Add(1);
        actionNameList_Type.Add(1);

        /* [4] */
        actionNameList.Add("Power Chord Stinger");
        actionNameList_isUnlocked.Add(true);
        actionNameList_Phases.Add(1);
        actionNameList_Type.Add(1);

        /* [5] */
        actionNameList.Add("Simple Power Stance");
        actionNameList_isUnlocked.Add(true);
        actionNameList_Phases.Add(1);
        actionNameList_Type.Add(1);

        /* [6] */

        /* [7] */

        /* [8] */
        actionNameList.Add("Basic Strike");
        actionNameList_isUnlocked.Add(true);
        

        /* [9] */
        actionNameList.Add("Basic Spin");
        actionNameList_isUnlocked.Add(true);
        

        /* [10] */
        actionNameList.Add("Power Chord Strum Slide");
        actionNameList_isUnlocked.Add(true);

        /* [11] */
        actionNameList.Add("Music Super 2"); //
        actionNameList_isUnlocked.Add(true);
        

        /* [12] */
        actionNameList.Add("Music Super Air 1"); // 
        actionNameList_isUnlocked.Add(true);

        /* [13] */
        actionNameList.Add("Default Launcher"); //
        actionNameList_isUnlocked.Add(true);

        /* [14] */
        actionNameList.Add("Default Slammer"); //
        actionNameList_isUnlocked.Add(true);

        /* [15] */
        actionNameList.Add("Default Block"); // 
        actionNameList_isUnlocked.Add(true);

        /* [16] */
        actionNameList.Add("Default Solo"); //
        actionNameList_isUnlocked.Add(true);

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