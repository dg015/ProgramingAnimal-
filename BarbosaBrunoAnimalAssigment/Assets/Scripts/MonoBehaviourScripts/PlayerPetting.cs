using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPetting : MonoBehaviour
{

    [SerializeField] Transform orientation;
    [SerializeField] private float pettingDistance;
    [SerializeField] private LayerMask layer;

    [SerializeField] private Camera virtualCamera;

    [SerializeField] public bool IsPetting;
    // Update is called once per frame

    private void Start()
    {
        
        
    }
    void Update()
    {
        petting();
    }


    private void petting()
    {

        Vector3 direction = virtualCamera.transform.forward;

        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0, 1.25f), direction * pettingDistance, Color.yellow);
        if ( Physics.Raycast(transform.position + new Vector3(0,1.25f), direction , out hit, pettingDistance,layer))
        {
            
            if(Input.GetKey(KeyCode.E))
            {
                IsPetting = true;
            }
            else
            {
                IsPetting = false;
            }

        }
        else
        {
            IsPetting=false;
        }

    }


}
