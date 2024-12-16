using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;         
    public float moveDistance = 3f;
 
    private Vector2 startingPosition; 
    
    private bool movingForward = true;
    private bool movingBackward = true;
    

    void Start()
    {
        
        startingPosition = transform.position;
    }

    void Update()
    {
        MoveEnemy();
        
        
    }

    void MoveEnemy()
    {
        
        if (movingForward)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime );


            



            if (Vector2.Distance(startingPosition, transform.position) >= moveDistance)
            {
                movingForward = false;
               
            }
        }
        
        else
        {


            transform.Translate(Vector2.left * speed * Time.deltaTime);
            


            if (Vector2.Distance(startingPosition, transform.position) <= 0.1f)
            {
                movingForward = true;
            }
        }
        

    }
}
