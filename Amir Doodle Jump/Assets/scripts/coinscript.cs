using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<playermovment>())
        {
            other.gameObject.GetComponent<playermovment>().scorecoins += 100;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
