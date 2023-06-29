using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerToSpaceShip : MonoBehaviour
{
    //earth ExistState
    public static bool earthAlreadyCreated;
    public static bool canCreateEarth;
    public static bool earthIsCreated;
    public static bool earthIsDestroyed;

    //core
    public static bool coreCreated = false;
    public static bool coreIsCreating = false;
    public static bool coreIsDestroying = false;

    //lava core
    public static bool coreLavaCreated = false;
    public static bool coreLavaIsCreating = false;
    public static bool coreLavaIsDestroying = false;

    //earth starting stats
    public static float earthTemperature = 0f;
    public static bool earthOxygenExist = false;
    public static float earthRotationSpeed = 0f;
    public static float earthMass = 0f;
    public static int earthLife = 0;
    public static string earthName = "Earth";

    //spaceShip starting stats
    public static string spaceshipState = "Performant";
    public static int spaceshipLife = 500;
    public static int spaceshipMaxLife = 500;
    public static int spaceshipEnergie = 400;
    public static int spaceshipMaxEnergie = 400;
    public static int spaceshipDroneNumber = 4;
    public static string spaceshipName = "SpaceShip";
    public static bool spaceshiphOxygenExist = true;

    void Start()
    {
        earthAlreadyCreated = false;
        earthIsDestroyed = false;
        canCreateEarth = false;
    }
}
