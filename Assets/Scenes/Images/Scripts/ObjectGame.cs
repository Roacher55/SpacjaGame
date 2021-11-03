using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightEnd;
    public GameObject leftEnd;
    public float speed;
    protected bool stopLeft = true;
    protected bool stopRight = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == rightEnd.name)
        {
            stopRight = false;
        }
        if (other.gameObject.name == leftEnd.name)
        {
            stopLeft = false;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == rightEnd.name)
        {
            stopRight = true;
        }
        if (other.gameObject.name == leftEnd.name)
        {
            stopLeft = true;
        }
    }

    protected void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.name == rightEnd.name)
        {
            Debug.Log("Dziala Stay");
            stopRight = false;
        }
        if (other.gameObject.name == leftEnd.name)
        {
            Debug.Log("Dziala Stay");
            stopLeft = false;
        }
    }


}
