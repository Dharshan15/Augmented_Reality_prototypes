using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform camera;
    /*public GameObject explosion;
    public AudioSource sound;*/
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void Shooter()
    {
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            Destroy(hit.transform.gameObject);
        }
    }
}
