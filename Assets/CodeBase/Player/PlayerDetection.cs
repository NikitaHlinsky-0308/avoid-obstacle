using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]private string nameSceneToFinish;

    void Update()
    {
        Detecting();
    }

    private void Detecting()
    {
        Collider[] detectedColliders = Physics.OverlapCapsule(transform.position - new Vector3(0,1,0), transform.position + new Vector3(0,1,0), 1);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].CompareTag("Finish"))
            {
                LoadSceneOnFinish(nameSceneToFinish);
            }
            
            // Door detecting
            // Trap detecting 
            
        }
        
        
    }

    private static void LoadSceneOnFinish(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
