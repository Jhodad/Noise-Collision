using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_HealthBar : MonoBehaviour
{

    public RawImage barRawImageEffect;

    public RawImage barRawImage;
    private Color barColor;


    private float barMaskWidth;
    public RectTransform barMaskRectTransform;
    public RectTransform edgeRectTransform;

    public Stats stats;

    private float healthPercent;

    private void Start()
    {
        //barRawImageEffect = transform.Find("Bar").GetComponent<RawImage>();
        barColor = barRawImage.color;
        barMaskWidth = barMaskRectTransform.sizeDelta.x;
        stats = GetComponentInParent<Stats>();

    }

    private void Update()
    {
        Debug.Log("Current health is: " + stats.CurrentHealthPercent() * 100 + "%");
        Rect uvRect = barRawImageEffect.uvRect;
        uvRect.x -= 0.2f * Time.deltaTime;
        barRawImageEffect.uvRect = uvRect;

        healthPercent = CheckCurrentHealthPercent();

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.x = barMaskWidth * healthPercent;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;

        edgeRectTransform.anchoredPosition = new Vector2(barMaskWidth * healthPercent,0);

        
    }

    private float CheckCurrentHealthPercent()
    {

        if (stats.CurrentHealthPercent() > 1)
        {
            Debug.Log("SI ES MAS GRANDE q 1");
            barRawImage.color = Color.red;
            // pasa algo del overflow
            edgeRectTransform.gameObject.SetActive(false);
            return 1;

        }
        else if (stats.CurrentHealthPercent() == 1)
        {
            edgeRectTransform.gameObject.SetActive(false);
            return stats.CurrentHealthPercent();
        }
        else 
        {
            edgeRectTransform.gameObject.SetActive(true);
            Debug.Log("NO ESS MAS GRANDE q 1");
            barRawImage.color = barColor;
            return stats.CurrentHealthPercent();
        }
    }
    

}