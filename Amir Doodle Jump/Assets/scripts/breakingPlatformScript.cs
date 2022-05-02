using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakingPlatformScript : MonoBehaviour
{
    [Range(5, 20)]
    public float junpForce;
    public GameObject leftCube;
    public GameObject rightCube;
    
    
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
        if (other.GetComponent<playermovment>())
        {

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb.velocity.y <= 0)
            {
                Vector3 newvelocity = rb.velocity;
                newvelocity.y = junpForce;
                rb.velocity = newvelocity;
                breakPlatform();
                gameObject.GetComponent<AudioSource>().Play();

            }
        }
    }
    public void breakPlatform()
    {
        Rigidbody leftRB = leftCube.GetComponent<Rigidbody>();
        Rigidbody rightRB = rightCube.GetComponent<Rigidbody>();
        leftRB.useGravity = true;
        leftRB.AddForce(-15, -5, 0);
        rightRB.useGravity = true;
        rightRB.AddForce(15, -5, 0);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
