using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerToSpaceShip : MonoBehaviour
{
    public static bool canCreateEarth;
    public static bool earthIsCreated;
    public static bool earthIsDestroyed;

    void Start()
    {
        earthIsDestroyed = false;
        canCreateEarth = false;
    }
}
