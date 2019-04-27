using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {
    public GameManager gameManager;
    public GameObject panelGame;

    List<GameObject> panelList;
    
    // Start is called before the first frame update
    void Start() {
        panelList = new List<GameObject>();
        foreach( Transform childTransform in panelGame.transform ) {
            panelList.Add( childTransform.gameObject );
        }
        foreach( GameObject panel in panelList ) {
            if( panel.name == "Panel_Team" ) {
                panel.SetActive( true );
            }
            else {
                panel.SetActive( false );
            }
        }
    }

    public void ChangeWindow(string thisWindow) {
        foreach( GameObject panel in panelList ) {
            if( panel.name == thisWindow ) {
                panel.SetActive( true );
            }
            else {
                panel.SetActive( false );
            }
        }
    }
}
