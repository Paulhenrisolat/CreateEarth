using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
    UIscript uIscript;

    private bool canInteract;

    enum ObjectType {Computer, note, log}
    [SerializeField] ObjectType objectType;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
        uIscript = GameObject.Find("Canvas").GetComponent<UIscript>();
    }

    // Update is called once per frame
    private void Update()
    {
        ObjectInteracted(objectType);
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
    private void ObjectInteracted(ObjectType objectSelected)
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
        }
    }
}
