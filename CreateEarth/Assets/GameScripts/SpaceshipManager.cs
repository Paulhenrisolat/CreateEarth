using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    public GameObject earthtest;
    private DissolveScript dissolveScript;

    // Start is called before the first frame update
    void Start()
    {
        earthtest = GameObject.Find("EarthTest");
        dissolveScript = earthtest.GetComponent<DissolveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        EarthManager();
        CreateEarth();
    }

    private void CreateEarth()
    {
        if (ComputerToSpaceShip.canCreateEarth)
        {
            print("earth is here");

            earthtest.SetActive(true);
            dissolveScript.dissolveAmount = 1;
            dissolveScript.isDissolving = true;

            ComputerToSpaceShip.canCreateEarth = false;
        }
    }

    private void EarthManager()
    {
        if (!ComputerToSpaceShip.earthIsCreated && !ComputerToSpaceShip.earthIsDestroyed)
        {
            dissolveScript.dissolveAmount = 1;
            earthtest.SetActive(false);
        }
        if (dissolveScript.dissolveAmount <= 0 && ComputerToSpaceShip.earthIsCreated)
        {
            dissolveScript.dissolveAmount = 0;
        }
        if (ComputerToSpaceShip.earthIsDestroyed)
        {
            dissolveScript.isDissolving = false;
        }
        
    }
}
