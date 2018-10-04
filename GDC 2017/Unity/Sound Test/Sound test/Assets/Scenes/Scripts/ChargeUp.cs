using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUp : MonoBehaviour {

    public float ChargeAmount;
    public float ChargeRate;

    //Alle variabler der skal inkluderes
    [Header("Audio Variables")]
    public AudioClip Drum1;
    public AudioClip Drum2;
    public bool MainDrum = true;
    public float MinimumPitch = 1;
    public float MaximumPitch = 1.2f;
    public float MinimumSpeed = 0.5f;
    public float MaximumSpeed = 0.1f;
    public float Volume = 1;
    public float TimeSinceLastDrum = 0;
    public AudioSource SelfAudioSource;

    // Use this for initialization
    void Start () {
        //Finder eget AudioSource component
        SelfAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        //debug code
        //Tryk en knap ned for at forøge ChargeAmount, nulstiller når der bliver sluppet igen
        //Space kan trykkes for at standse forøgelsen men blive på samme ChargeAmount
        if (!Input.GetKey("space"))
        {
            if (Input.anyKey)
            {
                ChargeAmount += ChargeRate * Time.deltaTime;
                if (ChargeAmount >= 1f)
                {
                    ChargeAmount = 1f;
                }
            }
            else
            {
                ChargeAmount = 0f;
            }
        }
        //Skal køres hver frame 
        PlayChargeSound(ChargeAmount);
	}



    //Håndtere chargeup lyden skal bruge chargeAmount med en værdi mellem 0-1 (0%-100%)
    public void PlayChargeSound(float chargeAmount)
    {
        //Tjekker hvis der oplades et charge
        if (chargeAmount > 0)
        {
            //Timing til hvornår næste lyd skal spilles.  mathf.lerp(min,max,procent) retunere en værdi mellem min og max i forhold til procent
            if (Time.time - TimeSinceLastDrum > Mathf.Lerp(MinimumSpeed,MaximumSpeed,chargeAmount))
            {

                //Bestemmer hvilken lyd der skal spilles
                if (MainDrum)
                {
                    SelfAudioSource.PlayOneShot(Drum1, Volume);
                }
                else
                {
                    SelfAudioSource.PlayOneShot(Drum2, Volume);
                }

                //skifter pitch på sin audio source
                SelfAudioSource.pitch = Mathf.Lerp(MinimumPitch, MaximumPitch, chargeAmount);
                //Opdatere timing
                TimeSinceLastDrum = Time.time;
                //Debug
                print("Played Sound, Time since Last drum " + Mathf.Lerp(MinimumSpeed, MaximumSpeed, chargeAmount));
                //skifter hvilken lyd der skal spilles næst
                MainDrum = !MainDrum;
            }
        }
    }
}
