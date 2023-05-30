using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerToSpaceShip : MonoBehaviour
{
    public static bool earthAlreadyCreated;
    public static bool canCreateEarth;
    public static bool earthIsCreated;
    public static bool earthIsDestroyed;

    void Start()
    {
        earthAlreadyCreated = false;
        earthIsDestroyed = false;
        canCreateEarth = false;
    }
}
