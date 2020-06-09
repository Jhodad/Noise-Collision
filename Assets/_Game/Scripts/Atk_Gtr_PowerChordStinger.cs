using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Gtr_PowerChordStinger : MonoBehaviour
{
    [HideInInspector] public string atkName;
    [HideInInspector] public int phases;
    [HideInInspector] public int type;
    public float damage;
    public float cost;

    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        atkName = "Power Chord Stinger";
        phases = 1;
        type = 1;
        cost = 40;

        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Perform(int phaseToPlay, bool state)
    {
        if (state) // Ground
        {
            if (player.stats.CanUseBattery(cost))
            {
                player.stats.UseBattery(cost);
                anim.SetTrigger("Guit_Atk_PowerChordStinger(Ground)");
            }
            else
            {
                Debug.Log("No more battery");
            }
            
        }
        else    // Air
        {

        }
    }

}
