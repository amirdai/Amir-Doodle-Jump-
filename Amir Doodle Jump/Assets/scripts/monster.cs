using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public GameObject lostcanvas;
    Vector3 velocity = new Vector3();
    public Rigidbody rbmonster;
    bool isright = true;
    // Start is called before the first frame update
    void Start()
    {
        rbmonster = gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<playermovment>())
        {
            lostcanvas.SetActive(true);
            other.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<AudioSource>().Play();

        }
    }
    
       
   
    // Update is called once per frame
    void Update()
    {
        if (isright)
        {
            velocity = rbmonster.velocity;
            velocity.x += 3 * Time.deltaTime;
            rbmonster.velocity = velocity;
            if (transform.position.x >= 0.5f)
                isright = false;
        }
        else
        {
            velocity = rbmonster.velocity;
            velocity.x -= 3 * Time.deltaTime;
            rbmonster.velocity = velocity;
            if (transform.position.x <= -0.5)
                isright = true;
        }
    }
}
