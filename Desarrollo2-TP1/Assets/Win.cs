using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    
    private bool isActive = true;
	
	// Update is called once per frame
	void Update ()
    {
        if (isActive)
            ActivarMouse();
		
	}
    void ActivarMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
