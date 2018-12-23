using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Luminosity.IO;

public class ControllsViewer : MonoBehaviour {

    [Header("Player One")]
    public Sprite KeyboradOne;
    public Sprite ControllerOne;
    public Image ImageOne;

    [Header("Player Two")]
    public Sprite KeyboradTwo;
    public Sprite ControllerTwo;
    public Image ImageTwo;

    [Header("Misc")]
    public GameObject Hint;
    public GameObject P1;
    public GameObject P2;


    private void Start()
    {
        Debug.LogWarning("Still need to see if controller is connected");
        bool keyboardOne = true;
        bool keyboardTwo = true;

        Hint.SetActive(keyboardOne || keyboardTwo);
        ShowPlayerOne(keyboardOne);
        ShowPlayerTwo(keyboardTwo);
    }

    private void ShowPlayerOne(bool keyboard)
    {
        P1.SetActive(keyboard);
        ImageOne.sprite = keyboard ? KeyboradOne : ControllerOne;
    }

    private void ShowPlayerTwo(bool keyboard)
    {
        P2.SetActive(keyboard);
        ImageTwo.sprite = keyboard ? KeyboradTwo : ControllerTwo;
    }
}
