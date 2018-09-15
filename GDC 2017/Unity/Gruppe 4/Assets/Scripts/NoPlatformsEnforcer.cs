using UnityEngine;
using System.Collections;

//enforces the 'no platforms' setting, if it's used
public class NoPlatformsEnforcer : MonoBehaviour {
    public GameObject main;
    private Main mainScript;
    // Use this for initialization
    void Awake()
    {
        mainScript = main.GetComponent<Main>();
    }

    void Start () {
	    if(!mainScript.globalVariables.platforms)
        {
            Destroy(gameObject);
        }
	}
}
