using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] //making the below gameobjects visible in the inspector without having to make them public
    GameObject contracts, lab, resources, raids, buttons;
    bool contractsOpen = false, labOpen = false, resOpen = false, raidsOpen = false; // these bools are important for making sure only one panel is open at a time

    void Update()
    {

        if(contractsOpen || labOpen || resOpen || raidsOpen) //if any of the panels are in the open position all of the buttons will move with it
        {
            buttons.transform.localPosition = new Vector3(720f, 0f, 0f); //relocates the gameobject parenting the buttons
        }
        else
        {
            buttons.transform.localPosition = new Vector3(1200f, 0f, 0f); //moves the buttons to the edge of the screen
        }
    }

    public void Contracts() //seperate functions required for each panel, I'm sure there's a more effective way but I couldn't find it
    {
        if (!contractsOpen) //if the panel isn't open this code will open it
        {
            contracts.transform.localPosition = new Vector3(720f, 0f, 0f); //moving the panel into view
            contractsOpen = true; //flagging the panel as open so the button will close it when pressed again

            //this section of code closes and flags as closed all of the other panels so that only one is open at a time
            lab.transform.localPosition = new Vector3(1200f, 0f, 0f);
            labOpen = false;
            resources.transform.localPosition = new Vector3(1200f, 0f, 0f);
            resOpen = false;
            raids.transform.localPosition = new Vector3(1200f, 0f, 0f);
            raidsOpen = false;
        }
        else
        {
            contracts.transform.localPosition = new Vector3(1200f, 0f, 0f); //if the panel is open this will move it out of sight
            contractsOpen = false; //flagging the panel as closed
        }
    }

    public void Lab()
    {

        if (!labOpen)
        {
            lab.transform.localPosition = new Vector3(720f, 0f, 0f);
            labOpen = true;

            contracts.transform.localPosition = new Vector3(1200f, 0f, 0f);
            contractsOpen = false;
            resources.transform.localPosition = new Vector3(1200f, 0f, 0f);
            resOpen= false;
            raids.transform.localPosition = new Vector3(1200f, 0f, 0f);
            raidsOpen = false;
        }
        else
        {
            lab.transform.localPosition = new Vector3(1200f, 0f, 0f);
            labOpen = false;
        }
    }

    public void Res()
    {
        if (!resOpen)
        {
            resources.transform.localPosition = new Vector3(720f, 0f, 0f);
            resOpen = true;

            contracts.transform.localPosition = new Vector3(1200f, 0f, 0f);
            contractsOpen = false;
            lab.transform.localPosition = new Vector3(1200f, 0f, 0f);
            labOpen = false;
            raids.transform.localPosition = new Vector3(1200f, 0f, 0f);
            raidsOpen = false;
        }
        else
        {
            resources.transform.localPosition = new Vector3(1200f, 0f, 0f);
            resOpen = false;
        }
    }

    public void Raids()
    {
        if (!raidsOpen)
        {
            raids.transform.localPosition = new Vector3(720f, 0f, 0f);
            raidsOpen = true;

            contracts.transform.localPosition = new Vector3(1200f, 0f, 0f);
            contractsOpen = false;
            lab.transform.localPosition = new Vector3(1200f, 0f, 0f);
            labOpen = false;
            resources.transform.localPosition = new Vector3(1200f, 0f, 0f);
            resOpen = false;
        }
        else
        {
            raids.transform.localPosition = new Vector3(1200f, 0f, 0f);
            raidsOpen = false;
        }
    }
}
