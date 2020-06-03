using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Gtr_PullOff : MonoBehaviour
{
    [HideInInspector] public string atkName;
    [HideInInspector] public int phases;
    [HideInInspector] public int type;


    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        atkName = "Pull Off";
        phases = 1;
        type = 1;

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
            anim.SetTrigger("Guit_Atk_PullOff(Ground)");
        }
        else    // Air
        {

        }
    }

}
