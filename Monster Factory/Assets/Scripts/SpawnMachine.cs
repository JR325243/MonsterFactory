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
        if (Input.GetMouseButtonDown(0) && placementMode)
        {
            for(int i = 0; i < GameManager.OccupiedSpaces.Count; i++)
            {
                if(GameManager.OccupiedSpaces[i] == grid.GetComponent<CustomGrid>().ghost.transform.position)
                {
                    occupied = true;
                }
            }

            if (!occupied && grid.GetComponent<CustomGrid>().target.transform.position != -Vector3.one)
            {
                Spawn();
                grid.GetComponent<CustomGrid>().ghost.transform.SetParent(container.transform);
                grid.GetComponent<CustomGrid>().ghost.SetActive(false);
                placementMode = false;
            }
            else
            {
                grid.GetComponent<CustomGrid>().ghost.transform.SetParent(container.transform);
                grid.GetComponent<CustomGrid>().ghost.SetActive(false);

                placementMode = false;
                occupied = false;
            }

        }
        else if ((Input.GetMouseButtonDown(1) && placementMode))
        {
            grid.GetComponent<CustomGrid>().ghost.transform.SetParent(container.transform);
            grid.GetComponent<CustomGrid>().ghost.SetActive(false);

            placementMode = false;
            occupied = false;
        }
    }

    public void Spawn()
    {
        Instantiate(prefab, grid.GetComponent<CustomGrid>().ghost.transform.position, Quaternion.identity, container.transform);
        GameManager.FillSpace(grid.GetComponent<CustomGrid>().ghost.transform.position);

        //insert code for resource removal here
    }
}
