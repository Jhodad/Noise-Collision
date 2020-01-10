using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesetHandler : MonoBehaviour
{

    private MovesetList_Guitar sMovesetList;
    private Stats sStats;
    private Player sPlayer;

    private List<string> actionNameList;
    private List<bool> actionNameList_isUnlocked;
    private List<string> actionNameList_moveset;

    private string actionCalledName;
    private int actionCalledPhase;
    private string lastActionCalled;
    // Start is called before the first frame update
    void Start()
    {
        sPlayer = GetComponent<Player>();
        sMovesetList = GetComponent<MovesetList_Guitar>();
        sStats = GetComponent<Stats>();

        actionNameList = new List<string>();
        actionNameList_isUnlocked = new List<bool>();
        actionNameList_moveset = new List<string>();
    }

    private void Update()
    {

    }

    // For each Attack Slot open a DropDownList and select the attack to assign IF unlocked true
    public void AttackSelector()
    {

    }

    private void PhaseWatcher(string newAction)
    {
        if (newAction == lastActionCalled)
        {
            //Check phases list
            if () // If the action only has one phase then phase = 1
            {
                actionCalledPhase = 1;
            }
            else // The action'ss phases are > 1
            {
                if () // if there's still a next phase then phase++
                {
                    actionCalledPhase++;
                }
                else // else, there are no more next phases OVERRIDE WITH BAD RECOVERY 
                // MAKE A BAD NOTE ANIMATION or something
                {

                }
            }
            
        }
    }

    // Receives which Attack Slot was called and calls the previously assigned attack
    private void Perform(int actionCalledNum)
    {

        switch (actionCalledNum)
        {
            // Attack on pos 0 REPLACE WITH NAMES
            case 0:
                actionCalledName = actionNameList_moveset[0];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 1:
                actionCalledName = actionNameList_moveset[1];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 2:
                actionCalledName = actionNameList_moveset[2];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 3:
                actionCalledName = actionNameList_moveset[3];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 4:
                actionCalledName = actionNameList_moveset[4];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 5:
                actionCalledName = actionNameList_moveset[5];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 6:
                actionCalledName = actionNameList_moveset[6];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 7:
                actionCalledName = actionNameList_moveset[7];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 8:
                actionCalledName = actionNameList_moveset[8];
                break;

            // Attack on pos 0 REPLACE WITH NAMES
            case 9:
                actionCalledName = actionNameList_moveset[9];
                break;
        }
        PhaseWatcher(actionCalledName);
        sMovesetList.ActionCall(actionCalledName, actionCalledPhase);

    }


}