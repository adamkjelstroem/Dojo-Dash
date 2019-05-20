using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

    private Vector2 dirP1 = Vector2.zero;
    private Vector2 dirP2 = Vector2.zero;
    private bool isChargingP1;
    private bool isChargingP2;


    private void Update()
    {

        // Set values form keyboard
        dirP1 = new Vector2(
            Input.GetAxisRaw("HorizontalP1"),
            Input.GetAxisRaw("VerticalP1")
            );
        dirP2 = new Vector2(
            Input.GetAxisRaw("HorizontalP2"),
            Input.GetAxisRaw("VerticalP2")
            );
        isChargingP1 = 0 != Input.GetAxisRaw("ChargeDashP1");
        isChargingP2 = 0 != Input.GetAxisRaw("ChargeDashP2");

        // Overide player 1 if there is a controller
        if (Input.GetJoystickNames().Length >= 1)
        {
            dirP1 = new Vector2(
                Input.GetAxisRaw("JoystickHorizontalP1"),
                Input.GetAxisRaw("JoystickVerticalP1")
                );
            isChargingP1 = 0 != Input.GetAxisRaw("JoystickChargeDashP1");
        }

        // Overide player 2 if there is a controller
        if (Input.GetJoystickNames().Length >= 2)
        {
            dirP2 = new Vector2(
                Input.GetAxisRaw("JoystickHorizontalP2"),
                Input.GetAxisRaw("JoystickVerticalP2")
                );
            isChargingP2 = 0 != Input.GetAxisRaw("JoystickChargeDashP2");
        }

        //exit game (press escape)
        if (Input.GetKeyDown(KeyCode.Escape)) //TODO note: the key is hard-coded
        {
            SceneManager.LoadScene(0);
        }
    }

    //player 1
    public bool IsPlayer1Charging()
    {
        return isChargingP1;
    }

    public Vector2 Player1Dir()
    {
        return dirP1;
    }

    //player 2
    public bool IsPlayer2Charging()
    {
        return isChargingP2;
    }

    public Vector2 Player2Dir()
    {
        return dirP2;
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
