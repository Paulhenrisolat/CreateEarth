using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    public GameObject interactBTN;
    private GameObject menuScreen;
    private bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        interactBTN = GameObject.FindGameObjectWithTag("interactBTN");
        menuScreen = GameObject.Find("MenuScreen");

        menuScreen.SetActive(false);
        interactBTN.SetActive(false);
        menuOpen = false;
    }

    private void Update()
    {
        OpenMenu();
    }

    //Open and Close pause menu with EscapeBTN
    private void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuOpen == false)
        {
            menuScreen.SetActive(true);
            menuOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuOpen == true)
        {
            menuScreen.SetActive(false);
            menuOpen = false;
        }
    }

    //Close pause menu with CloseBTN "x"
    public void CloseMenu()
    {
        menuScreen.SetActive(false);
        menuOpen = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Option()
    {

    }

    public void QuitGame()
    {

    }
}
