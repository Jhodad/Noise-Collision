using UnityEngine;

public class Stats : MonoBehaviour {

    [Header("Character")]
    public int characterID;

    // Events
    [Header("Events")]
    public bool isAlive;
    public bool isGrounded;
    public bool isGroundedSlope;

    // ====================================================================================================================== ||

    // Default Stats - Base
    [Header("Default - Base")]
    public float defaultHealth;
    public float defaultBattery;
    public float defaultAtk;
    public float defaultDef;
    public float defaultSpeed;
    public float defaultJump;
    public float defaultBlockResist;
    public float defaultEvadeStartup;

    // Default Stats - Modifiers / Multipliers
    [Header("Default - Modifiers")]
    public float defaultModifierHealth;
    public float defaultModifierBattery;
    public float defaultModifierAtk;
    public float defaultModifierDef;
    public float defaultModifierSpeed;
    public float defaultModifierJump;
    public float defaultModifierBlockResist;
    public float defaultModifierEvadeStartup;
    
    public float defaultModifierAir;
    public float defaultModifierGround;

    [Header("Current - Base")]
    // Current Stats - Base
    public float currentHealth;
    public float currentBattery;
    public float currentAtk;
    public float currentDef;
    public float currentSpeed;
    public float currentJump;
    public float currentBlockResist;
    public float currentEvadeStartup;

    // Current Stats - Modifiers / Multipliers
    [Header("Current - Modifiers")]
    public float currentModifierHealth;
    public float currentModifierBattery;
    public float currentModifierAtk;
    public float currentModifierDef;
    public float currentModifierSpeed;
    public float currentModifierJump;
    public float currentModifierBlockResist;
    public float currentModifierEvadeStartup;

    public float currentModifierGround;
    public float currentModifierAir;

    // ====================================================================================================================== ||



    // Stat choices for level ups;

    [HideInInspector] public int baseStatSelector;
    [HideInInspector] public int secondStatSelector;

    // XP
    [Header("Levels and XP")]
    public float nextLevelXP;

    [HideInInspector] private float currentXP;
    // [HideInInspector] Hide nextLevelXP when done testing
    [HideInInspector] private float currentLevelUpPoints;
    [HideInInspector] private float currentLevel;

    // Unique Effects
    private float[] uniqueEffects;
    private int uniqueEffectsMaxCapacity;
    private int uniqueEffectsCurrentCapacity;

    private float p1e1;
    private float p1e2;
    private float p1e3;
    private float p1e4;
    private float p1e5;
    private float p1e6;
    private float p1e7;
    private float p1e8;
    private float p1e9;
    private float p1e10;

    private float p2e1;
    private float p2e2;
    private float p2e3;
    private float p2e4;
    private float p2e5;
    private float p2e6;
    private float p2e7;
    private float p2e8;
    private float p2e9;
    private float p2e10;

    private float p3e1;
    private float p3e2;
    private float p3e3;
    private float p3e4;
    private float p3e5;
    private float p3e6;
    private float p3e7;
    private float p3e8;
    private float p3e9;
    private float p3e10;

    private float p4e1;
    private float p4e2;
    private float p4e3;
    private float p4e4;
    private float p4e5;
    private float p4e6;
    private float p4e7;
    private float p4e8;
    private float p4e9;
    private float p4e10;

    private float p5e1;
    private float p5e2;
    private float p5e3;
    private float p5e4;
    private float p5e5;
    private float p5e6;
    private float p5e7;
    private float p5e8;
    private float p5e9;
    private float p5e10;


    // ====================================================================================================================== ||

    // =========================================================== ||
    // =========================================================== ||
    // == Start & Update
    // =========================================================== ||
    // =========================================================== ||

    // Use this for initialization
    void Start () {

        // IF character is created for the first time
        InitializeBaseStats();

        // WHEN character is loaded from a save state


        // Move stuff to where they belong
        uniqueEffectsMaxCapacity = 10;
        uniqueEffectsCurrentCapacity = 4;
        currentLevelUpPoints = 0;
        currentLevel = 0;
        uniqueEffects = new float[uniqueEffectsMaxCapacity];

     
        
	}
	
