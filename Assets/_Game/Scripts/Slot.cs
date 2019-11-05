using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

    private bool hovered;
    public bool empty;

    private GameObject theItemPickedUp;
    [HideInInspector] public GameObject item;
    private GameObject player;

    [HideInInspector] public DescriptionBar descripBar;
    [HideInInspector] public InventoryTabs invTab;


    [HideInInspector] public string flavorText;
    [HideInInspector] public string descripText;

    [HideInInspector] public Texture itemIcon;

    [HideInInspector] public string itemName;
    
    

    // Use this for initialization
    void Start () {
        //player = GameObject.FindWithTag("Player");
        player = transform.parent.transform.parent.transform.parent.transform.parent.gameObject;
        descripBar = transform.parent.transform.parent.gameObject.GetComponentInChildren<DescriptionBar>();
        invTab = transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<InventoryTabs>();
        Debug.Log(player.name);
        Debug.Log(descripBar.name);
        Debug.Log(invTab.name);
        hovered = false;
        empty = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (item)
        {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<RawImage>().texture = itemIcon;
            this.GetComponent<RawImage>().color = Color.white;
            itemName = item.GetComponent<Item>().itemName;
        }
        else
        {
            empty = true;
        }
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        descripText = invTab.descripText;
        flavorText = invTab.flavorText;

        hovered = true;
        if (empty)
        {
            //Debug.Log("----- Slot: " + name + " is empty!");
            descripBar.itemDescription = "Description text is empty";
            descripBar.itemFlavor = "Flavor text is empty";
            descripBar.hoveredName = "No Name";
            descripBar.hoveredIcon = null;
            descripBar.iconIcon.GetComponent<RawImage>().color = descripBar.defaultColor;
        }
        else if (this.isActiveAndEnabled )
        {
            //Debug.Log("Slot: " + name + ", contains: " + itemName);
            descripBar.itemDescription = descripText;
            descripBar.itemFlavor = flavorText;
            descripBar.hoveredName = itemName;
            descripBar.iconIcon.GetComponent<RawImage>().color = Color.white;
            descripBar.hoveredIcon = itemIcon;

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void onPointerClick(PointerEventData eventData)
    {
        if (item)
        {
            //Item thisItem = item.GetComponent<Item>();

            // checking for item type

            //if (thisItem.type == "Water"){}
            

            
        }
    }

}
