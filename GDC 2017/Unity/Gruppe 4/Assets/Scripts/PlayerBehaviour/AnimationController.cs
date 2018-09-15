using UnityEngine;
using System.Collections;

/// <summary>
/// Animation controller for a player
/// </summary>
public class AnimationController : MonoBehaviour {
    
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
