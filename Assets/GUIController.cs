using Assets;
using Assets.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Dropdown teamsDropdown;

    private List<Team> _availableTeams;
    private Team _selectedTeam;

    void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        teamsDropdown.onValueChanged.AddListener(delegate { teamSelected(); });
        InvokeRepeating("refreshTeams", 2, 10);
        InvokeRepeating("refreshChallenges", 10, 2);
    }

    public void teamSelected()
    {
        if (_availableTeams != null)
        {
            if (teamsDropdown.value > 0)
            {
                _selectedTeam = _availableTeams[teamsDropdown.value - 1];
                Debug.Log(string.Format("team {0} with id {1} was selected!", _selectedTeam.Name, _selectedTeam.Id));
            }
            else
            {
                Debug.Log("Team overview was selected");
            }
        }
    }

    void refreshTeams()
    {
        Networking.Instance.refreshTeams(refreshTeamsSuccessCallback, refreshTeamsErrorCallback);
    }

    private void refreshTeamsSuccessCallback(JSONObject json)
    {
        if (json.IsArray)
        {
            _availableTeams = json.GetValues<Team>();
            teamsDropdown.ClearOptions();
            List<string> options = new List<string>();
            options.Add("Overview");
            options.AddRange(_availableTeams.Select(x => x.Name));
            teamsDropdown.AddOptions(options);
        }
    }

    private void refreshTeamsErrorCallback(JSONObject json)
    {
        Debug.LogError(json);
    }

    private void refreshChallenges()
    {
        if (_selectedTeam != null)
        {
            Networking.Instance.refreshChallenges(_selectedTeam.Id, refreshChallengesSuccessCallback, refreshChallengesErrorCallback);
        }
        else
        {
            Networking.Instance.refreshChallengeOverview(refreshChallengeOverviewSuccessCallback, refreshChallengeOverviewErrorCallback);
        }
    }

    private void refreshChallengesSuccessCallback(JSONObject json)
    {
        var teamStatus = json.GetValue<TeamStatus>();
        MaterialToggler.Instance.setTeamStatus(teamStatus);
    }

    private void refreshChallengesErrorCallback(JSONObject json)
    {
        Debug.LogError(json);
    }

    private void refreshChallengeOverviewSuccessCallback(JSONObject json)
    {
        var overviewStatus = json.GetValue<OverviewStatus>();
        MaterialToggler.Instance.setOverviewStatus(overviewStatus);
    }

    private void refreshChallengeOverviewErrorCallback(JSONObject json)
    {
        Debug.LogError(json);
    }
}