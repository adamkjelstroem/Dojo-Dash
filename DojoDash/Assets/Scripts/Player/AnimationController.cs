using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    //this is the player animation controller.


    public PlayerBehaviour player;
    public Animator am;

    bool isCharching = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCharging();
	}

    void UpdateCharging()
    {
        if(isCharching != player.charging)
        {
            am.SetBool("StartCharge", player.charging);
        }
        isCharching = player.charging;

    }
}
