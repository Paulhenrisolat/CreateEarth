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

    //earth manager
    public GameObject earthManager;
    public EarthManager earthManagerScript;
    public List<EarthLayer> earthLayers;

    //spaceship manager stat
    public GameObject spaceshipManagerStat;
    public SpaceshipManagerStat spaceshipManagerStatScript;

    //status earth window
    private bool statsusWindowIsOpen;
    private GameObject earthHoloC;
    private GameObject earthHoloNC;
    private TextMeshProUGUI earthTemp;
    private TextMeshProUGUI earthRotSpeed;
    private TextMeshProUGUI earthMass;
    private TextMeshProUGUI earthOxygen;
    public TextMeshProUGUI earthName;
    public TextMeshProUGUI earthHp;
    public TextMeshProUGUI earthHpMax;
    public GameObject earthNotFound;

    //status spaceship window
    private bool spaceshipstatsusWindowIsOpen;
    private TextMeshProUGUI spaceshipState;
    private TextMeshProUGUI spaceshipLife;
    private TextMeshProUGUI spaceshipEnergie;
    private TextMeshProUGUI spaceshiphOxygenExist;
    private TextMeshProUGUI spaceshipDroneNumber;
    private TextMeshProUGUI spaceshipName;

    //scan window
    private bool scanWindowIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        //earthManager
        earthManager = GameObject.Find("EarthManager");
        earthManagerScript = earthManager.GetComponent<EarthManager>();
        earthLayers = earthManagerScript.earthLayers;

        //spaceshipManagerStat
        spaceshipManagerStat = GameObject.Find("SpaceshipManagerStat");
        spaceshipManagerStatScript = spaceshipManagerStat.GetComponent<SpaceshipManagerStat>();

        computerScript = GameObject.Find("ComputerManager").GetComponent<ComputerScript>();
        earthHoloC = GameObject.Find("EarthHoloC");
        earthHoloNC = GameObject.Find("EarthHoloNC");
        earthName = GameObject.Find("EarthName").GetComponent<TextMeshProUGUI>();
        earthName.text = "test";

        statsusWindowIsOpen = false;
        spaceshipstatsusWindowIsOpen = false;
        scanWindowIsOpen = false;

        bottomPadding = 0;

        commandRuning = false;
    }

    // Update is called once per frame
    void Update()
    {
        WindowsOpen();
        CommandAction();
        UpdateEarthStatusWindow();
    }

    private void WindowsOpen()
    {
        if (computerScript.commandWopen)
        {
            commandInputField = GameObject.Find("InputCommandField").GetComponent<TMP_InputField>();
            commandOutpout = GameObject.Find("CommandOutpout");
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
            commandOutpoutPos = commandOutpout.transform;
        }
        if (statsusWindowIsOpen)
        {
            earthTemp = GameObject.Find("TemperatureSTAT").GetComponent<TextMeshProUGUI>();
            earthTemp.text = "Temp : " + earthManagerScript.earthTemperature + "�C";
            earthRotSpeed = GameObject.Find("RotationSpeedSTAT").GetComponent<TextMeshProUGUI>();
            earthRotSpeed.text = "Rotation Speed : " + earthManagerScript.earthRotationSpeed + "KM/h";
            earthMass = GameObject.Find("MassSTAT").GetComponent<TextMeshProUGUI>();
            earthMass.text = "Mass : " + earthManagerScript.earthMass + "Kg";
            earthOxygen = GameObject.Find("OxygenSTAT").GetComponent<TextMeshProUGUI>();
            earthOxygen.text = "Oxygen : " + earthManagerScript.earthOxygenExist;
            earthHp = GameObject.Find("HpSTAT").GetComponent<TextMeshProUGUI>();
            earthHp.text = earthManagerScript.earthHP + " HP /";
            earthHpMax = GameObject.Find("HpMaxSTAT").GetComponent<TextMeshProUGUI>();
            earthHpMax.text = earthManagerScript.earthMaxHP + " HP";
        }
        if (spaceshipstatsusWindowIsOpen)
        {
            spaceshipName = GameObject.Find("SpaceshipNameSTAT").GetComponent<TextMeshProUGUI>();
            spaceshipName.text = "Name : " + spaceshipManagerStatScript.spaceshipName;
            spaceshipState = GameObject.Find("SpaceshipStateSTAT").GetComponent<TextMeshProUGUI>();
            spaceshipState.text = "State : " + spaceshipManagerStatScript.spaceshipState;
            spaceshipLife = GameObject.Find("SpaceshipLifeSTAT").GetComponent<TextMeshProUGUI>();
            spaceshipLife.text = "Life : " + spaceshipManagerStatScript.spaceshipLife + " / " + spaceshipManagerStatScript.spaceshipMaxLife + " Hp";
            spaceshipEnergie = GameObject.Find("SpaceshipEnergySTAT").GetComponent<TextMeshProUGUI>();
            spaceshipEnergie.text = "Energie : " + spaceshipManagerStatScript.spaceshipEnergie + " / " + spaceshipManagerStatScript.spaceshipMaxEnergie + " J";
            spaceshiphOxygenExist = GameObject.Find("SpaceshipOxygenSTAT").GetComponent<TextMeshProUGUI>();
            spaceshiphOxygenExist.text = "Oxygen : " + spaceshipManagerStatScript.spaceshiphOxygenExist;
            spaceshipDroneNumber = GameObject.Find("SpaceshipDronesSTAT").GetComponent<TextMeshProUGUI>();
            spaceshipDroneNumber.text = "Drones : " + spaceshipManagerStatScript.spaceshipDroneNumber;
        }
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
        //test stat
        if (commandInput == "/spaceship heal" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Healing spaceship...";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            spaceshipManagerStatScript.spaceshipLife = spaceshipManagerStatScript.spaceshipLife + 10;

            //clear ipnut
            commandInput = null;
        }
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
        if (commandInput == "/test" && !commandRuning)
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
            statsusWindowIsOpen = true;
            computerScript.statusWindow.SetActive(true);
            

            //clear ipnut
            commandInput = null;
        }

        //close earth status window
        if (commandInput == "/earth close status" && !commandRuning)
        {
            //action
            statsusWindowIsOpen = false;
            computerScript.statusWindow.SetActive(false);
            

            //clear ipnut
            commandInput = null;
        }

        //open spaceShip status window
        if (commandInput == "/spaceship open status" && !commandRuning)
        {
            if (spaceshipstatsusWindowIsOpen)
            {
                //new text
                newCommand = Instantiate(commandLineErrorPrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = "[!]Window Already Open !";

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
            }
            else
            {
                //new text
                newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = "Opening [Spaceship] actual status";

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

                //action
                computerScript.spaceshipStatusWindow.SetActive(true);
                spaceshipstatsusWindowIsOpen = true;

                //clear ipnut
                commandInput = null;
            }
        }

        //close spaceShip status window
        if (commandInput == "/spaceship close status" && !commandRuning)
        {
            //action
            computerScript.spaceshipStatusWindow.SetActive(false);
            spaceshipstatsusWindowIsOpen = false;

            //clear ipnut
            commandInput = null;
        }

        //create earth
        if (commandInput == "/earth create core" && !commandRuning)
        {
            //action
            foreach (EarthLayer earthLayer in earthLayers)
            {
                if (earthLayer.name == "core")
                {
                    if(earthLayer.isCreating || earthLayer.isCreated)
                    {
                        //new error text
                        newCommand = Instantiate(commandLineErrorPrefab, commandOutpoutPos);
                        newCommand.GetComponent<TextMeshProUGUI>().text = "[!]Warning [CORE] Already created !";

                        bottomPadding = bottomPadding + 10;
                        commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
                    }
                    else
                    {
                        earthLayer.isCreating = true;

                        //new text
                        newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
                        newCommand.GetComponent<TextMeshProUGUI>().text = "Building [CORE]...";
                        bottomPadding = bottomPadding + 10;
                        commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
                    }
                }
            }

            //clear ipnut
            commandInput = null;
        }

        //create lava
        if (commandInput == "/earth create lava" && !commandRuning)
        {
            //action
            foreach (EarthLayer earthLayer in earthLayers)
            {
                if (earthLayer.name == "lava")
                {
                    if (earthLayer.isCreating || earthLayer.isCreated)
                    {
                        //new error text
                        newCommand = Instantiate(commandLineErrorPrefab, commandOutpoutPos);
                        newCommand.GetComponent<TextMeshProUGUI>().text = "[!]Warning [LAVA] Already created !";

                        bottomPadding = bottomPadding + 10;
                        commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
                    }
                    else
                    {
                        earthLayer.isCreating = true;

                        //new text
                        newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
                        newCommand.GetComponent<TextMeshProUGUI>().text = "Building [LAVA]...";
                        bottomPadding = bottomPadding + 10;
                        commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;
                    }
                }
            }

            //clear ipnut
            commandInput = null;
        }

        //destroy earth
        if (commandInput == "/earth destroy core" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Destroying [Earth]...";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            //ComputerToSpaceShip.earthIsDestroyed = true;

            //clear ipnut
            commandInput = null;
        }

        //window for scanning anny main gameplayObject : spaceship, earth, drones..(need to be open first)
        if (commandInput == "/scan open" && !commandRuning)
        {
            if (commandInput == "/scan open" && scanWindowIsOpen && !commandRuning)
            {
                //new text
                newCommand = Instantiate(commandLineErrorPrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = "[Scan] Window Already Open";

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

                //clear ipnut
                commandInput = null;
            }
            else
            {
                //new text
                newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
                newCommand.GetComponent<TextMeshProUGUI>().text = "Opening [Scan] window...";

                bottomPadding = bottomPadding + 10;
                commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

                //action
                computerScript.scanWindow.SetActive(true);
                scanWindowIsOpen = true;

                //clear ipnut
                commandInput = null;
            } 
        }
        if (commandInput == "/scan close" && !commandRuning)
        {
            //new text
            newCommand = Instantiate(commandLinePrefab, commandOutpoutPos);
            newCommand.GetComponent<TextMeshProUGUI>().text = "Closing [Scan] window...";

            bottomPadding = bottomPadding + 10;
            commandOutpout.GetComponent<VerticalLayoutGroup>().padding.bottom = bottomPadding;

            //action
            scanWindowIsOpen = false;

            //clear ipnut
            commandInput = null;
        }
    }

    private void UpdateEarthStatusWindow()
    {
        if (statsusWindowIsOpen)
        {
            foreach(EarthLayer earthLayer in earthLayers)
            {
                if(earthLayer.name == "core")
                {
                    if(earthLayer.isCreated == true)
                    {
                        earthHoloC.SetActive(true);
                        earthHoloNC.SetActive(false);
                        earthNotFound.SetActive(false);
                    }
                    else
                    {
                        earthHoloC.SetActive(false);
                        earthHoloNC.SetActive(true);
                        earthNotFound.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator CommandTimer()
    {
        yield return new WaitForSeconds(2);
        commandRuning = false;
    }
}
