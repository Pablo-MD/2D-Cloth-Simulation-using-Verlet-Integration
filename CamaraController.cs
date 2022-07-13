using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public float cameraSpeed;
    public float zoomSpeed;
    void Update()
    {

        //Create an Max and Min value for the zooming!
        transform.Translate(Input.GetAxisRaw("Horizontal") * cameraSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * cameraSpeed*Time.deltaTime,0);

        if (Input.GetAxisRaw("Mouse ScrollWheel")>0)
        {
            Camera.main.orthographicSize +=  zoomSpeed;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize -= zoomSpeed;
        }
    }
}
