using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    public GameObject interactBTN;

    // Start is called before the first frame update
    void Start()
    {
        interactBTN = GameObject.FindGameObjectWithTag("interactBTN");
        interactBTN.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
