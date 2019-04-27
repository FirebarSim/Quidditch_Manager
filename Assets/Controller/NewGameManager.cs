using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameManager : MonoBehaviour {
    public GameManager gameManager;
    public GameObject menuMain;
    public GameObject menuNewGame;
    public GameObject windowGame;
    public GameObject panelManager;
    public GameObject panelTeam;
    public Dropdown managerDropdown;
    public GameObject teamTogglegroup;
    public Text teamTitle;
    public Image teamLogo;
    public Text teamHistory;
    // Coach Details
    public InputField nameFirst;
    public InputField nameLast;
    // Coaching Skills
    public Slider coachingAttacking;
    public Slider coachingDefending;
    public Slider coachingFitness;
    public Slider coachingKeeping;
    public Slider coachingTactical;
    public Slider coachingTechnical;
    public Slider coachingMental;
    public Slider coachingMentoring;
    // Mental Skills
    public Slider mentalAdaptability;
    public Slider mentalDetermination;
    public Slider mentalDiscipline;
    public Slider mentalManagement;
    public Slider mentalMotivating;
    public Slider mentalKnowledge;

    Dictionary<Toggle,Team> teamToggles;

    void Start() {
        panelManager.SetActive( true );
        panelTeam.SetActive( false );
    }

    public void CancelButton() {
        if( panelTeam.activeInHierarchy ) {
            panelManager.SetActive( true );
            panelTeam.SetActive( false );
        }
        else {
            menuNewGame.SetActive( false );
            menuMain.SetActive( true );
        }
    }

    public void AcceptButton() {
        if( panelTeam.activeInHierarchy ) {
            CreateNewGame();
            panelTeam.SetActive( false );
            panelManager.SetActive( true );
            menuNewGame.SetActive( false );
            windowGame.SetActive( true );
        }
        else {
            panelManager.SetActive( false );
            panelTeam.SetActive( true );
        }
    }

    // Initialise Manager Selection
    public void InitialiseManagerSelection( List<Manager> managers ) {
        List<string> managerNames = new List<string>();
        managerNames.Add( "New Manager" );
        foreach( Manager manager in managers ) {
            managerNames.Add( manager.nameFirst + " " + manager.nameLast );
        }
        managerDropdown.AddOptions( managerNames );
    }

    public void InitialiseTeamSelection( List<Team> teams ) {
        teamToggles = new Dictionary<Toggle, Team>();
        foreach( Team team in teams ) {
            GameObject toggle_go = Instantiate( gameManager.prefabs["Toggle_Team_"], teamTogglegroup.transform );
            toggle_go.name = "Toggle_Team_" + team.name;
            toggle_go.GetComponentInChildren<Text>().text = team.name;
            Toggle toggle_tg = toggle_go.GetComponent<Toggle>();
            toggle_tg.group = teamTogglegroup.GetComponent<ToggleGroup>();
            toggle_tg.onValueChanged.RemoveAllListeners();
            toggle_tg.onValueChanged.AddListener( (bool status) => handleTeamToggle( status, toggle_tg) );
            teamToggles.Add( toggle_tg, team );
        }
    }

    void handleTeamToggle( bool status, Toggle t ) {
        if( status ) {
            Debug.Log( "Team is now " + teamToggles[t].name );
            teamTitle.text = teamToggles[t].name;
            teamTitle.color = new Color32( 50, 50, 50, 255 );
            if( gameManager.sprites.ContainsKey( teamToggles[t].name ) ) {
                teamLogo.sprite = gameManager.sprites[teamToggles[t].name];
                teamLogo.color = new Color32( 255, 255, 225, 255 );
            }
            else {
                teamLogo.sprite = null;
                teamLogo.color = new Color32( 255, 255, 225, 0 );
            }
            teamHistory.text = teamToggles[t].history;
            teamHistory.color = new Color32( 255, 255, 255, 255 );
        }
    }

    public void PopulateManager() {
        if( managerDropdown.value >= 1 ) {
            nameFirst.text = gameManager.managers[managerDropdown.value - 1].nameFirst;
            nameLast.text = gameManager.managers[managerDropdown.value - 1].nameLast;
            coachingAttacking.value = gameManager.managers[managerDropdown.value - 1].coachingAttacking;
            coachingDefending.value = gameManager.managers[managerDropdown.value - 1].coachingDefending;
            coachingFitness.value = gameManager.managers[managerDropdown.value - 1].coachingFitness;
            coachingKeeping.value = gameManager.managers[managerDropdown.value - 1].coachingKeeping;
            coachingTactical.value = gameManager.managers[managerDropdown.value - 1].coachingTactical;
            coachingTechnical.value = gameManager.managers[managerDropdown.value - 1].coachingTechnical;
            coachingMental.value = gameManager.managers[managerDropdown.value - 1].coachingMental;
            coachingMentoring.value = gameManager.managers[managerDropdown.value - 1].coachingMentoring;
            mentalAdaptability.value = gameManager.managers[managerDropdown.value - 1].mentalAdaptability;
            mentalDetermination.value = gameManager.managers[managerDropdown.value - 1].mentalDetermination;
            mentalDiscipline.value = gameManager.managers[managerDropdown.value - 1].mentalDiscipline;
            mentalManagement.value = gameManager.managers[managerDropdown.value - 1].mentalManagement;
            mentalMotivating.value = gameManager.managers[managerDropdown.value - 1].mentalMotivating;
            mentalKnowledge.value = gameManager.managers[managerDropdown.value - 1].mentalKnowledge;
            Debug.Log( "NewGameManager.cs - Manager Screen Populated with " + gameManager.managers[managerDropdown.value - 1].nameFirst + " " + gameManager.managers[managerDropdown.value - 1].nameLast + "." );
        }
        else {
            nameFirst.text = "";
            nameLast.text = "";
            coachingAttacking.value = 0;
            coachingDefending.value = 0;
            coachingFitness.value = 0;
            coachingKeeping.value = 0;
            coachingTactical.value = 0;
            coachingTechnical.value = 0;
            coachingMental.value = 0;
            coachingMentoring.value = 0;
            mentalAdaptability.value = 0;
            mentalDetermination.value = 0;
            mentalDiscipline.value = 0;
            mentalManagement.value = 0;
            mentalMotivating.value = 0;
            mentalKnowledge.value = 0;
        }
    }

    public void CreateNewGame() {
        Debug.Log( "NewGameManager.cs - Creating New Game" );
        if( managerDropdown.value >= 1 ) {
            gameManager.manager = gameManager.managers[managerDropdown.value - 1];
        }
        else {
            Manager tempManager = new Manager(nameFirst.text, nameLast.text, (int) coachingAttacking.value, (int) coachingDefending.value, (int) coachingFitness.value, (int) coachingKeeping.value, (int) coachingTactical.value, (int) coachingTechnical.value, (int) coachingMental.value, (int) coachingMentoring.value, (int) mentalAdaptability.value, (int) mentalDetermination.value, (int) mentalDiscipline.value, (int) mentalManagement.value, (int) mentalMotivating.value, (int) mentalKnowledge.value);
            gameManager.managers.Add( tempManager );
            gameManager.manager = gameManager.managers[gameManager.managers.Count - 1];
        }
        foreach( KeyValuePair <Toggle,Team> teamToggle in teamToggles ) {
            if( teamToggle.Key.isOn ) {
                gameManager.team = teamToggle.Value;
            }
        }
        Debug.Log( "NewGameManager.cs - Done" );
    }
}
