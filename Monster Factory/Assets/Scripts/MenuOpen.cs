using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] //making the below gameobjects visible in the inspector without having to make them public
    GameObject contracts, lab, resources, raids, buttons;
    bool contractsOpen = false, labOpen = false, resourcesOpen = false, raidsOpen = false; // these bools are important for making sure only one panel is open at a time

    void Update()
    {

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
        Open(contracts, contractsOpen);
        contractsOpen = contractsOpen ? false : true;
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
            menu.transform.SetAsLastSibling();
            LeanTween.moveLocalX(menu, 710f, 2f).setEaseOutExpo();
            StartCoroutine(ButtonStop(menu, 2f));
        }
        else
        {
            LeanTween.moveLocalX(menu, 1200f, 0.5f).setEaseOutQuad();
            StartCoroutine(ButtonStop(menu, 0.5f));
            
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

    void ButtonParent(GameObject parent)
    {
        buttons.transform.SetParent(parent.transform);
        buttons.transform.localPosition = Vector3.zero;
    }

    IEnumerator ButtonStop(GameObject menu, float time)
    {
        menu.GetComponentInChildren<Button>().interactable = false;
        yield return new WaitForSeconds(time);
        menu.GetComponentInChildren<Button>().interactable = true;
    }
}
