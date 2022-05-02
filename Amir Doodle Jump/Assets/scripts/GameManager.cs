using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 spawnPosition;
    public Vector3 coinspawnpos;
    public Vector3 onlycoinspawnpos;
    public GameObject[] platformsLevel1;
    public GameObject[] platformsLevel2;
    public GameObject[] platformsLevel3;
    public Transform playerTransform;
    public GameObject [] coinsmon;
    public GameObject coins;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            createPlatform1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player").GetComponent<playermovment>().score <= 1000)
        {
            if (playerTransform.position.y > onlycoinspawnpos.y - 15)
            {
               createcoind();
            }
        }


        if (GameObject.Find("player").GetComponent<playermovment>().score >= 1000)
        {
            if (playerTransform.position.y > coinspawnpos.y - 15)
            {
                createcoinsmon();
            }
        }




        if (GameObject.Find("player").GetComponent<playermovment>().score <= 1000)
        {
            if (playerTransform.position.y > spawnPosition.y - 15)
                createPlatform1();

        }
        if (GameObject.Find("player").GetComponent<playermovment>().score > 1000 && GameObject.Find("player").GetComponent<playermovment>().score <= 2000)
        {
            if (playerTransform.position.y > spawnPosition.y - 15)
                createPlatform2();

        }
        if (GameObject.Find("player").GetComponent<playermovment>().score >= 2000)
        {
            if (playerTransform.position.y > spawnPosition.y - 15)
                createPlatform3();

        }
    }

    void createcoind()
    {
        float randx = Random.Range(-4.5f, 4.5f);
        float randy = Random.Range(2f, 4.5f) ;
        onlycoinspawnpos.y += randy;
        onlycoinspawnpos.x = randx;
        Instantiate(coins, onlycoinspawnpos, Quaternion.identity);
    }
    void createPlatform1()
    {
        int wich = Random.Range(0, platformsLevel1.Length);
        float randx = Random.Range(-4.5f, 4.5f);
        float randy = Random.Range(2f, 4.5f);
        spawnPosition.y += randy;
        spawnPosition.x = randx;
        Instantiate(platformsLevel1[wich], spawnPosition, Quaternion.identity);
    }

    void createcoinsmon()
    {
        int wich2 = Random.Range(0, coinsmon.Length);
        float randomx = Random.Range(-1f, 4.5f);
        float randomy = Random.Range(2f, 4.5f);
        coinspawnpos.y += randomy;
        coinspawnpos.x = randomx;
        Instantiate(coinsmon[wich2], coinspawnpos+ playerTransform.position, Quaternion.identity);
    }

    void createPlatform2()
    {
        int wich = Random.Range(0, platformsLevel1.Length);
        float randx = Random.Range(-4.5f, 4.5f);
        float randy = Random.Range(2f, 4.5f);
        spawnPosition.y += randy;
        spawnPosition.x = randx;
        Instantiate(platformsLevel2[wich], spawnPosition, Quaternion.identity);
    }

    void createPlatform3()
    {
        int wich = Random.Range(0, platformsLevel2.Length);
        float randx = Random.Range(-4.5f, 4.5f);
        float randy = Random.Range(2f, 4.5f);
        spawnPosition.y += randy;
        spawnPosition.x = randx;
        Instantiate(platformsLevel3[wich], spawnPosition, Quaternion.identity);
    }
}