using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformscript : MonoBehaviour
{
    [Range(5,20)]
    public float junpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<playermovment>())
        {

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb.velocity.y <= 0)
            {
                Vector3 newvelocity = rb.velocity;
                newvelocity.y = junpForce;
                rb.velocity = newvelocity;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
