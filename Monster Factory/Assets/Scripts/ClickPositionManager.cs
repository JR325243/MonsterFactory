using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour
{
    public static ClickPositionManager instance;

    public LayerMask clickMask;
    public static Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            mousePos = -Vector3.one;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast (ray, out hit, 100f, clickMask))
            {
                mousePos = hit.point;
            }

            //logging click position
            //Debug.Log(clickPosition);
        //}
    }
}
