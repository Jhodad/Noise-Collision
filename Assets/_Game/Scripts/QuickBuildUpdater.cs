using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickBuildUpdater : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI onCombat;
    public TextMeshProUGUI combatCooldown;
    public TextMeshProUGUI combatRecovery;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Player>();
        Debug.Log("=======: " + player.name);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (player.anim.GetInteger("onRecovery_Elapsed") != 0)
        {
            combatRecovery.color = Color.red;

            combatCooldown.color = Color.red;
            onCombat.color = Color.red;
        }
        else
        {
            onCombat.text = player.mh.isOnCombat.ToString();
            if (player.mh.isOnCombat)
            {
                combatCooldown.color = Color.cyan;
                onCombat.color = Color.cyan;
            }
            else
            {
                combatCooldown.color = Color.green;
                onCombat.color = Color.green;
            }

            combatRecovery.color = Color.green;
        }

        
        
        combatCooldown.text = player.anim.GetInteger("combatTimeoutCurrentTime").ToString();
        combatRecovery.text =  player.anim.GetInteger("onRecovery_Elapsed").ToString();
    }

}
