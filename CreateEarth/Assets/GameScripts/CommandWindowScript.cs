using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandWindowScript : MonoBehaviour
{
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

    private void CommandAction()
    {
        if(commandInput == "/earth test" && !commandRuning)
        {
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = ":)";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            commandInput = null;
            //commandRuning = true;
            //StartCoroutine(CommandTimer());
        }
    }

    IEnumerator CommandTimer()
    {
        yield return new WaitForSeconds(2);
        commandRuning = false;
    }
}
