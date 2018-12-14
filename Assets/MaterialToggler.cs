using Assets.Domain;
using UnityEngine;

public class MaterialToggler : MonoBehaviour
{
    public Material Artifact;
    public Material Iron;
    public Material ChallengeSuccessfull;
    public Material ChallengeUnsuccessfull;

    private TeamStatus _currentStatus;

    private static MaterialToggler _instance = null;

    public static MaterialToggler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(MaterialToggler)) as MaterialToggler;

                if (_instance == null && Application.isEditor)
                    Debug.LogError("Could not locate a MaterialToggler object. You have to have exactly one MaterialToggler in the scene.");
            }

            return _instance;
        }
    }

    void Awake()
    {
        // See if we are a superfluous instance:
        if (_instance != null)
        {
            Debug.LogError("You can only have one instance of the MaterialToggler singleton object in existence.");
        }
        else
            _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer my_renderer = GetComponent<MeshRenderer>();
        if (my_renderer != null)
        {
            Material[] materials = new Material[my_renderer.materials.Length];
            for (int i = 0; i < my_renderer.materials.Length; i++)
            {
                Destroy(my_renderer.materials[i]);
                if (i == 0 || i == my_renderer.materials.Length - 1)
                {
                    materials[i] = i == 0 ? Artifact : Iron;
                }
                else
                {
                    if (_currentStatus == null)
                    {
                        materials[i] = ChallengeUnsuccessfull;
                    }
                    else
                    {
                        switch (i)
                        {
                            case 1:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge01Status);
                                break;
                            case 2:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge02Status);
                                break;
                            case 3:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge03Status);
                                break;
                            case 4:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge04Status);
                                break;
                            case 5:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge05Status);
                                break;
                            case 6:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge06Status);
                                break;
                            case 7:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge07Status);
                                break;
                            case 8:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge08Status);
                                break;
                            case 9:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge09Status);
                                break;
                            case 10:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge10Status);
                                break;
                            case 11:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge11Status);
                                break;
                            case 12:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge12Status);
                                break;
                            case 13:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge13Status);
                                break;
                            case 14:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge14Status);
                                break;
                            case 15:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge15Status);
                                break;
                            case 16:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge16Status);
                                break;
                            case 17:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge17Status);
                                break;
                            case 18:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge18Status);
                                break;
                            case 19:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge19Status);
                                break;
                            case 20:
                                materials[i] = GetMaterialForStatus(_currentStatus.Challenge20Status);
                                break;
                        }
                    }
                }
            }
            my_renderer.materials = materials;
        }
    }

    private Material GetMaterialForStatus(Status status)
    {
        return status == Status.Successful ? ChallengeSuccessfull : ChallengeUnsuccessfull;
    }

    public void setTeamStatus(TeamStatus status)
    {
        _currentStatus = status;
    }

    public void setOverviewStatus(OverviewStatus status)
    {
        _currentStatus = new TeamStatus
        {
            Challenge01Status = status.Challenge01Status,
            Challenge02Status = status.Challenge02Status,
            Challenge03Status = status.Challenge03Status,
            Challenge04Status = status.Challenge04Status,
            Challenge05Status = status.Challenge05Status,
            Challenge06Status = status.Challenge06Status,
            Challenge07Status = status.Challenge07Status,
            Challenge08Status = status.Challenge08Status,
            Challenge09Status = status.Challenge09Status,
            Challenge10Status = status.Challenge10Status,
            Challenge11Status = status.Challenge11Status,
            Challenge12Status = status.Challenge12Status,
            Challenge13Status = status.Challenge13Status,
            Challenge14Status = status.Challenge14Status,
            Challenge15Status = status.Challenge15Status,
            Challenge16Status = status.Challenge16Status,
            Challenge17Status = status.Challenge17Status,
            Challenge18Status = status.Challenge18Status,
            Challenge19Status = status.Challenge19Status,
            Challenge20Status = status.Challenge20Status
        };
    }
}