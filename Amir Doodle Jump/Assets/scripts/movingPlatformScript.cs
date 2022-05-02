using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformScript : MonoBehaviour
{
    [Range(5, 20)]
    public float junpForce;
    bool isright = true;
    public Rigidbody rbplatform;
    Vector3 velocity = new Vector3();
    Vector3  startpos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        rbplatform = gameObject.GetComponent<Rigidbody>();
        startpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isright)
        {
            velocity = rbplatform.velocity;
            velocity.x += 3* Time.deltaTime;
            rbplatform.velocity = velocity;
            if (transform.position.x >= startpos.x + 2.5f)
            {
                velocity = rbplatform.velocity;
                velocity.x = 0;
                rbplatform.velocity = velocity;
                isright = false;
            }
        }
        else
        {
            velocity = rbplatform.velocity;
            velocity.x -= 3 * Time.deltaTime;
            rbplatform.velocity = velocity;
            if (transform.position.x <= startpos.x - 2.5f)
            {
                velocity = rbplatform.velocity;
                velocity.x = 0;
                rbplatform.velocity = velocity;
                isright = true;
            }
               
        }
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
                gameObject.GetComponent<AudioSource>().Play();
               
            }
        }
    }
}
