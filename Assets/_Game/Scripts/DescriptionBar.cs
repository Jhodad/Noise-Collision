using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DescriptionBar : MonoBehaviour {

    public GameObject textTitle;
    public GameObject textItemName;
    public GameObject iconIcon;
    public GameObject textDescription;
    public GameObject textFlavor;
    [HideInInspector] public Color defaultColor;

    private TextMeshProUGUI textNameUpdated;
    private TextMeshProUGUI textDescriptionUpdated;
    private TextMeshProUGUI textFlavorUpdated;

    private Slot slotHovered;

    [HideInInspector] public Texture hoveredIcon;

    [HideInInspector] public string hoveredName;

    [HideInInspector] public string itemDescription;
    [HideInInspector] public string itemFlavor;

    // Use this for initialization
    void Start () {
        textNameUpdated = textItemName.GetComponent<TextMeshProUGUI>();
        textDescriptionUpdated = textDescription.GetComponent<TextMeshProUGUI>();
        textFlavorUpdated = textFlavor.GetComponent<TextMeshProUGUI>();
        defaultColor = iconIcon.GetComponent<RawImage>().color;
    }
	
	// Update is called once per frame
	void Update () {
        textNameUpdated.SetText(hoveredName);
        textDescriptionUpdated.SetText(itemDescription);
        textFlavorUpdated.SetText(itemFlavor);

        iconIcon.GetComponent<RawImage>().texture = hoveredIcon;
    }

    void updateIcon()
    {
        
    }
}
