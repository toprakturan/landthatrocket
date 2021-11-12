using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    public bool isCollidePlayer = false;
    public static MeteorBehavior Current;

    void Start()
    {
        Current = this;
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            isCollidePlayer = true;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
