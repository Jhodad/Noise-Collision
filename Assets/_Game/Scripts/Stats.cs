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



    // Use this for initialization
    void Start () {

        // IF character is created for the first time
        InitializeBaseStats();

        // WHEN character is loaded from a save state        
	}

    // Update is called once per frame
    void Update()
    {

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
