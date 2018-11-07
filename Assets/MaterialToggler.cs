using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialToggler : MonoBehaviour
{

    public Material ChallengeSuccessfull;
    public Material ChallengeUnsuccessfull;

    private System.Random _random = new System.Random();
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        count++;
        MeshRenderer my_renderer = GetComponent<MeshRenderer>();
        if (my_renderer != null)
        {
            if(count % 100 == 0)
            {
                Material[] materials = new Material[22];
                for( int i=0; i<22; i++)
                {
                    if( i == 0 || i == 21)
                    {
                        materials[i] = my_renderer.materials[i];
                    }
                    else
                    {
                        materials[i] = _random.Next(0, 2) == 0 ? ChallengeSuccessfull : ChallengeUnsuccessfull;
                    }
                }
                my_renderer.materials = materials;
            }
        }
    }
}