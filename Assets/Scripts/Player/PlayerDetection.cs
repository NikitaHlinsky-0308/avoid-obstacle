using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Level;
using EventBusSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]private string nameSceneToFinish;

    private int unitsCount = 1;
    void Update()
    {
        // Detecting();
    }

    // private void Detecting()
    // {
    //     Collider[] detectedColliders = Physics.OverlapCapsule(transform.position - new Vector3(0,1,0), transform.position + new Vector3(0,1,0), 1);
    //
    //     for (int i = 0; i < detectedColliders.Length; i++)
    //     {
    //         
    //         if (detectedColliders[i].TryGetComponent(out DoorEventHandler doorHandler))
    //         {
    //             DoorEventHandler dooritself = detectedColliders[i].GetComponent<DoorEventHandler>();
    //             string doorId = dooritself.DoorId;
    //             
    //             EventBus.RaiseEvent<IDoorEvent>(h => h.HandleDoorInteraction(doorId));
    //
    //             // LoadSceneOnFinish(nameSceneToFinish);
    //         }
    //         
    //         // Door detecting
    //         // Trap detecting 
    //         
    //     }
    //     
    //     
    // }

    private void OnTriggerEnter(Collider other)
    {
        DoorEventHandler doorHandl = null;
        
        if ((doorHandl = other.GetComponent<DoorEventHandler>()) is not null)
        {
            EventBus.RaiseEvent<IDoorEvent>(h => h.HandleDoorInteraction(doorHandl.DoorId));
        }
            
        
        
        // Door detecting
        // Trap detecting 
    }
}
