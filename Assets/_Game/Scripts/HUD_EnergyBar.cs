using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_EnergyBar : MonoBehaviour
{

    public RawImage barRawImageEffect;
    public RawImage barRawImageEdge;

    public RawImage barRawImage;
    private Color barColor;


    private float barMaskWidth;
    public RectTransform barMaskRectTransform;
    public RectTransform edgeRectTransform;

    public Stats stats;

    private float energyPercent;

    [Header("Display Texts")]
    public TextMeshProUGUI capacityMaxNumbers;
    public TextMeshProUGUI capacityCurrentNumbers;

    public TextMeshProUGUI capacityMaxPercent;
    public TextMeshProUGUI capacityCurrentPercent;

    private void Start()
    {
        //barRawImageEffect = transform.Find("Bar").GetComponent<RawImage>();
        barColor = barRawImage.color;
        barMaskWidth = barMaskRectTransform.sizeDelta.x;
        stats = GetComponentInParent<Stats>();

    }

    private void Update()
    {
        Debug.Log("Current energy is: " + stats.CurrentBatteryPercent() * 100 + "%");
        Rect uvRect = barRawImageEffect.uvRect;
        uvRect.x -= 0.2f * Time.deltaTime;
        barRawImageEffect.uvRect = uvRect;

        //Edge Effect
        Rect uvRectB = barRawImageEdge.uvRect;
        //uvRectB.x += 1f * Time.deltaTime;
        uvRectB.y -= 1f * Time.deltaTime;
        barRawImageEdge.uvRect = uvRectB;

        energyPercent = CheckCurrentEnergyPercent();

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.x = barMaskWidth * energyPercent;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;

        edgeRectTransform.anchoredPosition = new Vector2(barMaskWidth * energyPercent, 0);

        // Updates text, could be only when there are changes
        capacityCurrentNumbers.text = stats.currentBattery.ToString();
        capacityMaxNumbers.text = "/ " + stats.maxBattery.ToString();

        capacityCurrentPercent.text = (stats.CurrentBatteryPercent() * 100).ToString() + " %";
        capacityMaxPercent.text = "/ 100 %";
    }

    private float CheckCurrentEnergyPercent()
    {

        if (stats.CurrentBatteryPercent() > 1)
        {
            Debug.Log("SI ES MAS GRANDE q 1");
            barRawImage.color = Color.red;
            // pasa algo del overflow
            edgeRectTransform.gameObject.SetActive(false);
            return 1;

        }
        else if (stats.CurrentBatteryPercent() == 1)
        {
            edgeRectTransform.gameObject.SetActive(false);
            return stats.CurrentBatteryPercent();
        }
        else 
        {
            edgeRectTransform.gameObject.SetActive(true);
            Debug.Log("NO ESS MAS GRANDE q 1");
            barRawImage.color = barColor;
            return stats.CurrentBatteryPercent();
        }
    }
    

}