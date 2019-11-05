using UnityEngine;

public class AttackHandler : MonoBehaviour
{

    private AttackListGuitar attackList;
    private Stats stats;
    private PlayerController playerController;
    private Player player;

    string atkName;
    int atkPhase;
    bool canCombo;
    [SerializeField] bool canAttack;

    bool onRecovery;
    bool onAttack;

    // Start is called before the first frame update
    void Start()
    {
        attackList = GetComponent<AttackListGuitar>();
        stats = GetComponent<Stats>();
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Player>();

        atkPhase = 1;
        atkName = "No Attack";
        canAttack = true;
    }

    private void Update()
    {
        if (player.anim.GetBool("isAttackRecovering"))
        {
            player.anim.SetBool("isAttackRecovering", false);
            //Recovery();
        }

        if (!player.anim.GetBool("isAttackRecovering") && !player.IsPlayingName("AttackPhase") && !player.IsPlayingName("Recovery"))
        {
            canAttack = true;
        }
    }

    public void AttackSelector()
    {
       
    }


    public string StateWatcher(string atkCalled)
    {
        Debug.Log("--- inicia State ---");
        string currentState;
        Debug.Log("atkC" + atkCalled);
        Debug.Log("atkN" + atkName);
        Debug.Log("aqui: " + player.anim.GetBool("firstAttack"));
        if ((player.IsPlayingName("AttackPhase") || player.anim.GetBool("isAttacking"))     &&  !player.anim.GetBool("isAttackRecovering") && player.anim.GetBool("firstAttack")) // is Already attacking, so check chains to make the right follow up
        {
            
                if (atkName == atkCalled) // Next attack matches last attack, so extend 
                {
                    currentState = "Extend chain with an extender";
                }
                else // atkName =/= atkCalled, so Next attack is a new attack
                {
                    if (atkName == "No Attack") // Means this is a starter attack, 
                    {
                        currentState = "Chain Starter";
                    }
                    else
                    {
                        currentState = "Extend chain with a combo";
                    }

                }
            
        }
        else if (player.IsPlayingName("Recovery")) // isnt attacking, check if he can attack, and enable the attack state or if its recovery phase
        {
            currentState = "Is on recovery";
        }
        else{
            currentState = "Start new chain";
        }

        Debug.Log("--- fin state ---");

        return currentState;
    }



    public void Attack(string atkCalled)
    {
        Debug.Log("======================= INICIA ATTACK  =======================");
        string currentState;
        currentState = StateWatcher(atkCalled);
        Debug.Log("currentState = " + currentState + "=====================");

        if (player.isGrounded && canAttack) // Actions on the floor
        {
            switch (currentState)
            {
                case "Start new chain":
                    player.anim.SetBool("isAttacking", true);
                    player.anim.SetBool("firstAttack", true);
                    player.anim.Play("AttackPhase", 0);
                    Debug.Log("llamo al atatque");
                    Attack(atkCalled);
                    break;

                case "Chain Starter":
                    Debug.Log("Chain starter phase: " + atkPhase);
                    atkName = atkCalled;
                    attackList.AttackCall(atkName, 1);
                    break;

                case "Extend chain with an extender":   // With the same attack's next phase
                    Debug.Log("Same attack: " + atkPhase);
                    Debug.Log("same attack, atkName: " + atkName + ", atkCalled: " + atkCalled + ", phase sent: "+atkPhase);
                    canCombo = attackList.CheckPhases(atkName, atkPhase);
                    if (canCombo)// There's still more phases to the same attack
                    {
                        atkPhase = atkPhase + 1;
                        Debug.Log("after canCombo: "+atkPhase);
                        atkName = atkCalled;
                        attackList.AttackCall(atkName, atkPhase);
                    }
                    else // else theres no more phases, force a punish recovery
                    {
                        Recovery();
                    }

                    break;

                case "Extend chain with a combo":       // With a different attack
                    Debug.Log("diff: " + atkPhase);
                    Debug.Log("SON =/=, atkName: " + atkName + ", atkCalled: " + atkCalled);
                    //player.anim.Play("AttackPhase", 0);
                    atkName = atkCalled;
                    atkPhase = 1;
                    attackList.AttackCall(atkName, 1);
                    break;

                case "Is on recovery":            // Extender phase timed out, force recovery from the last attack, then resume movement
                    Recovery();
                    break;

                default: // Attack can't be performed at the time
                    break;
            }
        }
        else if(!player.isGrounded && canAttack) // Actions on the air
        {
            
            
            
        }
        Debug.Log("======================= FIN ATTACK =======================");
        

    }


    void Recovery()
    {
        Debug.Log("--- inic ia recovery ---");
        canAttack = false;
        Debug.Log("got sent to recovery");
        if (player.IsPlayingName("AttackPhase"))
        {
            player.anim.SetBool("isAttacking", false);
            player.anim.Play("Recovery", 0);
            player.anim.SetBool("isAttackRecovering", true);

            atkPhase = 1;
            atkName = "No Attack";
        }
        else
        {
            player.anim.SetBool("isAttacking", false);
            player.anim.SetBool("isAttackRecovering", true);

            atkPhase = 1;
            atkName = "No Attack";
        }
        Debug.Log("--- fin recovery ---");
        Debug.Log("recovery:  " + atkPhase);





    }


    /*


                    if (player.anim.GetInteger("attackPhase") == 1)
                    {
                        attackListGuitar.Default_Horizontal_Basic(1);
                        player.anim.SetInteger("attackPhase", (player.anim.GetInteger("attackPhase") + 1));
                    }
                    else if (player.anim.GetInteger("attackPhase") == 2)
                    {
                        attackListGuitar.Default_Horizontal_Basic(2);
                        player.anim.SetInteger("attackPhase", (player.anim.GetInteger("attackPhase") + 1));
                    }
                    else if (player.anim.GetInteger("attackPhase") == 3)
                    {
                        attackListGuitar.Default_Horizontal_Basic(3);
                        player.anim.SetInteger("attackPhase", (player.anim.GetInteger("attackPhase") + 1));
                    }
                    break;


                case "Ground Vertical":
                    if (player.anim.GetInteger("attackPhase") == 1)
                    {
                        attackListGuitar.Default_Vertical_Basic(1);
                        player.anim.SetInteger("attackPhase", (player.anim.GetInteger("attackPhase") + 1));
                    }
                    else if (player.anim.GetInteger("attackPhase") == 2)
                    {
                        attackListGuitar.Default_Vertical_Basic(2);
                        player.anim.SetInteger("attackPhase", (player.anim.GetInteger("attackPhase") + 1));
                    }
                    break;


                     */
}
