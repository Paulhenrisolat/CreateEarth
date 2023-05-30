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
    }

    private void EarthManager()
    {
        //V2
        //Start earth not created
        if (!ComputerToSpaceShip.canCreateEarth && !ComputerToSpaceShip.earthAlreadyCreated)
        {
            earthtest.SetActive(false);
        }
        //earth is creating
        if(ComputerToSpaceShip.canCreateEarth && !ComputerToSpaceShip.earthAlreadyCreated)
        {
            earthtest.SetActive(true);
            dissolveScript.dissolveAmount = 1;
            dissolveScript.isDissolving = true;
            ComputerToSpaceShip.earthAlreadyCreated = true;
        }
        //earth is created
        if (ComputerToSpaceShip.earthAlreadyCreated && !ComputerToSpaceShip.earthIsDestroyed)
        {
            earthtest.SetActive(true);
            dissolveScript.isDissolving = true;
        }
        //earth is destroying
        if (ComputerToSpaceShip.earthAlreadyCreated && ComputerToSpaceShip.earthIsDestroyed)
        {
            ComputerToSpaceShip.canCreateEarth = false;
            earthtest.SetActive(true);
            //dissolveScript.dissolveAmount = 0;
            dissolveScript.isDissolving = false;

            if(dissolveScript.dissolveAmount >= 1)
            {
                ComputerToSpaceShip.earthAlreadyCreated = false;
            }
        }
        
    }
}
