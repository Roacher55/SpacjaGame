using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : ObjectGame
{
    // Start is called before the first frame update
    float randomDirection;
    public GameObject playerSpace;
    float randomSpeed;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        InvokeRepeating("RandomDirection", 3, 5);
        InvokeRepeating("RandomScale", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        RandomMove();
    }

    void RandomMove()
    {
       

        if (randomDirection==0 && stopLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(leftEnd.transform.position.x, leftEnd.transform.position.y, transform.position.z), (speed +randomSpeed) * Time.deltaTime);
        }
        else if(randomDirection ==1 && stopRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(rightEnd.transform.position.x, rightEnd.transform.position.y, transform.position.z), (speed + randomSpeed) * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }
    }

    void RandomDirection()
    {
        randomDirection = Random.Range(0, 3);
    }

    protected new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.name == playerSpace.name)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("2");
        }
    }

    protected new void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.gameObject.name == playerSpace.name)
        {
            Debug.Log("4");
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void RandomScale()
    {
        transform.localScale = new Vector3(Random.Range(1.5f, 3.5f), transform.localScale.y, transform.localScale.z);    
        randomSpeed = Random.Range(-0.5f, 2);
    }


}
    
