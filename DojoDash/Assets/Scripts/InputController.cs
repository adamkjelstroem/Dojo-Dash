using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Input;
using static PlayerControls;

public class InputController : MonoBehaviour, IPlayer1Actions, IPlayer2Actions {

    [SerializeField] private PlayerControls playerControls;

    private void Awake()
    {
        playerControls.Player1.SetCallbacks(this);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        //exit game (press escape)
        if (Input.GetKeyDown(KeyCode.Escape)) //TODO note: the key is hard-coded
        {
            SceneManager.LoadScene(0);
        }
    }

    //player 1
    private Vector2 dirP1 = Vector2.zero;
    private bool isChargingP1;

    public bool IsPlayer1Charging()
    {
        return isChargingP1;
    }

    public Vector2 Player1Dir()
    {
        return dirP1;
    }

    public void OnMovementP1(InputAction.CallbackContext context)
    {
        dirP1 = context.ReadValue<Vector2>();
    }

    public void OnDashChargeP1(InputAction.CallbackContext context)
    {
        isChargingP1 = context.ReadValue<bool>();
    }

    //player 2
    private Vector2 dirP2 = Vector2.zero;
    private bool isChargingP2;

    public bool IsPlayer2Charging()
    {
        return isChargingP2;
    }

    public Vector2 Player2Dir()
    {
        return dirP2;
    }

    public void OnMovementP2(InputAction.CallbackContext context)
    {
        dirP2 = context.ReadValue<Vector2>();
    }

    public void OnDashChargeP2(InputAction.CallbackContext context)
    {
        isChargingP2 = context.ReadValue<bool>();
    }
}



//=====================================================================
// AI
//=====================================================================

/*
double tC = -1;
public bool IsPlayer2Charging()
{
if (tC == -1) tC = Time.time;

if(tC <= Time.time-0.9)
{
    tC = Time.time;
    return false;
}
return true;

}

public Vector2 Player2Dir()
{

///TODO use code from player 1 to handle control on p2 eventuially

//TODO generate x and y direction based on opponent's location

GameObject human = GameObject.Find("PlayerOne"); //the human player
GameObject bot = GameObject.Find("PlayerTwo"); //the bot

float dX = human.transform.position.x - bot.transform.position.x;
float dY = human.transform.position.y - bot.transform.position.y;
float angle = Mathf.Atan2(dY, dX);



//print("" + dX + ", " + dY + " " + angle + " " + Mathf.Cos(angle) + ", " + Mathf.Sin(angle));
return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
}

*/
