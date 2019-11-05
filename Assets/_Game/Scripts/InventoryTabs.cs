using UnityEngine;
using UnityEngine.UI;

public class InventoryTabs : MonoBehaviour
{
    public GameObject inventory;
    public bool inventoryEnabled;
    private int tabCounter = 1;

    private GameObject[] inventoryTabList;
    private int maxTabs = 8;

    // Tabs
    public GameObject tabConsumables;
    public GameObject tabEquipment;
    public GameObject tabElemental;
    public GameObject tabResources;
    public GameObject tabBlueprints;
    public GameObject tabSongBook;
    public GameObject tabSoundPacks;
    public GameObject tabCollectibles;

    // Holders
    public GameObject holderConsumables;
    public GameObject holderEquipment;
    public GameObject holderElemental;
    public GameObject holderResources;
    public GameObject holderBlueprints;
    public GameObject holderSongBook;
    public GameObject holderSoundPacks;
    public GameObject holderCollectibles;

    // List of slot holders from each tab
    private GameObject[] slotHolderList;

    // Default capacity for each slot
    private int currentSlotsConsumables = 10;
    private int currentSlotsEquipment = 5;
    private int currentSlotsElemental = 5;
    private int currentSlotsResources = 15;
    private int currentSlotsBlueprints = 10;
    private int currentSlotsSongBook = 10;
    private int currentSlotsSoundPacks = 5;
    private int currentSlotsCollectibles = 20;

    // maxSlotsName = max possible slots
    private int maxSlotsConsumables = 20;
    private int maxSlotsEquipment = 20;
    private int maxSlotsElemental = 20;
    private int maxSlotsResources = 20;
    private int maxSlotsBlueprints = 20;
    private int maxSlotsSongBook = 20;
    private int maxSlotsSoundPacks = 20;
    private int maxSlotsCollectibles = 20;

    // maxSlotGeneral is the number of slots that exist, regardles of how many are usable
    private int maxSlotsGeneral = 20;
    // Number that modifies the current available spaces on a specific slot, it adds capacityModifier to currentCapacity
    [HideInInspector] public int capacityModifier = 0;
    // Bolean that enables using the modifier above
    private bool slotExpanderUsed;

    // Slots, contains all slots on a holder, regardless of how many are usable
    private Transform[] slotConsumables;
    private Transform[] slotEquipment;
    private Transform[] slotElemental;
    private Transform[] slotResources;
    private Transform[] slotBlueprints;
    private Transform[] slotSongBook;
    private Transform[] slotSoundPacks;
    private Transform[] slotCollectibles;

    // Slots, contains only the usable slots on a holder
    private Transform[] slotConsumablesAvailable;
    private Transform[] slotEquipmentAvailable;
    private Transform[] slotElementalAvailable;
    private Transform[] slotResourcesAvailable;
    private Transform[] slotBlueprintsAvailable;
    private Transform[] slotSongBookAvailable;
    private Transform[] slotSoundPacksAvailable;
    private Transform[] slotCollectiblesAvailable;

    // Items
    [HideInInspector] public GameObject itemPickedUp;
    [HideInInspector] public string flavorText;
    [HideInInspector] public string descripText;

    private bool itemAdded = false;
    private int itemType; // Uses numbers that = tabs


    // ====================================================================== //
    // ===================================================================== //
    // ==================================================================== //
    // ========================= Start & Updates ========================= //

