using System.Collections;
using System.Collections.Generic;

public class Squad {
    string name;
    Player chaser1;
    Player chaser2;
    Player chaser3;
    Player beater1;
    Player beater2;
    Player keeper;
    Player seeker;
    List<Player> reserves;

    public Squad( string name, Player chaser1, Player chaser2, Player chaser3, Player beater1, Player beater2, Player keeper, Player seeker, List<Player> reserves) {
        this.name = name;
        this.chaser1 = chaser1;
        this.chaser2 = chaser2;
        this.chaser3 = chaser3;
        this.beater1 = beater1;
        this.beater2 = beater2;
        this.keeper = keeper;
        this.seeker = seeker;
        this.reserves = reserves;
    }
}
