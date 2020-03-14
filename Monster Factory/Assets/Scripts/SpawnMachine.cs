using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMachine : MonoBehaviour
{
    public GameObject prefab, container;
    GameObject grid;
    bool placementMode = false, occupied = false;

    void Awake()
    {
        grid = GameObject.Find("Grid"); //located the grid object so that its components can be accessed
        container = GameObject.Find("Machines");
    }

    public void EnablePlacement()
    {
        placementMode = true; //activating placement mode so that an object can be placed

        //sets the ghost object to an instance of the prefab selected
        grid.GetComponent<CustomGrid>().ghost = Instantiate(prefab, grid.GetComponent<CustomGrid>().ghost.transform.position, Quaternion.identity);
    }

    void Update()
    {
        //left click after button has been pressed
        if (Input.GetMouseButtonDown(0) && placementMode)
        {
            //checking the list of currently occupied grid squares to prevent overlap
            for(int i = 0; i < GameManager.OccupiedSpaces.Count; i++)
            {
                //counting through the vaules stored in the GAme Manager to find any that match the currently highlighted position
                if(GameManager.OccupiedSpaces[i] == grid.GetComponent<CustomGrid>().ghost.transform.position)
                {
                    occupied = true;
                }
            }

            //if the space doesn't have a machine in it and its on the plane that is defined in CustomGrid then the object is instatiated
            if (!occupied && grid.GetComponent<CustomGrid>().target.transform.position != -Vector3.one)
            {
                //using a function so that relevant data can be fed in regarding resources that need removing from the inventory
                Spawn();

                //storing all the machines in a container for convenience later - need to find a way of safely deleting these as they serve no further purpose
                grid.GetComponent<CustomGrid>().ghost.transform.SetParent(container.transform);
                grid.GetComponent<CustomGrid>().ghost.SetActive(false);

                //ends the placement of machines until the player presses the button again
                placementMode = false;
            }
            else
            {
                //storing all the machines in a container for convenience later - need to find a way of safely deleting these as they serve no further purpose
                grid.GetComponent<CustomGrid>().ghost.transform.SetParent(container.transform);
                grid.GetComponent<CustomGrid>().ghost.SetActive(false);

                placementMode = false;
                occupied = false;
            }

        }
        else if ((Input.GetMouseButtonDown(1) && placementMode)) //allows the player to cancel out of placement without placing a machine
        {
            //storing all the machines in a container for convenience later - need to find a way of safely deleting these as they serve no further purpose
            grid.GetComponent<CustomGrid>().ghost.transform.SetParent(container.transform);
            grid.GetComponent<CustomGrid>().ghost.SetActive(false);

            placementMode = false;
            occupied = false;
        }
    }

    public void Spawn()
    {
        //instantiating a permanent gameobject in the scene, as a child of the machines object for convenience
        Instantiate(prefab, grid.GetComponent<CustomGrid>().ghost.transform.position, Quaternion.identity, container.transform);
        //storing the location of the new object so others cannot be placed there
        GameManager.FillSpace(grid.GetComponent<CustomGrid>().ghost.transform.position);

        //insert code for resource removal here
    }
}
