using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    Renderer meshrendererr;
    bool powertime;

    // Start is called before the first frame update
    void Start()
    {
        meshrendererr = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (powertime)
        {
            meshrendererr.material.SetFloat("Vector1_d470170df1ec4cd6a1f8141778f5510e", (meshrendererr.material.GetFloat("Vector1_d470170df1ec4cd6a1f8141778f5510e")) + 0.03f);
            if (meshrendererr.material.GetFloat("Vector1_d470170df1ec4cd6a1f8141778f5510e") >= 5)
                powertime = false;

        }

        else
        {
            meshrendererr.material.SetFloat("Vector1_d470170df1ec4cd6a1f8141778f5510e", (meshrendererr.material.GetFloat("Vector1_d470170df1ec4cd6a1f8141778f5510e")) - 0.03f);
            if (meshrendererr.material.GetFloat("Vector1_d470170df1ec4cd6a1f8141778f5510e") <= 0)
                powertime = true;
        }
    }
}
