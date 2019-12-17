using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_EnergyBar : MonoBehaviour
{

    public RawImage barRawImageEffect;

    public RawImage barRawImage;
    private Color barColor;


    private float barMaskWidth;
    public RectTransform barMaskRectTransform;
    public RectTransform edgeRectTransform;

    public Stats stats;

    private float energyPercent;

    private void Start()
    {
        //barRawImageEffect = transform.Find("Bar").GetComponent<RawImage>();
        barColor = barRawImage.color;
        barMaskWidth = barMaskRectTransform.sizeDelta.x;
        stats = GetComponentInParent<Stats>();

    }

    private void Update()
    {
        Debug.Log("Current energy is: " + stats.CurrentEnergyPercent() * 100 + "%");
        Rect uvRect = barRawImageEffect.uvRect;
        uvRect.x -= 0.2f * Time.deltaTime;
        barRawImageEffect.uvRect = uvRect;

        energyPercent = CheckCurrentEnergyPercent();

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.x = barMaskWidth * energyPercent;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;

        edgeRectTransform.anchoredPosition = new Vector2(barMaskWidth * energyPercent,0);

        
    }

    private float CheckCurrentEnergyPercent()
    {

        if (stats.CurrentEnergyPercent() > 1)
        {
            Debug.Log("SI ES MAS GRANDE q 1");
            barRawImage.color = Color.red;
            // pasa algo del overflow
            edgeRectTransform.gameObject.SetActive(false);
            return 1;

        }
        else if (stats.CurrentEnergyPercent() == 1)
        {
            edgeRectTransform.gameObject.SetActive(false);
            return stats.CurrentEnergyPercent();
        }
        else 
        {
            edgeRectTransform.gameObject.SetActive(true);
            Debug.Log("NO ESS MAS GRANDE q 1");
            barRawImage.color = barColor;
            return stats.CurrentEnergyPercent();
        }
    }
    

}