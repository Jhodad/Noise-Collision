using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour {

    public Texture icon;
    public int itemType;
    public string itemName;

    public GameObject descripObject;
    public GameObject flavorObject;

    private TextMeshProUGUI descriptionText;
    private TextMeshProUGUI flavorText;

    public string description;
    public string flavor;

    /*  RARITIES
    public int rarity1 = 1;
    public int rarity2 = 2;
    public int rarity3 = 3;
    public int rarity4 = 4;
    public int rarity5 = 5;
    public int rarity6 = 6;
    */

    public int rarity;

    // Use this for initialization
    void Start () {

        itemType = itemType + 1;

        descriptionText = descripObject.GetComponent<TextMeshProUGUI>();
        flavorText = flavorObject.GetComponent<TextMeshProUGUI>();

        description = descriptionText.text;
        flavor = flavorText.text;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