    void Start()
    {
        inventoryEnabled = false;
        inventoryTabList = new GameObject[maxTabs];
        slotHolderList = new GameObject[maxTabs];

        inventoryTabList[0] = tabConsumables;
        slotHolderList[0] = holderConsumables;
        slotConsumables = new Transform[maxSlotsConsumables];
        slotConsumablesAvailable = new Transform[maxSlotsConsumables];

        inventoryTabList[1] = tabEquipment;
        slotHolderList[1] = holderEquipment;
        slotEquipment = new Transform[maxSlotsEquipment];
        slotEquipmentAvailable = new Transform[maxSlotsEquipment];

        inventoryTabList[2] = tabElemental;
        slotHolderList[2] = holderElemental;
        slotElemental = new Transform[maxSlotsElemental];
        slotElementalAvailable = new Transform[maxSlotsElemental];

        inventoryTabList[3] = tabResources;
        slotHolderList[3] = holderResources;
        slotResources = new Transform[maxSlotsResources];
        slotResourcesAvailable = new Transform[maxSlotsResources];

        inventoryTabList[4] = tabBlueprints;
        slotHolderList[4] = holderBlueprints;
        slotBlueprints = new Transform[maxSlotsBlueprints];
        slotBlueprintsAvailable = new Transform[maxSlotsBlueprints];

        inventoryTabList[5] = tabSongBook;
        slotHolderList[5] = holderSongBook;
        slotSongBook = new Transform[maxSlotsSongBook];
        slotSongBookAvailable = new Transform[maxSlotsSongBook];

        inventoryTabList[6] = tabSoundPacks;
        slotHolderList[6] = holderSoundPacks;
        slotSoundPacks = new Transform[maxSlotsSoundPacks];
        slotSoundPacksAvailable = new Transform[maxSlotsSoundPacks];

        inventoryTabList[7] = tabCollectibles;
        slotHolderList[7] = holderCollectibles;
        slotCollectibles = new Transform[maxSlotsCollectibles];
        slotCollectiblesAvailable = new Transform[maxSlotsCollectibles];

        // Turn all slots to black because they are disabled
        slotMaxCounter(); 
        // Turns available slots to white
        for (int i = 1; i <= maxTabs; i++)
        {
            slotCapacityHandler(i, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("aprete I hguehue");
            inventoryEnabled = !inventoryEnabled;
            InventoryED();
        }

        if (Input.GetKeyDown(KeyCode.O) && inventoryEnabled)
        {
            Debug.Log("aprete O hguehue");
            InventoryTabSwitcher();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            slotCapacityHandler(1, capacityModifier + 1);
            slotCapacityHandler(2, capacityModifier + 1);
            slotCapacityHandler(3, capacityModifier + 1);
        }




    }
    // =========================================================================== //
    // ========================= Inventory Menus & Tabs ========================= //
    // ========================================================================= //

    public void InventoryED() // Inventory Enable / Disable
    {
        if (inventoryEnabled)
        {
            inventory.SetActive(true); // Turn on inventory holder
            for (int i = 0; i < inventoryTabList.Length; i++)
            {
                inventoryTabList[i].SetActive(false); // Turn off al tabs to open the menu cleanly
            }
            inventoryTabList[0].SetActive(true); // Turn on default Tab
        }
        else
        {
            inventory.SetActive(false);
            tabCounter = 1;
        }
    }

    // ---

    public void InventoryTabSwitcher() // Switch throughout all tabs in the inventory
    {
        if (tabCounter == maxTabs)
        {
            inventoryTabList[tabCounter - 1].SetActive(false);
            tabCounter = 1;
            inventoryTabList[0].SetActive(true);
        }
        else
        {
            inventoryTabList[tabCounter - 1].SetActive(false);
            inventoryTabList[tabCounter].SetActive(true);
            tabCounter++;
        }
    }
    // ================================================================================ //
    // ========================= Slot holders and capacities ========================= //
    // ============================================================================== //

    // PUEDES USAR EL SWITCH PARA REDUCIR CODIGO 
    public void slotMaxCounter() // Creates max capacity list of slots, regardless of avaiable ones
    {
        for (int i = 0; i < maxSlotsGeneral; i++)
        {
            slotConsumables[i] = holderConsumables.transform.GetChild(i);
            slotConsumables[i].GetComponent<RawImage>().enabled = false;
            //slotConsumables[i].GetComponent<RawImage>().color = Color.black;
            //Debug.Log("I = " + i + " This is slot Consumable: " + slotConsumables[i].name);

            slotEquipment[i] = holderEquipment.transform.GetChild(i);
            slotEquipment[i].GetComponent<RawImage>().enabled = false;

            slotElemental[i] = holderElemental.transform.GetChild(i);
            //slotElemental[i].GetComponent<RawImage>().color = Color.black;
            slotElemental[i].GetComponent<RawImage>().enabled = false;

            slotResources[i] = holderResources.transform.GetChild(i);
            //slotResources[i].GetComponent<RawImage>().color = Color.black;
            slotResources[i].GetComponent<RawImage>().enabled = false;

            slotSongBook[i] = holderSongBook.transform.GetChild(i);
            //slotsongBook[i].GetComponent<RawImage>().color = Color.black;
            slotSongBook[i].GetComponent<RawImage>().enabled = false;

            slotBlueprints[i] = holderBlueprints.transform.GetChild(i);
            //slotBlueprints[i].GetComponent<RawImage>().color = Color.black;
            slotBlueprints[i].GetComponent<RawImage>().enabled = false;

            slotSoundPacks[i] = holderSoundPacks.transform.GetChild(i);
            //slotSoundPacks[i].GetComponent<RawImage>().color = Color.black;
            slotSoundPacks[i].GetComponent<RawImage>().enabled = false;

            slotCollectibles[i] = holderCollectibles.transform.GetChild(i);
            //slotCollectibles[i].GetComponent<RawImage>().color = Color.black;
            slotSoundPacks[i].GetComponent<RawImage>().enabled = false;
        }
    }

    // ---

    void slotCapacityHandler(int tabHolderIndex, int modifier) // Creates list of slots available for use and modifies that list with a number to increase the available slots
    {
        switch (tabHolderIndex)
        {
            case 8: // Collectibles
                currentSlotsCollectibles = currentSlotsCollectibles + modifier;
                for (int i = 0; i < currentSlotsCollectibles; i++)
                {
                    slotCollectiblesAvailable[i] = holderCollectibles.transform.GetChild(i);
                    slotCollectiblesAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotCollectiblesAvailable[i].GetComponent<RawImage>().color = Color.cyan;
                }
                break;
            case 7: // SoundPacks
                currentSlotsSoundPacks = currentSlotsSoundPacks + modifier;
                for (int i = 0; i < currentSlotsSoundPacks; i++)
                {
                    slotSoundPacksAvailable[i] = holderSoundPacks.transform.GetChild(i);
                    slotSoundPacksAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotSoundPacksAvailable[i].GetComponent<RawImage>().color = Color.white;
                }
                break;
            case 6: // songBook
                currentSlotsSongBook = currentSlotsSongBook + modifier;
                for (int i = 0; i < currentSlotsSongBook; i++)
                {
                    slotSongBookAvailable[i] = holderSongBook.transform.GetChild(i);
                    slotSongBookAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotsongBookAvailable[i].GetComponent<RawImage>().color = Color.white;
                }

                break;
            case 5: // Blueprints
                currentSlotsBlueprints = currentSlotsBlueprints + modifier;
                for (int i = 0; i < currentSlotsBlueprints; i++)
                {
                    slotBlueprintsAvailable[i] = holderBlueprints.transform.GetChild(i);
                    slotBlueprintsAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotBlueprintsAvailable[i].GetComponent<RawImage>().color = Color.white;
                }
                break;
            case 4: // Resources
                currentSlotsResources = currentSlotsResources + modifier;
                for (int i = 0; i < currentSlotsResources; i++)
                {
                    slotResourcesAvailable[i] = holderResources.transform.GetChild(i);
                    slotResourcesAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotResourcesAvailable[i].GetComponent<RawImage>().color = Color.white;
                }
                break;
            case 3: // Elemental
                currentSlotsElemental = currentSlotsElemental + modifier;
                for (int i = 0; i < currentSlotsElemental; i++)
                {
                    slotElementalAvailable[i] = holderElemental.transform.GetChild(i);
                    slotElementalAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotElementalAvailable[i].GetComponent<RawImage>().color = Color.white;
                }
                break;
            case 2: // Equipment
                currentSlotsEquipment = currentSlotsEquipment + modifier;
                for (int i = 0; i < currentSlotsEquipment; i++)
                {
                    slotEquipmentAvailable[i] = holderEquipment.transform.GetChild(i);
                    slotEquipmentAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotEquipmentAvailable[i].GetComponent<RawImage>().color = Color.white;
                }
                break;
            case 1: // Consumables
                currentSlotsConsumables = currentSlotsConsumables + modifier;
                for (int i = 0; i < currentSlotsConsumables; i++)
                {
                    slotConsumablesAvailable[i] = holderConsumables.transform.GetChild(i);
                    slotConsumablesAvailable[i].GetComponent<RawImage>().enabled = true;
                    //slotConsumablesAvailable[i].GetComponent<RawImage>().color = Color.white;
                    //Debug.Log(slotConsumablesAvailable[i].GetComponent<Slot>().empty.ToString());
                    //Debug.Log(slotConsumablesAvailable[i].name);
                }
                break;
            default: // Out of boundaries Index
                break;
        }
    }

    // ---

    // OUTDATED - This detects all slots into one big array, it's only useful if you intend of having all inventory tabs use the same amount of spaces
    /*
    public void DetectInventorySlots()
    {
        for (int j = 0; j < slotHolderList.Length; j++)
        {
            for (int i = 0; i < maxSlots; i++)
            {
                slot[i] = slotHolderList[j].transform.GetChild(i);
                Debug.Log("I = " + i +" This is slot: " + slot[i].name);
            }
            Debug.Log("--------- J changed, using new holder ----------- J = " + j);
        }
    }
    */
       
    // ======================================================================= //
    // ========================= Item Functionality ========================= //
    // ===================================================================== //

    public void AddItem(GameObject item, int itemType)
    {
        Debug.Log("I picked item: " + item.name + ", with type: " +  itemType);
    switch (itemType)
    {
        case 8: // Collectibles
                for (int i = 0; i < currentSlotsCollectibles; i++)
                {
                    if (slotCollectiblesAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotCollectiblesAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotCollectiblesAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        //slotCollectiblesAvailable[i].GetComponent<RawImage>().color = Color.white;
                        itemAdded = true;
                    }
                }
                break;
        case 7: // SoundPacks
                for (int i = 0; i < currentSlotsSoundPacks; i++)
                {
                    if (slotSoundPacksAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotSoundPacksAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotSoundPacksAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        itemAdded = true;
                    }
                }
                break;
        case 6: // songBook
                for (int i = 0; i < currentSlotsSongBook; i++)
                {
                    if (slotSongBookAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotSongBookAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotSongBookAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        itemAdded = true;
                    }
                }
                break;
        case 5: // Blueprints
                for (int i = 0; i < currentSlotsBlueprints; i++)
                {
                    if (slotBlueprintsAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotBlueprintsAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotBlueprintsAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        itemAdded = true;
                    }
                }
                break;
        case 4: // Resources
                for (int i = 0; i < currentSlotsResources; i++)
                {
                    if (slotResourcesAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotResourcesAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotResourcesAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        itemAdded = true;
                    }
                }
                break;
        case 3: // Elemental
                for (int i = 0; i < currentSlotsElemental; i++)
                {
                    if (slotElementalAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotElementalAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotElementalAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        itemAdded = true;
                    }
                }
                break;
        case 2: // Equipment
                for (int i = 0; i < currentSlotsEquipment; i++)
                {
                    if (slotEquipmentAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotEquipmentAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotEquipmentAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        //slotEquipmentAvailable[i].GetComponent<RawImage>().color = Color.white;
                        itemAdded = true;
                    }
                }
                break;
        case 1: // Consumables
                for (int i = 0; i < currentSlotsConsumables; i++)
                {
                    if (slotConsumablesAvailable[i].GetComponent<Slot>().empty && itemAdded == false)
                    {
                        slotConsumablesAvailable[i].GetComponent<Slot>().item = itemPickedUp;
                        slotConsumablesAvailable[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                        //slotConsumablesAvailable[i].GetComponent<RawImage>().color = Color.white;
                        itemAdded = true;
                    }
                }
                break;
        default: // Out of boundaries Index
            break;
    }
}

    // ================================================================ //
    // ========================= On Triggers ========================= //
    // ============================================================== //

    public void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.tag == "item")
        {
            itemAdded = false;
        }
        else
        {
        }

    }
    
    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.GetComponent<Item>())
        {
            itemPickedUp = other.gameObject;
            descripText = other.gameObject.GetComponentInChildren<Item>().description;
            flavorText = other.gameObject.GetComponentInChildren<Item>().flavor;

            itemType = itemPickedUp.GetComponent<Item>().itemType;

            AddItem(itemPickedUp, itemType);
            
        }
    }
    



}

