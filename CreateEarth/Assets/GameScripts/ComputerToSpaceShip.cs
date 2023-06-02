using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerToSpaceShip : MonoBehaviour
{
    //earth state
    public static bool earthAlreadyCreated;
    public static bool canCreateEarth;
    public static bool earthIsCreated;
    public static bool earthIsDestroyed;

    //earth stats
    public static float earthTemperature;
    public static bool earthOxygenExist;
    public static float earthRotationSpeed;
    public static float earthMass;
    public static int earthLife;
    public static string earthName;

    //spaceShip stats
    public static int spaceshipLife;
    public static int spaceshipDroneNumber;
    public static string spaceshipName;
    public static bool spaceshiphOxygenExist;

    void Start()
    {
        earthAlreadyCreated = false;
        earthIsDestroyed = false;
        canCreateEarth = false;

        //earth
        earthOxygenExist = false;
        earthTemperature = 0f;
        earthRotationSpeed = 0f;
        earthMass = 0f;
        earthName = "Earth";
        earthLife = 0;

        //spaceship
        spaceshipLife = 500;
        spaceshiphOxygenExist = true;
        spaceshipDroneNumber = 4;
        spaceshipName = "SpaceShip";
    }
}
