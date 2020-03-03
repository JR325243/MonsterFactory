using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=cfjLQrMGEb4

public class CameraController : MonoBehaviour
{

    public float movespeed = 5;
    public float edgeboarderthiccness = 10;

    public Vector3 limits;

    void Update()
    {
        Vector3 CameraPos = transform.position; //vector three that stores the camera position

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - edgeboarderthiccness) //if w pressed OR the mouse y position (mesured from bottom left) is in the space equal to the thicc modifier from the top
        {
            CameraPos.z += movespeed * Time.deltaTime; //move up when W is pressed. movespeed dictates how much and time.deltatime means it doesnt change if its running at a high or low fps
        }

        if(Input.GetKey("s") || Input.mousePosition.y <= edgeboarderthiccness) //same again, but as its measured from the bottom it is simply mesuring if you're that distance from the bottom, not height - the thiccness
        {
            CameraPos.z -= movespeed * Time.deltaTime; 
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= Screen.width - edgeboarderthiccness)
        {
            CameraPos.x -= movespeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= edgeboarderthiccness)
        {
            CameraPos.x += movespeed * Time.deltaTime;
        }

        CameraPos.x = Mathf.Clamp(CameraPos.x, -limits.x, limits.x);
        CameraPos.z = Mathf.Clamp(CameraPos.z, -limits.y, limits.y);

        transform.position = CameraPos; //set current position to updated position
    }
}
