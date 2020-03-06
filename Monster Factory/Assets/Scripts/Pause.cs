using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool open = false;
    public void PauseButton()
    {
        if (!open)
        {
            gameObject.SetActive(true);
            open = true;
        }
        else
        {
            gameObject.SetActive(false);
            open = false;
        }
    }
}
