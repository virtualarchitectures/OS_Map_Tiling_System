using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {
	
	// This script exits the application upon pressing the Esc key
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
