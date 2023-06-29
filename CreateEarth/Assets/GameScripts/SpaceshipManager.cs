using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    //earth elements
    //public GameObject earthtest;
    //public GameObject earthLavaCore;

    private DissolveScript dissolveScript;
    private GameObject earthElement;
    public List<GameObject> earthElements;

    //earth manager
    public GameObject earthManager;
    public List<EarthLayer> earthLayers;
    public List<EarthLayer> createdLayers;

    private bool layerIsCreated;
    //create state
    private bool elementIsCreating;
    //private bool elementCreated;
    private bool elementIsDestroying;

    // Start is called before the first frame update
    void Start()
    {
        earthManager = GameObject.Find("EarthManager");
        earthLayers = earthManager.GetComponent<EarthManager>().earthLayers;
        createdLayers = earthManager.GetComponent<EarthManager>().createdLayers;

        //earthtest = GameObject.Find("EarthTest");
        //earthLavaCore = GameObject.Find("EarthLavaCore");

        layerIsCreated = false;

        //elementIsCreating = false;
        //elementCreated = false;
        elementIsDestroying = false;

        foreach (EarthLayer earthLayer in earthLayers)
        {
            earthElement = GameObject.Find(earthLayer.name);

            if(earthElement == null)
            {
                Debug.LogError(earthLayer.name + " Is missing in the scene Object");
            }
            else
            {
                dissolveScript = earthElement.GetComponent<DissolveScript>();
                dissolveScript.dissolveAmount = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        EarthManager();
        LayerIsCreated();
    }

    //dissolve and set active gameobject for earth
    private void EarthManager()
    {
        //Creating then adding a layer of earth
        foreach(EarthLayer earthLayer in earthLayers)
        {
            //creating earth layer
            if(earthLayer.isCreating == true)
            {
                earthLayer.isCreating = false;
                Debug.Log("Hey Thats  Me !! : " + earthLayer.name);

                earthElement = GameObject.Find(earthLayer.name);
                dissolveScript = earthElement.GetComponent<DissolveScript>();

                earthElement.SetActive(true);
                dissolveScript.dissolveAmount = 1;
                dissolveScript.isDissolving = true;

                earthLayer.isActive = true;
                layerIsCreated = true;
            }

            //layer created
            if(earthLayer.isCreated == true)
            {
                earthElement = GameObject.Find(earthLayer.name);
                dissolveScript = earthElement.GetComponent<DissolveScript>();
                dissolveScript.dissolveAmount = 0;
                dissolveScript.isDissolving = true;
            }
        }

        //is destroying
        if (elementIsDestroying)
        {
            earthElement.SetActive(true);
            dissolveScript.isDissolving = false;

            if (dissolveScript.dissolveAmount >= 1)
            {
                ComputerToSpaceShip.earthAlreadyCreated = false;
            }
        }
    }

    private void LayerIsCreated()
    {
        if(layerIsCreated == true)
        {
            foreach (EarthLayer earthLayer in earthLayers)
            {
                earthElement = GameObject.Find(earthLayer.name);
                dissolveScript = earthElement.GetComponent<DissolveScript>();

                if (dissolveScript.isDissolved == true && earthLayer.isActive == true)
                {
                    Debug.Log(":OOOOO " + dissolveScript);
                    earthLayer.isCreated = true;
                    earthManager.GetComponent<EarthManager>().AddCreatedLayer(earthLayer);

                    layerIsCreated = false;
                    earthLayer.isActive = false;
                }
            }
        }
    }
}
