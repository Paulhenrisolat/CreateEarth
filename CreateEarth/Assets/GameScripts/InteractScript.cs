using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    UIscript uIscript;

    // Start is called before the first frame update
    void Start()
    {
        uIscript = GameObject.Find("Canvas").GetComponent<UIscript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            uIscript.interactBTN.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uIscript.interactBTN.SetActive(false);
        }
    }
}
