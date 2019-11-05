using UnityEngine;

public class Stats : MonoBehaviour {

    public int characterID;

    // Modifiers
    [HideInInspector] public float modifierHealth;
    [HideInInspector] public float modifierBattery;
    [HideInInspector] public float modifierAtk;
    [HideInInspector] public float modifierDef;
                      public float modifierSpeed;
                      public float modifierJump;
    [HideInInspector] public float modifierBlockResist;
    [HideInInspector] public float modifierEvadeStartup;

    // Current Stats
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentBattery;
    [HideInInspector] public float currentAtk;
    [HideInInspector] public float currentDef;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float currentJump;
    [HideInInspector] public float currentBlockResist;
    [HideInInspector] public float currentEvadeStartup;

    // Default Stats, for resets and stuff
    public float defaultHealth;
    public float defaultBattery;
    public float defaultAtk;
    public float defaultDef;
    public float defaultSpeed;
    public float defaultJump;
    public float defaultBlockResist;
    public float defaultEvadeStartup;
    public float defaultAirModifierGround;
    public float defaultAirModifierAir;

    // Stat choices for level ups;

    [HideInInspector] public int baseStatSelector;
    [HideInInspector] public int secondStatSelector;

    // XP

    [HideInInspector] private float currentXP;
    // [HideInInspector] Hide nextLevelXP when done testing
    public float nextLevelXP;
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


    // =============================================================================== //
    // =============================== Start & Update =============================== //
    // ============================================================================= //
    // ============================================================================ //

    // Use this for initialization
    void Start () {

        uniqueEffectsMaxCapacity = 10;
        uniqueEffectsCurrentCapacity = 4;
        currentLevelUpPoints = 0;
        currentLevel = 0;
        uniqueEffects = new float[uniqueEffectsMaxCapacity];

        currentHealth = defaultHealth;
        
	}
	
	// Update is called once per frame
	void Update () {
        // Check for level ups
        if (currentXP >= nextLevelXP)
        {
            levelUp(baseStatSelector, secondStatSelector);
        }
    }

    // =============================================================================== //
    // ============================= Leveling Up and XP ============================= //
    // ============================================================================= //
    // ============================================================================ //

    private void levelUp(int baseStatDecision, int ifDefChoiceThenResistance)
    {
        Debug.Log(this.name + " has leveled up!");

        currentXP = currentXP - nextLevelXP; // Leave CurrentXP at 0 to start the new level

        nextLevelXP = (nextLevelXP * 0.2f) + nextLevelXP;

        currentLevelUpPoints = currentLevelUpPoints + 1;

        switch (baseStatDecision)
        {
            case 1: // Health Upgrade
                currentHealth = currentHealth + modifierHealth;
                break;

            case 2: // ATK Upgrade
                currentAtk = currentAtk + modifierAtk;
                break;

            case 3: // DEF Upgrade
                currentDef = currentDef + modifierDef;
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
                currentSpeed = currentSpeed + modifierSpeed;
                break;

            case 5: // Battery Upgrade
                currentBattery = currentBattery + modifierBattery;
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
