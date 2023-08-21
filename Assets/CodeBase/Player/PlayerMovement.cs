using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerMovement : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float roadWidth;
    
    [Header("Controls")]
    [SerializeField] private float controlSpeed;
    
        
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;
  

    void Update()
    {
        MoveForward();
        MoveSide();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void MoveSide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            
            xScreenDifference /= Screen.width;
            xScreenDifference *= controlSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            
            position.x = Mathf.Clamp(position.x, -roadWidth / 2,
                roadWidth / 2);
            
            transform.position = position;
        }
    }
}
