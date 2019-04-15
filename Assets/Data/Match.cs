using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match {
    public enum Outcome { Undefined, Team1, Team2, Draw, Canceled, Rescheduled }

    public int schedule { get; protected set; }
    public Team team1 { get; protected set; }
    public Team team2 { get; protected set; }
    public Outcome outcome { get; protected set; }

    float probabilityResolve = 0;

    public Match( int schedule, Team team1, Team team2 ) {
        this.schedule = schedule;
        this.team1 = team1;
        this.team2 = team2;
        this.outcome = Outcome.Undefined;
        Debug.Log( "Match.cs - Match between " + team1.name + " and " + team2.name + " scheduled for " + schedule + "." );
    }

    public void Progress() {
        probabilityResolve += Time.deltaTime * Random.Range( 0f, 1f );
        if( probabilityResolve >= 1 ) {
            if( Random.Range( 0f, 1f ) > 0.5 ) {
                outcome = Outcome.Team1;
                Debug.Log( "Match.cs - " + team1.name + " defeat " + team2.name + "." );
            }
            else {
                outcome = Outcome.Team2;
                Debug.Log( "Match.cs - " + team2.name + " defeat " + team1.name + "." );
            }
        }
    }
}
