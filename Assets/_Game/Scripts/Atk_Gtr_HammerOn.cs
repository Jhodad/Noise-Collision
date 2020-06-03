using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_Gtr_HammerOn : MonoBehaviour
{
    [HideInInspector] public string atkName;
    [HideInInspector] public int phases;
    [HideInInspector] public int type;
    float damage;
    float cost;


    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        atkName = "Hammer On";
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
            anim.SetTrigger("Guit_Atk_HammerOn(Ground)");
        }
        else    // Air
        {

        }
    }

}
