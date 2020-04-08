using UnityEngine;

public class Stats : MonoBehaviour
{

    [Header("Character")]
    public int characterID;

    // Events
    [Header("Events")]
    public bool isAlive;
    public bool isGrounded;
    public bool isGroundedSlope;
    public bool isFalling;

    // ====================================================================================================================== ||


    // MAX Capactiy Stats
    [Header("MAX Stats")]
    public float maxHealth;
    public float maxBattery;
    public float maxInstMeter;

    // Default Stats - Base
    [Header("Default - Base")]
    public float defaultHealth;
    public float defaultBattery;
    public float defaultInstMeter;

    public float defaultRegenHealth;
    public float defaultRegenBattery;
    public float defaultRegenInst;

    public float defaultAtk;
    public float defaultDef;
    public float defaultSpeed;
    public float defaultJump;
    public float defaultBlockResist;
    public float defaultEvadeStartup;

    [Header("Current - Base")]
    // Current Stats - Base
    public float currentHealth;
    public float currentBattery;
    public float currentInstMeter;

    public float currentRegenHealth;
    public float currentRegenBattery;
    public float currentRegenInst;

    public float currentAtk;
    public float currentDef;
    public float currentSpeed;
    public float currentJump;
    public float currentBlockResist;
    public float currentEvadeStartup;

    // Base Stats - Modifiers / Multipliers
    [Header("Base - Modifiers")]
    public float defaultModifierSpeed;
    public float defaultModifierAir;
    public float defaultModifierSpeedCombat;


    // Current Stats - Modifiers / Multipliers
    [Header("Current - Modifiers")]
    public float modifierHealth;
    public float modifierBattery;
    public float modifierInstMeter;

    public float modifierRegenHealth;
    public float modifierRegenBattery;
    public float modifierRegenInst;

    public float modifierAtk;
    public float modifierDef;
    public float modifierSpeed;
    public float modifierJump;
    public float modifierBlockResist;
    public float modifierEvadeStartup;

    public float modifierGround;
    public float modifierAir;
    public float modifierSpeedCombat;

    

    // For Direction observers
    float lastValueBattery;
    float lastValueHealth;
    float lastValueInst;

    // ====================================================================================================================== ||

    // Stat choices for level ups;
    [HideInInspector] public int baseStatSelector;
    [HideInInspector] public int secondStatSelector;

    // XP
    [Header("Levels and XP")]
    private float currentXP;    //XP carried at the moment
    private float leftoverXP;   //XP overflow after leveling up
    private float needXP;       //XP Needed for next Level up
    private float gainedXP;     //XP earned but not registered

    private float currentLevel;

    // ====================================================================================================================== ||






    // =========================================================== ||
    // =========================================================== ||
    // == Start & Update
    // =========================================================== ||
    // =========================================================== ||

    bool goingDownh;
    bool goingDowne;
    bool goingDowni;

    // Use this for initialization
    void Start()
    {

        // IF character is created for the first time
        InitializeBaseStats();

        // WHEN character is loaded from a save state        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealthPercent() >= 1)
        {
            goingDownh = true;
        }
        else if (CurrentHealthPercent() == .1f)
        {
            goingDownh = false;
        }

        if (goingDownh)
        {
            currentHealth -= 0.5f;
        }
        else
        {
            currentHealth += 0.5f;
        }

        // 2


        //3 
        if (CurrentInstrumentMeterPercent() >= 1)
        {
            goingDowni = true;
        }
        else if (CurrentInstrumentMeterPercent() == .1f)
        {
            goingDowni = false;
        }

        if (goingDowni)
        {
            currentInstMeter -= 0.5f;
        }
        else
        {
            currentInstMeter += 0.5f;
        }

        // Checks
        CheckHealth(); // Checks if player isAlive
        
        CheckBatteryDirection();
       // Debug.Log("Current battery before: " + currentBattery);
        RestoreBattery();
       // Debug.Log("Current battery after: " + currentBattery);

       // Debug.Log("Current XP: " + currentXP);
       // Debug.Log("Needed XP: " + needXP);
    }

    // ====================================================================================================================== ||






