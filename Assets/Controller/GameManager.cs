using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start() {
        foreach( Transform child in canvas.transform ) {
            // Initialise to Main Menu
            if( child.gameObject.name == "MainMenu" ) {
                child.gameObject.SetActive( true );
            }
            else {
                child.gameObject.SetActive( false );
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
