using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=eUFwxK9Z9aw&list=PL-axpC8Nx3Wl8c5OWjge-1b0cqfX2LOcw&index=8

[ExecuteInEditMode]
public class CustomGrid : MonoBehaviour
{
    public GameObject target, ghost;
    public float gridSize;
    public LayerMask clickMask;
    public static Vector3 mousePos;

    Vector3 truePos;

    private void Update()
    {
        //if the mouse isn't over the right plane the placement location will default to this location (-1,-1,-1)
        mousePos = -Vector3.one;

        //Ray sets a relative position in the world space from the on screen mouse position (I think?)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //when the ray intersects with the plane on the Click Check layer this code is executed
        if (Physics.Raycast(ray, out hit, 100f, clickMask))
        {
            // defines the mouse position in world space
            mousePos = hit.point;
        }

        //setting the position of the target object to the mouse / this could probably be bypassed but works fine
        target.transform.position = mousePos;
    }

    void LateUpdate()
    {
        truePos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize; //sets the x value of the vector 3 to the grid position nearest the position of the target
        truePos.y = 0.5f; //keeps the object fully above the floor
        truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize; //sets the z value of the vector 3 to the grid position nearest the position of the target

        ghost.transform.position = truePos; //sets the position of the object after the correct grid position have been defined
    }

    
}
