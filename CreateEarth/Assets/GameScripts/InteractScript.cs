using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
    UIscript uIscript;

    private bool canInteract;

    enum ObjectType {Computer, note, log, door}
    [SerializeField] ObjectType objectType;

    enum SceneChoice { SampleScene, ComputerRoom, ChamberCorridor, AbsorberRoom, PowerRoom, LocalRoom, RightWing, LeftWing, SpaceshipInterior, SpaceshipExterior}
    [Header("If Door")]
    [SerializeField] SceneChoice sceneChoice;
    public int doorIndex;
    public bool isLocked;

    //spaceship manager stat
    public GameObject spaceshipManagerStat;
    public SpaceshipManagerStat spaceshipManagerStatScript;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
        uIscript = GameObject.Find("Canvas").GetComponent<UIscript>();

        //spaceshipManagerStat
        spaceshipManagerStat = GameObject.Find("SpaceshipManagerStat");
        spaceshipManagerStatScript = spaceshipManagerStat.GetComponent<SpaceshipManagerStat>();

        //IndexSystem
        if (sceneChoice == SceneChoice.SampleScene)
        {
            doorIndex = 0;
        }
        if (sceneChoice == SceneChoice.SpaceshipInterior)
        {
            doorIndex = 1;
        }
        if (sceneChoice == SceneChoice.AbsorberRoom)
        {
            doorIndex = 2;
        }

        
    }

    // Update is called once per frame
    private void Update()
    {
        ObjectInteracted(objectType, sceneChoice);

        //if list doorsopen contain the index of this door, this door is not locked anymore 
        if (spaceshipManagerStatScript.doorsOpen.Contains(doorIndex))
        {
            isLocked = false;
        }
        else
        {
            isLocked = true;
        }
    }

    //Enter range of interactible object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            uIscript.interactBTN.SetActive(true);
            canInteract = true;
        }
    }

    //Exit range of interactible object
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uIscript.interactBTN.SetActive(false);
            canInteract = false;
        }
    }

    //Action when interact for the Object that have been selected from the EnumList ObjectType
    private void ObjectInteracted(ObjectType objectSelected, SceneChoice sceneSelected)
    {
        if (canInteract == true && Input.GetKeyDown("e"))
        {
            
            if (objectSelected == ObjectType.Computer)
            {
                SceneManager.LoadScene("ComputerScreen");
            }
            if (objectSelected == ObjectType.note)
            {

            }
            if (objectSelected == ObjectType.log)
            {

            }
            if (objectSelected == ObjectType.door)
            {
                //LockedSystem
                if (!isLocked)
                {
                    SceneManager.LoadScene(sceneChoice.ToString());
                }
                else
                {
                    Debug.Log("The Room is Locked");
                }
            }
            
        }
    }
}
