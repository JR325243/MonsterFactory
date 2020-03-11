using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    
    public GameObject menu, pause, options;
    bool pauseOpen = false, optionsOpen = false;

    private void Start()
    {
        menu.transform.localScale = Vector3.zero;
        pause.transform.localScale = Vector3.one;
        options.transform.localScale = Vector3.zero;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseButton();
        }
    }

    public void OptionsButton()
    {
        StartCoroutine(Wait());
    }


    public void PauseButton()
    {
        if (!pauseOpen)
        {
            LeanTween.scale(menu, Vector3.one, 1f).setEaseInOutQuint();
            pauseOpen = true;
        }
        else
        {
            LeanTween.scale(menu, Vector3.zero, 1f).setEaseInOutQuint();
            pauseOpen = false;
        }
    }

    IEnumerator Wait()
    {
        if (!optionsOpen)
        {
            LeanTween.scale(pause, Vector3.zero, 0.5f).setEaseInOutQuint();
            yield return new WaitForSeconds(0.5f);
            LeanTween.scale(options, Vector3.one, 0.5f).setEaseInOutQuint();
            optionsOpen = true;
        }
        else
        {
            LeanTween.scale(options, Vector3.zero, 0.5f).setEaseInOutQuint();
            yield return new WaitForSeconds(0.5f);
            LeanTween.scale(pause, Vector3.one, 0.5f).setEaseInOutQuint();
            optionsOpen = false;
        }
    }
}
