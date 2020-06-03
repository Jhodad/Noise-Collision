using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Gtr_BasicSwing : MonoBehaviour
{
    [HideInInspector] public string atkName;
    [HideInInspector] public int phases;
    [HideInInspector] public int type;

    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        atkName = "Basic Swing";
        phases = 3;
        type = 0;

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
                    anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_1");
                    break;

                case 2:
                    if (player.IsPlayingName("Guit_Atk_BasicSwing(Ground)_1"))
                    {
                        anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_2");
                    }
                    break;

                case 3:
                    if (player.IsPlayingName("Guit_Atk_BasicSwing(Ground)_2"))
                    {
                        anim.SetTrigger("Guit_Atk_BasicSwing(Ground)_3");
                    }
                    break;
            }
        }
        else    // Air
        {
            Debug.Log("Thiss attack doesnt have air anims");
        }
    }
}
