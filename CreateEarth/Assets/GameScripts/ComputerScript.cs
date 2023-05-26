using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerScript : MonoBehaviour
{
    private GameObject commandWindow;
    private bool commandWopen;

    // Start is called before the first frame update
    void Start()
    {
        commandWindow = GameObject.Find("CommandWindow");

        commandWindow.SetActive(false);
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
}
