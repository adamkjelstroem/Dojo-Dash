//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ControllsViewer : MonoBehaviour {

//    [Header("Player One")]
//    public Sprite KeyboradOne;
//    public Sprite ControllerOne;
//    public Image ImageOne;

//    [Header("Player Two")]
//    public Sprite KeyboradTwo;
//    public Sprite ControllerTwo;
//    public Image ImageTwo;

//    [Header("Misc")]
//    public GameObject Hint;
//    public GameObject P1;
//    public GameObject P2;


//    private void FixedUpdate()
//    {
//        GamePadState padOne = GamePad.GetState(PlayerIndex.One);
//        GamePadState padTwo = GamePad.GetState(PlayerIndex.Two);

//        Debug.LogWarning("Still need to see if controller is connected");
//        bool keyboardOne = !padOne.IsConnected;
//        bool keyboardTwo = !padTwo.IsConnected;

//        Hint.SetActive(keyboardOne || keyboardTwo);
//        ShowPlayerOne(keyboardOne);
//        ShowPlayerTwo(keyboardTwo);
//    }

//    private void ShowPlayerOne(bool keyboard)
//    {
//        P1.SetActive(keyboard);
//        ImageOne.sprite = keyboard ? KeyboradOne : ControllerOne;
//    }

//    private void ShowPlayerTwo(bool keyboard)
//    {
//        P2.SetActive(keyboard);
//        ImageTwo.sprite = keyboard ? KeyboradTwo : ControllerTwo;
//    }
//}
