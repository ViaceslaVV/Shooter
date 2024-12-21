using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;
    public GameObject bulletPrefab;


    private Vector2 startingPosition;

    private bool movingForward = true;

    public Transform visionPoint; 
    public float visionDistance = 5f; 

    //padaryti didesnį moveDistance atstumą, pakeisti reikšmę Move Enemy (&&) pridededant terrain level
    void Start()
    {
        startingPosition = transform.position;

    }

    void Update()
    {
        if (!LookForPlayer())
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {
        if (movingForward)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-2, 2); 

            if (Vector2.Distance(startingPosition, transform.position) >= moveDistance) 
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(2, 2); 

            if (Vector2.Distance(startingPosition, transform.position) <= 0.1f)
            {
                movingForward = true;
            }
        }
    }

    bool LookForPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(visionPoint.position, Vector2.right, visionDistance);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            Shoot();
            return true; 
            
        }

        return false; 
    }
    void Shoot()
    {
        Vector3 shootingDirection = Vector2.right;

        GameObject obj = Instantiate(bulletPrefab, transform.position + shootingDirection, transform.rotation);
        

        
    }

}
