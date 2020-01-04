using UnityEngine;

public class Stats : MonoBehaviour {

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
    public float defaultModifierInstMeter;
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
    public float currentInstMeter;
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
    public float currentModifiereInstMeter;
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
    void Start () {

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
        if (CurrentBatteryPercent() >= 1)
        {
            goingDowne = true;
        }
        else if (CurrentBatteryPercent() == .1f)
        {
            goingDowne = false;
        }

        if (goingDowne)
        {
            currentBattery -= 0.5f;
        }
        else
        {
            currentBattery += 0.5f;
        }

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
        Debug.Log("Current XP: " + currentXP);
        Debug.Log("Needed XP: " + needXP);
    }

    // ====================================================================================================================== ||






    // =========================================================== ||
    // ==  Stats on First Creation 
    // =========================================================== ||
    // =========================================================== ||
    private void InitializeBaseStats()
    {
        maxHealth = defaultHealth;
        maxBattery = defaultBattery;
        maxInstMeter = defaultInstMeter;

        currentHealth = defaultHealth;
        currentBattery = defaultBattery;
        currentInstMeter = defaultInstMeter;

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
        currentModifiereInstMeter = defaultModifierInstMeter;

        currentModifierAtk = defaultModifierAtk;
        currentModifierDef = defaultModifierDef;
        currentModifierSpeed = defaultModifierSpeed;
        currentModifierJump = defaultModifierJump;
        currentModifierBlockResist = defaultModifierBlockResist;
        currentModifierEvadeStartup = defaultModifierEvadeStartup;

        currentXP = 0;
        leftoverXP = 0;
        needXP = 100;
        currentLevel = 1;

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
        needXP+=100;
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
        currentLevel =currentLevel + 1; //Agregar efectos despues de la suma
        CalculateNextLevelXP();
    }





}
