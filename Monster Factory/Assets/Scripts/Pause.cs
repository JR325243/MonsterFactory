using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    
    public GameObject menu, pause, options;
    bool pauseOpen = false, optionsOpen = false;

    private void Start()
    {
        //ensures all menus are correctly scaled to begin with
        menu.transform.localScale = Vector3.zero;
        pause.transform.localScale = Vector3.one;
        options.transform.localScale = Vector3.zero;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) //allows escape button to be used to acces the menu
        {
            PauseButton();
        }
    }

    public void OptionsButton() //placing the coroutine inside of a fuction is necessary for accessing the code from button components
    {
        StartCoroutine(Wait());
    }


    public void PauseButton()
    {
        if (!pauseOpen)
        {
            LeanTween.scale(menu, Vector3.one, 1f).setEaseInOutQuint(); // resizes the element from 0,0,0 to 1,1,1 with animation
            pauseOpen = true;
        }
        else
        {
            LeanTween.scale(menu, Vector3.zero, 1f).setEaseInOutQuint(); //returns the element to 0,0,0
            pauseOpen = false;
            if (optionsOpen) //if the player closes the pause menu while in the options section the game will return to the default pause menu when its next opened
            {
                StartCoroutine(Wait()); //runs the open options coroutine
            }
            
        }
    }

    IEnumerator Wait()
    {
        if (!optionsOpen)
        {
            LeanTween.scale(pause, Vector3.zero, 0.5f).setEaseInOutQuint(); //shrinks the pause menu contents
            yield return new WaitForSeconds(0.5f); //prevents the two tweens from overlapping in an ugly way
            LeanTween.scale(options, Vector3.one, 0.5f).setEaseInOutQuint(); // embiggens the options menu contents
            optionsOpen = true;
        }
        else
        {
            // exact opposite of the above
            LeanTween.scale(options, Vector3.zero, 0.5f).setEaseInOutQuint();
            yield return new WaitForSeconds(0.5f);
            LeanTween.scale(pause, Vector3.one, 0.5f).setEaseInOutQuint();
            optionsOpen = false;
        }
    }
}
