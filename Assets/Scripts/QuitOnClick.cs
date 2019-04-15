
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

    public void Quit() {
        if( Application.isEditor ) {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else {
            Application.Quit();
        }
    }
}