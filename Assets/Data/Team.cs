using System.Collections.Generic;

public class Team {
    public string name { get; protected set; }
    public string nation { get; protected set; }
    public List<Player> playerList;
    //List<Squad> suqads;

    public Team( string name, string nation, List<Player> playerList ) {
        this.name = name;
        this.nation = nation;
        this.playerList = playerList;
    }
}
