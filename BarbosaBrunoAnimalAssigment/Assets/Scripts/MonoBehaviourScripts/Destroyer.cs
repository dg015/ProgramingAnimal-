using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //destoy game object after 5 seconds
        Destroy(gameObject, 5);
    }
}
