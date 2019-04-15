using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class League {
    public enum Type { RoundRobin, Knockout }

    public string name { get; protected set; }
    int stadia = 2;
    List<Team> teams;
    Type type;
    List<Match> matches;
    public Team winner { get; protected set; }

    public League( string name, Type type) {
        this.name = name;
        this.type = type;
        this.teams = new List<Team>();
        this.matches = new List<Match>();
    }

    public void Add(Team team) {
        teams.Add( team );
    }

    public void Update() {
        Schedule();
        foreach( Match match in matches ) {
            if( match.schedule < Time.time && match.outcome == Match.Outcome.Undefined ) {
                match.Progress();
                if( match.outcome == Match.Outcome.Team1 ) {
                    teams.Remove( match.team2 );
                }
                else if( match.outcome == Match.Outcome.Team2 ) {
                    teams.Remove( match.team1 );
                }
            }
        }
        if( teams.Count == 1 ) {
            winner = teams[0];
            Debug.Log( "League.cs - The " + winner.name + " win the " + name + "." );
        }
    }

    void Schedule() {
        if( type == Type.Knockout && matches.TrueForAll( match => match.outcome != Match.Outcome.Undefined ) ) {
            List<Team> tempTeams = new List<Team>();
            foreach( Team team in teams ) {
                tempTeams.Add( team );
            }
            for( int i = 0; i < highestPowerof2( tempTeams.Count ); i++ ) {
                matches.Add( new Match( (int) Time.time + ( i / stadia ) * 7, tempTeams[0], tempTeams[1] ) );
                tempTeams.Remove( tempTeams[0] );
                tempTeams.Remove( tempTeams[0] );
            }
        }
        else if( type == Type.RoundRobin ) {
            Debug.LogError( "League.cs - Round Robin not Implemented." );
        }
    }

    int highestPowerof2( int n ) {
        int res = 0;
        for( int i = n; i >= 1; i-- ) {
            // If i is a power of 2 
            if( ( i & ( i - 1 ) ) == 0 ) {
                res = i;
                break;
            }
        }
        return res;
    }
}
