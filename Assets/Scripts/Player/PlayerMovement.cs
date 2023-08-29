using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float roadWidth;
    [SerializeField] private float inputTimeRate = 0.1f;
    [SerializeField] private Transform targetFinish;
    
    [Header("Controls")]
    [SerializeField] private float controlSpeed;
    
        
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private Vector3 vel;
    private Vector3 prevMousePosition = Vector3.zero;
    

    
    void Start()
    {
        
        StartCoroutine(Loop());
    }

    
    
    private void MoveForward()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void MoveSide()
    {

        // var delta =  MouseDelta();
        
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        
        // if (Input.GetMouseButtonUp(0))
        // {
        //     targetFinish.position = new Vector3(0, targetFinish.position.y, targetFinish.position.z);
        // }

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

            // var posX = Mathf.Clamp(transform.position.x + delta.x, -1, 1) * roadWidth;
            //
            // targetFinish.position = new Vector3(posX, targetFinish.position.y, targetFinish.position.z);

            
            
        }
    }

    private Vector2 MouseDelta()
    {
        Vector3 delta = Input.mousePosition - prevMousePosition;
        
        prevMousePosition = Input.mousePosition;
        
        return new Vector2(delta.x, delta.y);
    }

    IEnumerator Loop()
    {
        while (true)
        {
            MoveForward();
            MoveSide();

            // transform.position = Vector3.SmoothDamp(
            //     this.transform.position, 
            //     targetFinish.position, 
            //     ref vel, 
            //     speed);

            yield return new WaitForSeconds(inputTimeRate);
        }
    }
    
}
