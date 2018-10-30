using Luminosity.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFixerController : MonoBehaviour {

    public Color ChangeKeyColor;

    [Header("Player 1 Keyboard")]
    public Text p1lName;
    public Text p1rName;
    public Text p1uName;
    public Text p1dName;
    public Text p1cName;

    
    [Header("Player 2 Keyboard")]
    public Text p2lName;
    public Text p2rName;
    public Text p2uName;
    public Text p2dName;
    public Text p2cName;


    private DataPair[] dataPairs = new DataPair[10];

    private Dictionary<Text, Outline> TextToOutlineMap = new Dictionary<Text, Outline>();

    class DataPair
    {
        public DataPair(string controlSchemeName, string actionName, bool positive, Text text)
        {
            this.controlSchemeName = controlSchemeName;
            this.actionName = actionName;
            this.positive = positive;
            this.text = text;
        }

        public KeyCode GetKeyCode()
        {
            return positive ? InputManager.GetAction(controlSchemeName, actionName).Bindings[0].Positive : InputManager.GetAction(controlSchemeName, actionName).Bindings[0].Negative;
        }
        
        public Text text;
        public string controlSchemeName;
        public string actionName;
        public bool positive;
    }

    // Use this for initialization
    void Start () {
        dataPairs[0] = new DataPair("Player 1", "Horizontal", true, p1rName);
        dataPairs[1] = new DataPair("Player 1", "Horizontal", false, p1lName);
        dataPairs[2] = new DataPair("Player 1", "Vertical", true, p1uName);
        dataPairs[3] = new DataPair("Player 1", "Vertical", false, p1dName);
        dataPairs[4] = new DataPair("Player 1", "DashCharge", true, p1cName);

        dataPairs[5] = new DataPair("Player 2", "Horizontal", true, p2rName);
        dataPairs[6] = new DataPair("Player 2", "Horizontal", false, p2lName);
        dataPairs[7] = new DataPair("Player 2", "Vertical", true, p2uName);
        dataPairs[8] = new DataPair("Player 2", "Vertical", false, p2dName);
        dataPairs[9] = new DataPair("Player 2", "DashCharge", true, p2cName);

        for (int i = 0; i < dataPairs.Length; i++)
        {
            TextToOutlineMap.Add(dataPairs[i].text, dataPairs[i].text.GetComponent<Outline>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(InputManager.GetButton("DashCharge"));

        //extract all key bindings
        dataPairs[0] = new DataPair("Player 1", "Horizontal", true, p1rName);
        dataPairs[1] = new DataPair("Player 1", "Horizontal", false, p1lName);
        dataPairs[2] = new DataPair("Player 1", "Vertical", true, p1uName);
        dataPairs[3] = new DataPair("Player 1", "Vertical", false, p1dName);
        dataPairs[4] = new DataPair("Player 1", "DashCharge", true, p1cName);
        
        dataPairs[5] = new DataPair("Player 2", "Horizontal", true, p2rName);
        dataPairs[6] = new DataPair("Player 2", "Horizontal", false, p2lName);
        dataPairs[7] = new DataPair("Player 2", "Vertical", true, p2uName);
        dataPairs[8] = new DataPair("Player 2", "Vertical", false, p2dName);
        dataPairs[9] = new DataPair("Player 2", "DashCharge", true, p2cName);
        
        for(int i = 0; i < dataPairs.Length; i++) {
            DisplayKeyCode(dataPairs[i]);
        }

    }

    public void OnKeyClick(Text text) {
        Debug.Log("Clicked text: " + text.text);
        
        DataPair dp = GetDataPair(text);
        


        ScanSettings settings = new ScanSettings
        {
            ScanFlags = ScanFlags.Key,
            // If the player presses this key the scan will be canceled.
            CancelScanKey = KeyCode.Escape,
            // If the player doesn't press any key within the specified number
            // of seconds the scan will be canceled.
            Timeout = 10
        };

        //TODO 
        text.color = ChangeKeyColor;


        // You can replace the lambda function with a member function if you want.
        InputManager.StartInputScan(settings, result =>
        {
            // The handle should return "true" if the key is accepted or "false" if the key is rejected.
            // If the key is rejected the scan will continue until a key is accepted or until the timeout expires.

            InputAction inputAction = InputManager.GetAction(dp.controlSchemeName, dp.actionName);
            
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey) && !vKey.Equals(KeyCode.Mouse0))
                {
                    //your code here
                    if(dp.positive) inputAction.Bindings[0].Positive = vKey;
                    else inputAction.Bindings[0].Negative = vKey;

                    text.color = new Color(0f, 0f, 0f);
                }
            }

            return true;
        });


    }
    
    private DataPair GetDataPair(Text text)
    {
        for(int i =0; i < dataPairs.Length; i++)
        {
            if (dataPairs[i].text == text) return dataPairs[i];
        }
        return null;
    }

    private void DisplayKeyCode(DataPair dataPair)
    {
        DisplayKeyCode(dataPair.text, dataPair.GetKeyCode());
    }

    void DisplayKeyCode(Text text, KeyCode keyCode) {
        string s = "" + keyCode;
        if (keyCode.Equals(KeyCode.UpArrow)) s = "↑";
        if (keyCode.Equals(KeyCode.DownArrow)) s = "↓";
        if (keyCode.Equals(KeyCode.LeftArrow)) s = "←";
        if (keyCode.Equals(KeyCode.RightArrow)) s = "→";
        if (keyCode.Equals(KeyCode.Space)) s = "__";
        if (keyCode.Equals(KeyCode.Delete)) s = "del";
        WriteText(text, s);
        DisplayPressedKey(text, keyCode);
    }

    void DisplayPressedKey(Text text, KeyCode keyCode)
    {
        TextToOutlineMap[text].enabled = InputManager.GetKey(keyCode);
        //text.fontStyle = InputManager.GetKey(keyCode) ? FontStyle.Bold : FontStyle.Normal;
    }

    void WriteText(Text text, string s)
    {
        text.text = s;
    }
}
