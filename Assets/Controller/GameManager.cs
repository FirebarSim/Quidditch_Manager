using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject canvas;
    public string savePath = "/Resources/Saves/Default/";
    public NewGameManager newGameManager;

    public List<Manager> managers;
    public Manager manager;

    public List<Player> players;

    public List<Team> teams;
    public Team team;

    public Dictionary<string, GameObject> prefabs { get; protected set; }
    public Dictionary<string, Sprite> sprites { get; protected set; }

    // Start is called before the first frame update
    void Start() {
        LoadPrefabs();
        LoadSprites();
        foreach( Transform child in canvas.transform ) {
            // Initialise to Main Menu
            if( child.gameObject.name == "MainMenu" ) {
                child.gameObject.SetActive( true );
            }
            else {
                child.gameObject.SetActive( false );
            }
        }
        InitialiseManagers();
        InitialisePlayers();
        InitialiseTeams();
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Load the Prefabs
    void LoadPrefabs() {
        prefabs = new Dictionary<string, GameObject>();
        GameObject[] prefabArray = Resources.LoadAll<GameObject>( "Prefabs/" );
        foreach( GameObject go in prefabArray ) {
            Debug.Log(go);
            prefabs[go.name] = go;
        }
    }

    // Load the Sprites
    void LoadSprites() {
        sprites = new Dictionary<string, Sprite>();
        Sprite[] spriteArray = Resources.LoadAll<Sprite>( "Images/Teams/" );
        foreach( Sprite s in spriteArray ) {
            Debug.Log( s );
            sprites[s.name] = s;
        }
    }

    // Initialise the Managers List from file.
    void InitialiseManagers() {
        managers = new List<Manager>();
        string[] lines = File.ReadAllLines( Application.dataPath + savePath + "managers.csv" );
        foreach( string line in lines ) {
            string[] values = line.Split( ',' );
            Manager manager = new Manager( values[0], values[1], int.Parse( values[2] ), int.Parse( values[3] ), int.Parse( values[4] ), int.Parse( values[5] ), int.Parse( values[6] ), int.Parse( values[7] ), int.Parse( values[8] ), int.Parse( values[9] ), int.Parse( values[10] ), int.Parse( values[11] ), int.Parse( values[12] ), int.Parse( values[13] ), int.Parse( values[14] ), int.Parse( values[15] ) );
            Debug.Log( "GameManager.cs - Manager " + manager.nameFirst + " " + manager.nameLast + " created." );
            managers.Add( manager );
        }
        newGameManager.InitialiseManagerSelection( managers );
    }

    // Initialise the Players List from file.
    void InitialisePlayers() {
        players = new List<Player>();
        string[] lines = File.ReadAllLines( Application.dataPath + savePath + "players.csv" );
        foreach( string line in lines ) {
            string[] values = line.Split( ',' );
            Player player = new Player(values[0], values[1], int.Parse(values[2]), float.Parse(values[3]), float.Parse( values[4] ), float.Parse( values[5] ), float.Parse( values[6] ) );
            Debug.Log( "GameManager.cs - Player " + player.name + " created." );
            players.Add( player );
        }
    }

    // Initialise the Teams List from file.
    void InitialiseTeams() {
        teams = new List<Team>();
        string[] lines = File.ReadAllLines( Application.dataPath + savePath + "teams.csv" );
        foreach( string line in lines ) {
            string[] values = line.Split( '|' );
            List<Player> playerList = new List<Player>();
            string[] playerIDs = values[2].Split( ' ' );
            foreach( string playerID in playerIDs ) {
                playerList.Add( players[int.Parse( playerID )] );
            }
            //Team team = new Team( values[0], values[1], playerList );
            Team team = new Team( values[0], values[1], playerList, values[3] );
            Debug.Log( "GameManager.cs - Team " + team.name + " created." );
            teams.Add( team );
        }
        newGameManager.InitialiseTeamSelection( teams );
    }

    // Save User Preferences
    public void SaveOptions() {
        Debug.Log( "GameManager.cs - Preferences Updated" );
    }

    // Quit a Session, removing the player team and manager
    public void QuitSession() {
        manager = null;
        team = null;
    }

    // Quit the Game or Stop Playing in the Editor
    public void Quit() {
        if( Application.isEditor ) {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else {
            Application.Quit();
        }
    }
}
