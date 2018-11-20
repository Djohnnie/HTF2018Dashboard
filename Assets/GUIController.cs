using Assets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    public Dropdown teamsDropdown;

    void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        teamsDropdown.onValueChanged.AddListener(delegate { teamSelected(); });
        InvokeRepeating("refreshTeams", 2, 10);
    }

    public void teamSelected()
    {

    }

    void refreshTeams()
    {
        Networking.Instance.refreshTeams(refreshTeamsSuccessCallback, refreshTeamsErrorCallback);
    }

    private void refreshTeamsSuccessCallback(JSONObject json)
    {
        if (json.IsArray)
        {
            List<string> options = new List<string>();
            foreach (JSONObject name in json.list)
            {
                options.Add(name.getStringValue("name"));
            }
            teamsDropdown.ClearOptions();
            teamsDropdown.AddOptions(options);
            //if (!GridController.Instance.hasSelectedArena())
            //{
            //    arenaSelected();
            //}

        }
    }

    private void refreshTeamsErrorCallback(JSONObject json)
    {
        Debug.LogError(json);
    }
}