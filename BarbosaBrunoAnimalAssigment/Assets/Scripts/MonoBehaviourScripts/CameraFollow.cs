using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //set the location of the object to the location of the camera, the object this is attached to should hold the camera
        //so the camera will be at the correct posiiton
        transform.position = cameraPosition.position;
    }
}
