using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Gtr_BasicSwingHeavy : MonoBehaviour
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
        atkName = "Basic Swing Heavy";
        phases = 2;
        type = 0;
        cost = 0;

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
            switch (phaseToPlay)
            {
                case 1:
                    anim.SetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_1");
                    break;

                case 2:
                    if (player.IsPlayingName("Guit_Atk_BasicSwingHeavy(Ground)_1"))
                    {
                        anim.SetTrigger("Guit_Atk_BasicSwingHeavy(Ground)_2");
                    }

                    break;
            }
        }
        else    // Air
        {
        }
    }

}
