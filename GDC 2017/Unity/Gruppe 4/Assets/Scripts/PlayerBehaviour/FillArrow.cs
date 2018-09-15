using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// fills the charge arrow to indicate how big the charge is
/// </summary>
public class FillArrow : MonoBehaviour
{
    public GameObject player;
    public Image arrow;
    public PlayerBehaviour playerBehaviour;

    void Awake()
    {
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //show the player charge arrow
        if (playerBehaviour.charging && playerBehaviour.chargeDir >= 0)
        {
            arrow.fillAmount = Mathf.Min(Time.time - playerBehaviour.chargeStart, 
                playerBehaviour.chargeMax, CalculateMaxCharge())
                / playerBehaviour.chargeMax;
        }
        else
        {
            //Hide the player charge arrow
            transform.position = new Vector3(-250, -250, 0);
        }
    }

    public float CalculateMaxCharge()
    {
        return ((playerBehaviour.energy - playerBehaviour.energyCostMin) / playerBehaviour.energyCostRate);
    }
}
