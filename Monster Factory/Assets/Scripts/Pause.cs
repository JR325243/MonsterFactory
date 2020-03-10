using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //[SerializeField]
    public GameObject pauseMenu, optionsMenu;
    bool pauseOpen = false, optionsOpen = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Y Pressed");
            PauseButton();
        }
    }

    public void OptionsButton()
    {
        if (!optionsOpen)
        {
            optionsMenu.transform.localPosition = new Vector3(0f, 0f, 0f); //moving the panel into view
            optionsOpen = true;
        }
        else
        {
            optionsMenu.transform.localPosition = new Vector3(0f, -1250f, 0f); //moving the panel into view
            optionsOpen = false;
        }
    }

    public void PauseButton()
    {
        if (!pauseOpen)
        {
            pauseMenu.transform.localPosition = new Vector3(0f, 0f, 0f); //moving the panel into view
            pauseOpen = true;
        }
        else
        {
            pauseMenu.transform.localPosition = new Vector3(0f, -1250f, 0f); //moving the panel into view
            pauseOpen = false;
        }
    }
}
