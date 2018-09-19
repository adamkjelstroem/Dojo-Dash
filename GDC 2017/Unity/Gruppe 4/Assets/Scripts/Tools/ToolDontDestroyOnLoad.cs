using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDontDestroyOnLoad : MonoBehaviour {

    public bool dontDestroy;

    void Awake() {
        if (dontDestroy)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
	}

}
