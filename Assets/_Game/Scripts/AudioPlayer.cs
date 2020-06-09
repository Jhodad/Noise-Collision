using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioClip swing1;
    public AudioClip swing2;
    public AudioClip swing3;
    public AudioClip swing4;
    public AudioClip swing5;
    public AudioClip swing6;

    public AudioClip flameA;
    public AudioClip fryingP;

    public AudioClip StrapSpin;
    
    public AudioClip HammerOn1;
    public AudioClip HammerOn2;
    public AudioClip HammerOn3;
    public AudioClip HammerOn4;
    public AudioClip HammerOn5;

    public AudioClip PowerChord1;
    public AudioClip PowerChord2;
    public AudioClip PowerChord3;
    public AudioClip PowerChord4;
    public AudioClip PowerChord5;
    
    public AudioClip PullOff1;
    public AudioClip PullOff2;
    public AudioClip PullOff3;

    public AudioClip Stinger;

    public AudioClip Step;

    public AudioClip MutedStrum;
    public AudioClip ErrorStrum;


    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        
        switch (clip)
        {
            case "swing1":
                audioSrc.PlayOneShot(swing1);
                break;

            case "swing2":
                audioSrc.PlayOneShot(swing2);
                break;

            case "swing3":
                audioSrc.PlayOneShot(swing3);
                break;

            case "swing4":
                audioSrc.PlayOneShot(swing4);
                break;

            case "swing5":
                audioSrc.PlayOneShot(swing5);
                break;

            case "swing6":
                audioSrc.PlayOneShot(swing6);
                break;

            case "flameA":
                audioSrc.PlayOneShot(flameA);
                break;

            case "fryingP":
                audioSrc.PlayOneShot(fryingP);
                break;

            case "StrapSpin":
                audioSrc.PlayOneShot(StrapSpin);
                break;

            case "Error":
                audioSrc.Stop();
                audioSrc.PlayOneShot(ErrorStrum);
                break;

            case "MutedStrum":
                audioSrc.Stop();
                audioSrc.PlayOneShot(MutedStrum);
                break;

            case "Stinger":
                audioSrc.Stop();
                audioSrc.PlayOneShot(Stinger);
                break;

            case "Step":
                audioSrc.PlayOneShot(Step);
                break;

        }
    }

    public void PlayRandomPowerChord()
    {
        audioSrc.Stop();

        int clip = Random.Range(1, 5);
        switch (clip)
        {
            case 1:
                audioSrc.PlayOneShot(PowerChord1);
                break;
            case 2:
                audioSrc.PlayOneShot(PowerChord2);
                break;
            case 3:
                audioSrc.PlayOneShot(PowerChord3);
                break;
            case 4:
                audioSrc.PlayOneShot(PowerChord4);
                break;
            case 5:
                audioSrc.PlayOneShot(PowerChord5);
                break;
        }
    }

    public void PlayRandomHammerOn()
    {
        audioSrc.Stop();
        int clip = Random.Range(4, 5);
        //int clip = Random.Range(1, 5);
        switch (clip)
        {
            case 1:
                audioSrc.PlayOneShot(HammerOn1);
                break;
            case 2:
                audioSrc.PlayOneShot(HammerOn2);
                break;
            case 3:
                audioSrc.PlayOneShot(HammerOn3);
                break;
            case 4:
                audioSrc.PlayOneShot(HammerOn4);
                break;
            case 5:
                audioSrc.PlayOneShot(HammerOn5);
                break;
        }
    }

    public void PlayRandomPullOff()
    {
        audioSrc.Stop();

        int clip = Random.Range(1, 3);
        switch (clip)
        {
            case 1:
                audioSrc.PlayOneShot(PullOff1);
                break;
            case 2:
                audioSrc.PlayOneShot(PullOff2);
                break;
            case 3:
                audioSrc.PlayOneShot(PullOff3);
                break;
        }
    }

    public void StopAudio()
    {
        audioSrc.Stop();
    }

}
