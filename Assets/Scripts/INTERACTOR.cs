using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class INTERACTOR : MonoBehaviour
{
    public LayerMask capaInteract = 6;
    UnityEvent onInteract;
    public Camera mainCamera;
    public AudioClip sonidoAgarrar;
    public AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       RaycastHit hit;
        Ray rayo = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            Debug.DrawRay(rayo.origin, rayo.direction * 200, Color.red);


        if (Physics.Raycast(rayo, out hit, 200, capaInteract))
        
        {
            if (hit.collider.GetComponent<INTERACTABLE>() != false)
            {
               onInteract = hit.collider.GetComponent<INTERACTABLE>().onInteract;
               
                if (Input.GetKey("mouse 0"))
                {

                    Debug.Log("aaa");
                    onInteract.Invoke();
                   Invoke("SonidoAgarrar", 0.1f);
                }
            }
            Debug.DrawLine(mainCamera.transform.position, mainCamera.transform.forward * 2, Color.blue);
            //Debug.DrawLine(transform.position, Camera.main.transform.forward - Camera.main.transform.forward * 2, Color.blue);
             //Debug.DrawLine(transform.position, Vector3.forward * 2, Color.blue);
            // Debug.DrawRay(camara.position, look, Color.green, 14);
        }
    }

    void SonidoAgarrar()
    {
        audioSource.PlayOneShot(sonidoAgarrar);
    }
}
