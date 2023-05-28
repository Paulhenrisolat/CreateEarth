using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    private GameObject earthtest;

    // Start is called before the first frame update
    void Start()
    {
        earthtest = GameObject.Find("EarthTest");
        earthtest.SetActive(false);
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
            earthtest.SetActive(true);
            ComputerToSpaceShip.canCreateEarth = false;
        }
    }
}
