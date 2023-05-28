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
    private GameObject newCommand;

    public TMP_InputField commandInputField;
    private string commandInput;
    private bool commandRuning;
    private bool commandExist;

    // Start is called before the first frame update
    void Start()
    {
        computerScript = GameObject.Find("ComputerManager").GetComponent<ComputerScript>();
        commandInputField = GameObject.Find("InputCommandField").GetComponent<TMP_InputField>();
        commandOutpout = GameObject.Find("CommandOutpout");
        bottomPadding = 0;
        commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
        commandOutpoutPos = commandOutpout.transform;

        commandRuning = false;
    }

    // Update is called once per frame
    void Update()
    {
        CommandAction();
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
        if (commandInput == "/earth open status" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Opening [Earth] actual status";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            computerScript.statusWindow.SetActive(true);

            //clear ipnut
            commandInput = null;
        }
        if (commandInput == "/earth close status" && !commandRuning)
        {
            //action
            computerScript.statusWindow.SetActive(false);

            //clear ipnut
            commandInput = null;
        }
        if (commandInput == "/earth create" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Building [Earth]...";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            ComputerToSpaceShip.canCreateEarth = true;

            //clear ipnut
            commandInput = null;
        }
    }

    IEnumerator CommandTimer()
    {
        yield return new WaitForSeconds(2);
        commandRuning = false;
    }
}
