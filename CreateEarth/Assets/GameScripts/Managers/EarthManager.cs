using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EarthManager : MonoBehaviour
{
    //status earth
    public string earthName = "Earth";
    public int earthHP = 0;
    public int earthMaxHP = 0;
    public float earthTemperature = 0f;
    public float earthRotationSpeed = 0f;
    public float earthMass = 0f;
    public bool earthOxygenExist = false;
    public int earthLayerNumber;

    //earth layers
    public List<EarthLayer> earthLayers;
    public List<EarthLayer> createdLayers;

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
            
        foreach (EarthLayer earthLayer in earthLayers)
        {
            Debug.Log(earthLayer + " Name:" + earthLayer.name + " Creating:" + earthLayer.isCreating + " Created:" + earthLayer.isCreated + " Destroying:" + earthLayer.isDestroying);
        }
    }

    public void AddCreatedLayer(EarthLayer earthLayer)
    {
        createdLayers.Add(earthLayer);
    }
}
