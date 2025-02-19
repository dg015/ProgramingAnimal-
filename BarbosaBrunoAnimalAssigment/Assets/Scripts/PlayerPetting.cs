using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPetting : MonoBehaviour
{
    [SerializeField] public PetAT petScript;

    [SerializeField] Transform orientation;
    [SerializeField] private float pettingDistance;
    [SerializeField] private LayerMask layer;

    [SerializeField] private Camera virtualCamera;

    // Update is called once per frame

    private void Start()
    {
        petScript = GameObject.Find("Cat").GetComponent<PetAT>();
        Debug.Log(petScript.ToString());
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
            
            if(Input.GetKey(KeyCode.E) && petScript.petValue < petScript.petValueMax)
            {
                petScript.petValue += Time.deltaTime;
            }

        }

    }

}
