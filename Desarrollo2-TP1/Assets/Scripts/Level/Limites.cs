using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Limites : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            SceneManager.LoadScene("Loose");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
        
           
    
    
}
