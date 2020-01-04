using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD_InstrumentBar : MonoBehaviour
{

    public RawImage barRawImageEffect;
    public RawImage barRawImageEdge;
    public RawImage barRawImageEdge2;

    public RawImage barRawImage;
    private Color barColor;


    private float barMaskWidth;
    public RectTransform barMaskRectTransform;
    public RectTransform edgeRectTransform;

    public Stats stats;

    private float instMeterPercent;

    private void Start()
    {
        //barRawImageEffect = transform.Find("Bar").GetComponent<RawImage>();
        barColor = barRawImage.color;
        barMaskWidth = barMaskRectTransform.sizeDelta.y;
        stats = GetComponentInParent<Stats>();

    }

    private void Update()
    {
        Debug.Log("Current instrument meter is: " + stats.CurrentHealthPercent() * 100 + "%");
        Rect uvRect = barRawImageEffect.uvRect;
        uvRect.x -= 0.02f * Time.deltaTime;
        barRawImageEffect.uvRect = uvRect;

        //Edge Effect
        Rect uvRectB = barRawImageEdge.uvRect;
        uvRectB.x -= 1f * Time.deltaTime;
        //uvRectB.y += 1f * Time.deltaTime;
        barRawImageEdge.uvRect = uvRectB;

        Rect uvRectB2 = barRawImageEdge2.uvRect;
        //uvRectB2.x += 1f * Time.deltaTime;
        uvRectB2.y += 1f * Time.deltaTime;
        barRawImageEdge2.uvRect = uvRectB2;

        instMeterPercent = CheckCurrentInstrumentMeterPercent();

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.y = barMaskWidth * instMeterPercent;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;

        edgeRectTransform.anchoredPosition = new Vector2(0, barMaskWidth * instMeterPercent);

       

        
    }

    private float CheckCurrentInstrumentMeterPercent()
    {

        if (stats.CurrentInstrumentMeterPercent() > 1)
        {
            Debug.Log("SI ES MAS GRANDE q 1");
            barRawImage.color = Color.red;
            // pasa algo del overflow
            edgeRectTransform.gameObject.SetActive(false);
            return 1;

        }
        else if (stats.CurrentInstrumentMeterPercent() == 1)
        {
            edgeRectTransform.gameObject.SetActive(false);
            return stats.CurrentInstrumentMeterPercent();
        }
        else 
        {
            edgeRectTransform.gameObject.SetActive(true);
            Debug.Log("NO ESS MAS GRANDE q 1");
            barRawImage.color = barColor;
            return stats.CurrentInstrumentMeterPercent();
        }
    }
    

}