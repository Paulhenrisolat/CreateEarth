using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New EarthLayer")]
public class EarthLayer : ScriptableObject
{
    public new string name;
    public bool isActive;
    public bool isCreated;
    public bool isCreating;
    public bool isDestroying;
}