    // =========================================================== ||
    // ==  Stats on First Creation 
    // =========================================================== ||
    // =========================================================== ||
    private void InitializeBaseStats() // SHOULD LOAD FROM A SAVE STATE
    {
        // INITIAL MAX
        maxHealth = defaultHealth;
        maxBattery = defaultBattery;
        maxInstMeter = defaultInstMeter;

        // INITIAL MODIFIER
        //defaultModifierSpeed = 1;
        //defaultModifierAir = 1;


        // ---
        modifierGround = 1; //For other effects, not movement
        modifierAir = defaultModifierAir;

        modifierHealth = 1;
        modifierBattery = 1;
        modifierInstMeter = 1;

        modifierAtk = 1;
        modifierDef = 1;
        modifierSpeed = defaultModifierSpeed;
        modifierSpeedCombat = defaultModifierSpeedCombat;
        //modifierJump = 1;
        modifierBlockResist = 1;
        modifierEvadeStartup = 1;

        // INITIAL CURRENTS
        currentHealth = defaultHealth;
        currentBattery = defaultBattery;
        currentInstMeter = defaultInstMeter;

        currentRegenHealth = defaultRegenHealth;
        currentRegenBattery = defaultRegenBattery;
        currentRegenInst = defaultRegenInst;

        currentAtk = defaultAtk;
        currentDef = defaultDef;

        currentSpeed = defaultSpeed;
        currentJump = defaultJump;
        currentBlockResist = defaultBlockResist;
        currentEvadeStartup = defaultEvadeStartup;

        // XP
        currentXP = 0;
        leftoverXP = 0;
        needXP = 100;
        currentLevel = 1;

        // LAST VALUES for Directions
        lastValueBattery = maxBattery;
        lastValueHealth = maxHealth;
        lastValueInst = maxInstMeter;

    }

    // =========================================================== ||
    // =========================================================== ||
    // == Health
    // =========================================================== ||
    // =========================================================== ||

    public float CurrentHealthPercent()
    {
        float result;
        result = currentHealth / maxHealth;
        return result;
    }


    // UPDATE TO USE PERCENT!!!!!!!!!!!!
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
    // == Energy
    // =========================================================== ||
    // =========================================================== ||

    public float CurrentBatteryPercent()
    {
        float result;
        result = currentBattery / maxBattery;
        return result;
    }

    public int CheckBatteryDirection()
    {
        int result;

        if (currentBattery < lastValueBattery)
        { // Battery going down
            lastValueBattery = currentBattery;
            Debug.Log("Battery going down");
            result = -1;
        }
        else if (currentBattery > lastValueBattery)
        { // Battery going up
            lastValueBattery = currentBattery;
            Debug.Log("Battery going up");
            result = 1;
        }
        else
        { // Battery remains same
            result = 0;
           // Debug.Log("Battery same");
        }
        return result;
    }

    private void RestoreBattery()
    {
        if (currentBattery < maxBattery)
        {
            if ((currentBattery += currentRegenBattery) < maxBattery)
            {
                currentBattery += currentRegenBattery;
            }
            else
            {
                Debug.Log("I SET TO MAX");
                currentBattery = maxBattery;
                
            }
        }   
    }


    // =========================================================== ||
    // =========================================================== ||
    // == Instrument Meter
    // =========================================================== ||
    // =========================================================== ||

    public float CurrentInstrumentMeterPercent()
    {
        float result;
        result = currentInstMeter / maxInstMeter;
        return result;
    }


    // =========================================================== ||
    // =========================================================== ||
    // == Level Up & Experience Points
    // =========================================================== ||
    // =========================================================== ||

    public void AddXP(float XP)
    {
        gainedXP = XP;
        if (CheckIfLevelUp())
        {
            currentXP = currentXP + XP;
            currentXP = currentXP - needXP;
            LevelUp();

        }
        else
        {
            currentXP = currentXP + XP;
        }
    }

    private void RemoveXP()
    {

    }

    private void CalculateNextLevelXP()
    {
        needXP += 100;
    }

    private bool CheckIfLevelUp()      //Before adding gainedXP into currentXP, check if it makes the character level up
    {
        if (currentXP + gainedXP >= needXP)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void LevelUp()
    {
        Debug.Log("Subi de nivel: " + currentLevel);
        currentLevel = currentLevel + 1; //Agregar efectos despues de la suma
        CalculateNextLevelXP();
    }





}
