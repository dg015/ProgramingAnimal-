using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleOnBool : MonoBehaviour
{
    public bool destroyCommand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOnComand();
    }

    public void DestroyOnComand()
    {
        if(destroyCommand )
        {
            Destroy(gameObject);
        }
    }
}
