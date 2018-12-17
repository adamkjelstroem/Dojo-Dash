using Luminosity.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

    //joystick movements below this threshold are ignored
    float joystickSensitivity = 0.5f;

    /// <summary>
    /// Contains the keys for the controls of a player (and whether it's a bot, a local player or an internet player)
    /// </summary>
    //private class PlayerConfig
    //{
    //    public int type; //human=0, bot=1, internet player=2
    //    public string
    //        joystickChargeDash,
    //        chargeDash,

    //        joystickHorizontal,
    //        joystickVertical,
    //        horizontal,
    //        vertical;

    //    public PlayerConfig(int type,
    //        string joystickChargeDash,
    //        string chargeDash,
    //        string joystickHorizontal,
    //        string joystickVertical,
    //        string horizontal,
    //        string vertical)
    //    {
    //        this.type = type;
    //        this.joystickChargeDash = joystickChargeDash;
    //        this.chargeDash = chargeDash;
    //        this.joystickHorizontal = joystickHorizontal;
    //        this.joystickVertical = joystickVertical;
    //        this.horizontal = horizontal;
    //        this.vertical = vertical;
    //    }
    //}

    //private PlayerConfig[] players =
    //{
    //    //player 1
    //    new PlayerConfig(0,"JoystickChargeDashP1","ChargeDashP1","JoystickHorizontalP1","JoystickVerticalP1","HorizontalP1","VerticalP1"),
    //    //player 2
    //    new PlayerConfig(0,"JoystickChargeDashP2","ChargeDashP2","JoystickHorizontalP2","JoystickVerticalP2","HorizontalP2","VerticalP2"),
    //};

    //=====================================================================
    // Others
    //=====================================================================

    private void Update()
    {
        //exit game (press escape)
        if (Input.GetKeyDown(KeyCode.Escape)) //TODO note: the key is hard-coded
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    //=====================================================================
    // Local player
    //=====================================================================

    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Player">p1=1,p2=2</param>
    /// <returns>whether a given player is charging.</returns>
    public bool IsPlayerCharging(int Player)
    {
        PlayerID player = Player == 1 ? PlayerID.One : PlayerID.Two;

        return InputManager.GetButton("DashCharge", player);

        //PlayerConfig p = players[Player - 1];
        //if (Input.GetJoystickNames().Length >= 1)
        //{
        //    // We have a controller.
        //    return Input.GetButton(p.joystickChargeDash);
        //}
        //else
        //{
        //    // We have no controller.
        //    return Input.GetAxis(p.chargeDash) == 1;
        //}
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Player">p1=1,p2=2</param>
    /// <returns>the direction a given player is aiming in</returns>
    public Vector2 PlayerDir(int Player)
    {
        PlayerID player = Player == 1 ? PlayerID.One : PlayerID.Two;

        Vector2 dir = new Vector2(InputManager.GetAxisRaw("Horizontal", player), InputManager.GetAxisRaw("Vertical", player));

        if (dir.x < joystickSensitivity && dir.x > joystickSensitivity)
            dir.x = 0;
        if (dir.y < joystickSensitivity && dir.x > joystickSensitivity)
            dir.y = 0;

        return dir;

        //PlayerConfig p = players[Player - 1];
        //if (Input.GetJoystickNames().Length >= 1)
        //{
        //    // We have a controller.

        //    if (Mathf.Abs(Input.GetAxis(p.joystickHorizontal)) <= joystickSensitivity && Mathf.Abs(Input.GetAxis(p.joystickVertical)) <= joystickSensitivity)
        //    {
        //        return new Vector2(0, 0); //minor joystick movements are ignored
        //    }

        //    Vector2 dir = new Vector2(Input.GetAxis(p.joystickHorizontal), Input.GetAxis(p.joystickVertical));
        //    return dir;
        //}

        //// We have no controller.
        //return new Vector2((int)Mathf.Round(Input.GetAxis(p.horizontal)), (int)Mathf.Round(Input.GetAxis(p.vertical)));
    }

    //player 1
    public bool IsPlayer1Charging()
    {
        return IsPlayerCharging(1);
    }

    public Vector2 Player1Dir()
    {
        return PlayerDir(1);
    }

    //player 2
    public bool IsPlayer2Charging()
    {
        return IsPlayerCharging(2);
    }

    public Vector2 Player2Dir()
    {
        return PlayerDir(2);
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

}
