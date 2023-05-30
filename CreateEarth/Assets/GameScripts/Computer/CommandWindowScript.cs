using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandWindowScript : MonoBehaviour
{
    ComputerScript computerScript;

    public GameObject commandOutpout;
    private Transform commandOutpoutPos;

    public int bottomPadding;
    public GameObject commandLinePrefab;
    public GameObject commandLineErrorPrefab;
    private GameObject newCommand;

    public TMP_InputField commandInputField;
    private string commandInput;
    private bool commandRuning;
    private bool commandExist;

    private bool statsusWindowIsOpen;
    private GameObject earthHoloC;
    private GameObject earthHoloNC;
    private GameObject earthNotFound;

    // Start is called before the first frame update
    void Start()
    {
        computerScript = GameObject.Find("ComputerManager").GetComponent<ComputerScript>();
        commandInputField = GameObject.Find("InputCommandField").GetComponent<TMP_InputField>();
        commandOutpout = GameObject.Find("CommandOutpout");
        earthHoloC = GameObject.Find("EarthHoloC");
        earthHoloNC = GameObject.Find("EarthHoloNC");
        earthNotFound = GameObject.Find("EarthNotFound");

        statsusWindowIsOpen = false;
        bottomPadding = 0;
        commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
        commandOutpoutPos = commandOutpout.transform;

        commandRuning = false;
    }

    // Update is called once per frame
    void Update()
    {
        CommandAction();
        UpdateEarthStatusWindow();
    }

    //Trigger when player hit 'Enter/Return' and commandInput not null or wihtespaces in the commandInput window
    public void ReadCommandInput(string input)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            commandInput = input;

            if (!string.IsNullOrWhiteSpace(commandInput))
            {
                Debug.Log(input);

                newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = input;

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

                commandInputField.text = "";
            }
        }
    }

    //Actions trigger by specific commands
    private void CommandAction()
    {
        //close command window
        if (commandInput == "/close" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Closing...";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            computerScript.commandWindow.SetActive(false);

            //clear ipnut
            commandInput = null;
        }

        //print a smiley
        if (commandInput == "/earth test" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = ":)";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action

            //clear ipnut
            commandInput = null;
        }

        //change earth name
        if (commandInput == "/earth set name" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Earth rename to..";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action

            //clear ipnut
            commandInput = null;
        }

        //open earth status window
        if (commandInput == "/earth open status" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Opening [Earth] actual status";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            computerScript.statusWindow.SetActive(true);
            statsusWindowIsOpen = true;

            //clear ipnut
            commandInput = null;
        }

        //close earth status window
        if (commandInput == "/earth close status" && !commandRuning)
        {
            //action
            computerScript.statusWindow.SetActive(false);
            statsusWindowIsOpen = false;

            //clear ipnut
            commandInput = null;
        }

        //create earth
        if (commandInput == "/earth create" && !commandRuning)
        {
            if (ComputerToSpaceShip.earthAlreadyCreated && ComputerToSpaceShip.canCreateEarth)
            {
                //new text
                newCommand = Instantiate(commandLineErrorPrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = "[!]Warning [Earth] Already created !";

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
            }
            if (!ComputerToSpaceShip.earthAlreadyCreated)
            {
                //new text
                newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = "Building [Earth]...";

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

                //action
                ComputerToSpaceShip.earthIsDestroyed = false;
                ComputerToSpaceShip.canCreateEarth = true;
            }

            //clear ipnut
            commandInput = null;
        }

        //destroy earth
        if (commandInput == "/earth destroy" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Destroying [Earth]...";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            ComputerToSpaceShip.earthIsDestroyed = true;

            //clear ipnut
            commandInput = null;
        }
    }

    private void UpdateEarthStatusWindow()
    {
        if (statsusWindowIsOpen)
        {
            if (ComputerToSpaceShip.earthIsCreated)
            {
                earthHoloC.SetActive(true);
                earthHoloNC.SetActive(false);
                //earthNotFound.SetActive(false);
            }
            if (!ComputerToSpaceShip.earthIsCreated)
            {
                earthHoloC.SetActive(false);
                earthHoloNC.SetActive(true);
                //earthNotFound.SetActive(true);
            }
        }
    }

    IEnumerator CommandTimer()
    {
        yield return new WaitForSeconds(2);
        commandRuning = false;
    }
}