	// Update is called once per frame
	void Update () {

        // Checks
        CheckHealth();

        // Check for level ups - FIX
        if (currentXP >= nextLevelXP)
        {
            levelUp(baseStatSelector, secondStatSelector);
        }
    }

    // ====================================================================================================================== ||






    // =========================================================== ||
    // ==  Stats on First Creation 
    // =========================================================== ||
    // =========================================================== ||
    private void InitializeBaseStats()
    {
        currentHealth = defaultHealth;
        currentBattery = defaultBattery;
            
        currentAtk = defaultAtk;
        currentDef = defaultDef;
        currentSpeed = defaultSpeed;
        currentJump = defaultJump;
        currentBlockResist = defaultBlockResist;
        currentEvadeStartup = defaultEvadeStartup;

        currentModifierGround = defaultModifierGround;
        currentModifierAir = defaultModifierAir;

        currentModifierHealth = defaultModifierHealth;
        currentModifierBattery = defaultModifierBattery;
        currentModifierAtk = defaultModifierAtk;
        currentModifierDef = defaultModifierDef;
        currentModifierSpeed = defaultModifierSpeed;
        currentModifierJump = defaultModifierJump;
        currentModifierBlockResist = defaultModifierBlockResist;
        currentModifierEvadeStartup = defaultModifierEvadeStartup;
}

// =========================================================== ||
// =========================================================== ||
// == Health
// =========================================================== ||
// =========================================================== ||

private bool CheckHealth()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        return isAlive;
    }




    // =========================================================== ||
    // =========================================================== ||
    // == Level Up
    // =========================================================== ||
    // =========================================================== ||
    private void levelUp(int baseStatDecision, int ifDefChoiceThenResistance)
    {
        Debug.Log(this.name + " has leveled up!");

        currentXP = currentXP - nextLevelXP; // Leave CurrentXP at 0 to start the new level

        nextLevelXP = (nextLevelXP * 0.2f) + nextLevelXP;

        currentLevelUpPoints = currentLevelUpPoints + 1;

        switch (baseStatDecision)
        {
            case 1: // Health Upgrade
                currentHealth = currentHealth + currentModifierHealth;
                break;

            case 2: // ATK Upgrade
                currentAtk = currentAtk + currentModifierAtk;
                break;

            case 3: // DEF Upgrade
                currentDef = currentDef + currentModifierDef;
                switch (ifDefChoiceThenResistance)
                {
                    case 1: // Resistance 1

                        break;

                    case 2: // Resistance 2

                        break;

                    default: // Random resistance option?
                        break;
                }
                break;

            case 4: // Speed Upgrade
                currentSpeed = currentSpeed + currentModifierSpeed;
                break;

            case 5: // Battery Upgrade
                currentBattery = currentBattery + currentModifierBattery;
                break;

            case 6: // Block Upgrade

                break;

            case 7: // Evade Upgrade

                break;

            case 8: // Evade Upgrade

                break;

            case 9: // Evade Upgrade

                break;

            case 10: // Evade Upgrade

                break;

            default:

                break;
        }
    }

    private void uniqueEffectsSelector(float positionOfEffectToChange)
    {
        // Need to add an onClick selector that choose which effect wants to be rolled for a new one
        switch ((int) positionOfEffectToChange)
        {
            case 1: // Pool 1
               
                break;

            case 2: // Pool 2
               
                break;

            case 3: // Pool 3

                break;

            case 4: // Pool 4

                break;

            case 5: // Pool 5

                break;

            case 6: // Pool 6

                break;

            case 7: // Pool 7

                break;

            case 8: // Pool 8

                break;

            case 9: // Pool 9

                break;

            case 10: // Pool 10

                break;

            default: // Random one?
                positionOfEffectToChange = Random.value * 10;
                uniqueEffectsSelector(positionOfEffectToChange);
                break;
        }
    }





}
