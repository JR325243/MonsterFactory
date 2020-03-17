using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] //making the below gameobjects visible in the inspector without having to make them public
    GameObject contracts, lab, resources, raids;
    bool contractsOpen = false, labOpen = false, resourcesOpen = false, raidsOpen = false; // these bools are important for making sure only one panel is open at a time

    void Update()
    {
        //allows keys 1 2 3 4 to open the relevant menus if needed
        if (Input.GetKeyUp("1")){
            Contracts();
        }
        if (Input.GetKeyUp("2"))
        {
            Lab();
        }
        if (Input.GetKeyUp("3"))
        {
            Res();
        }
        if (Input.GetKeyUp("4"))
        {
            Raids();
        }
    }

    public void Contracts() //seperate functions required for each panel, I'm sure there's a more effective way but I couldn't find it
    {
        Open(contracts, contractsOpen); //runs the open function with the relevant gameobject and bool
        contractsOpen = contractsOpen ? false : true; //ternary operator toggles the bool value, bypassing an issue where the open function did not correctly set the bool value
    }

    public void Lab()
    {

        Open(lab, labOpen);
        labOpen = labOpen ? false : true;
    }

    public void Res()
    {
        Open(resources, resourcesOpen);
        resourcesOpen = resourcesOpen ? false : true;
    }

    public void Raids()
    {
        Open(raids, raidsOpen);
        raidsOpen = raidsOpen ? false : true;
    }

    void Open(GameObject menu, bool menuOpen)
    {
        if (!menuOpen) //if the panel isn't open this code will open it
        {
            menu.transform.SetAsLastSibling(); //positions this UI element at the bottom of the parent object so it is drawn last and shown on top of the other buttons
            LeanTween.moveLocalX(menu, 710f, 2f).setEaseOutExpo(); //uses the tween library to move the UI element into view with animation
            StartCoroutine(ButtonStop(menu, 2f)); //runs the coroutine responsible for disabling button functionality while the UI moves - this prevents the player from bugging out the UI
        }
        else
        {
            LeanTween.moveLocalX(menu, 1200f, 0.5f).setEaseOutQuad(); // moves the UI back off the screen with a tween animation
            StartCoroutine(ButtonStop(menu, 0.5f)); //suspends button functionality
            
        }
        
    }

    //This function is depreciated for now, leaving the code in case we bring it back
    void CloseAll(GameObject menu1, bool m1, GameObject menu2, bool m2, GameObject menu3, bool m3)
    {
        LeanTween.moveLocalX(menu1, 1200f, 2f).setEaseOutExpo();
        m1 = false;

        LeanTween.moveLocalX(menu2, 1200f, 2f).setEaseOutExpo();
        m2 = false;

        LeanTween.moveLocalX(menu3, 1200f, 2f).setEaseOutExpo();
        m3 = false;
    }

    IEnumerator ButtonStop(GameObject menu, float time)
    {
        menu.GetComponentInChildren<Button>().interactable = false; //disables button interactibility for any child objects in the menu
        yield return new WaitForSeconds(time); // waits for a variable amount of time - meaning this function can be reused across the game
        menu.GetComponentInChildren<Button>().interactable = true; //restores button function after the tweening has ended
    }
}
