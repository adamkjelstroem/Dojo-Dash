using UnityEngine;
using System.Collections;

//handles smoke
public class SmokeController : MonoBehaviour {

    float time = 0;
    public float timeAlive = 1.0f; //TODO optimum values?

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time > timeAlive)
        {
            Destroy(transform.gameObject);
        }
	}
}
