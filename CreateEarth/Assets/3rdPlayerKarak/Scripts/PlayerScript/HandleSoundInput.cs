using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSoundInput : MonoBehaviour
{
    void Update()
    {
        SoundActions();
    }

    private void SoundActions()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //FindObjectOfType<AudioManager>().Play("PlayerWalk");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
        if (Input.GetKeyDown(KeyCode.D))
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
    }
}
