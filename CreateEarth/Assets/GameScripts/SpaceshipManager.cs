using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateEarth();
    }

    private void CreateEarth()
    {
        if (ComputerToSpaceShip.canCreateEarth == true)
        {
            print("earth is here");
            ComputerToSpaceShip.canCreateEarth = false;
        }
    }
}
