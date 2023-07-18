using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManagerStat : MonoBehaviour
{
    //spaceShip starting stats
    public string spaceshipState = "Performant";
    public int spaceshipLife = 500;
    public int spaceshipMaxLife = 500;
    public int spaceshipEnergie = 400;
    public int spaceshipMaxEnergie = 400;
    public int spaceshipDroneNumber = 4;
    public string spaceshipName = "SpaceShip";
    public bool spaceshiphOxygenExist = true;
    public int spaceshipExternalMaterial = 150;

    //doors
    public List<int> doorsOpen = new();
    

    //avoid duplicate DontDestroyOnload
    private static GameObject instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //remove if alreadty existant
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        //add door to the openDoors
        doorsOpen.Add(0);
        doorsOpen.Add(1);
        //doorsOpen.Add(2);
    }
}
