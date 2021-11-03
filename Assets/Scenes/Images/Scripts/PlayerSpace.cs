using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpace : ObjectGame
{
    
    public float spaceJump = 0.5f;
    public GameObject target;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void MoveToLeft()
    {
        if(stopLeft)
        { 
              transform.position = Vector3.MoveTowards(transform.position, leftEnd.transform.position, speed * Time.deltaTime);
            
        }
    }
    void MoveToRight()
    {
        
            if (stopRight && (rightEnd.transform.position.x -0.7f > transform.position.x + spaceJump))
            {
                transform.position = new Vector3(transform.position.x + spaceJump, transform.position.y, transform.position.z);
        }
        
    }
    private new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other.gameObject.name == rightEnd.name)
        {
            stopRight = false;
            transform.position = new Vector3(transform.position.x - spaceJump, transform.position.y, transform.position.z);
        }
        if (other.gameObject.name == target.name)
        {
            target.GetComponent<SpriteRenderer>().color = Color.green;
            GameHelper.scoreBool = true;
        }
    }

    private new void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.gameObject.name == target.name)
        {
            target.GetComponent<SpriteRenderer>().color = Color.red;
            GameHelper.scoreBool = false;
        }
    }


    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToRight();
        }
        else
        {
            MoveToLeft();
        }
        
    }
}
