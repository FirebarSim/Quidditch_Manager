using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadController : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject instantiationPoint;
    public Team team;

    bool instantiated = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Debug.Log( team );
        if( instantiated == false ) {
            foreach( Player player in team.playerList ) {
                Instantiate( playerPrefab, instantiationPoint.transform );
            }
            instantiated = true;
        }
    }
}
