using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerScript : MonoBehaviour
{
    public GameObject commandWindow;
    public GameObject statusWindow;
    public GameObject spaceshipStatusWindow;
    public GameObject scanWindow;

    public bool commandWopen;

    // Start is called before the first frame update
    void Start()
    {
        commandWindow = GameObject.Find("CommandWindow");
        statusWindow = GameObject.Find("EarthStatusWindow");
        spaceshipStatusWindow = GameObject.Find("SpaceShipStatusWindow");
        scanWindow = GameObject.Find("ScannerWindow");

        commandWindow.SetActive(false);
        statusWindow.SetActive(false);
        spaceshipStatusWindow.SetActive(false);
        scanWindow.SetActive(false);

        commandWopen = false;
    }

    // Update is called once per frame
    void Update()
    {
        ExitComputer();
    }

    private void ExitComputer()
    {
        if (Input.GetKeyDown("e") && commandWopen == false)
        {
            SceneManager.LoadScene("SampleScene");
            print("exitPC");
        }
    }

    public void OpenCommandWindow()
    {
        if (commandWopen == false)
        {
            commandWindow.SetActive(true);
            commandWopen = true;
        }
        else if (commandWopen == true)
        {
            commandWindow.SetActive(false);
            commandWopen = false;
        }
    }

    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }
}
