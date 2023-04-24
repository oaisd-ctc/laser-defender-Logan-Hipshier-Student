using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = .1f;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    

    void Start(){
        InitBounds();
    }
    
    void Update()
    {
        Move();
    }
   
   ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds= mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos= new Vector2();
        newPos.x=Mathf.Clamp(transform.position.x + delta.x, minBounds.x, maxBounds.x);
        newPos.y=Mathf.Clamp(transform.position.y + delta.y, minBounds.y, maxBounds.y);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
