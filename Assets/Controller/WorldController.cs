using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {
    List<Player> players;
    List<Team> teams;
    List<League> leagues;
    
    // Start is called before the first frame update
    void Start() {
        initPlayers();
        initTeams();
        initLeagues();
    }

    // Update is called once per frame
    void Update() {
        //updateLeagues();
    }

    void initPlayers() {
        players = new List<Player>();
        string[] lines = File.ReadAllLines( "D:\\GitHub\\Quidditch Manager\\Quidditch Manager\\Assets\\Resources\\Saves\\Default\\players.csv" );
        foreach( string line in lines ) {
            string[] values = line.Split( ',' );
            Player player = new Player( values[1], values[2], int.Parse( values[3] ), float.Parse( values[4] ), float.Parse( values[5] ), float.Parse( values[6] ), float.Parse( values[7] ) );
            Debug.Log( player.name );
            players.Add( player );
        }
    }

    void initTeams() {
        teams = new List<Team>();
        string[] lines = File.ReadAllLines( "D:\\GitHub\\Quidditch Manager\\Quidditch Manager\\Assets\\Resources\\Saves\\Default\\teams.csv" );
        foreach( string line in lines ) {
            string[] values = line.Split( ',' );
            List<Player> playerList = new List<Player>();
            string[] playerIDs = values[3].Split( ' ' );
            foreach( string playerID in playerIDs ) {
                playerList.Add( players[int.Parse( playerID )] );
            }
            Team team = new Team( values[1], values[2], playerList );
            Debug.Log( team.name );
            teams.Add( team );
        }
    }

    void initLeagues() {
        leagues = new List<League>();
        League league = new League( "British and Irish Quidditch League", League.Type.Knockout );
        foreach( Team team in teams ) {
            league.Add( team );
        }
        Debug.Log( league.name );
        leagues.Add( league );
    }

    void updateLeagues() {
        foreach( League league in leagues ) {
            if( league.winner == null ) {
                league.Update();
            }
        }
    }
}
