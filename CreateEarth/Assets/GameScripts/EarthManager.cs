using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour
{
    public List<EarthLayer> earthLayers;
    public List<EarthLayer> createdLayers;

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
