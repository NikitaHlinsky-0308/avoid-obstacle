using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteracion : MonoBehaviour
{
    [Header("Elements")] 
    [SerializeField] private string nameSceneToLoad;

    [SerializeField] private GameObject panel;

    public void MoveToScene()
    {
        SceneManager.LoadScene(nameSceneToLoad);
    }

    public void ShowPanel()
    {
        
    }
    
    public void HidePanel()
    {
        
    }
}
