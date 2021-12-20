using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] Platforms;
    public GameObject NextPlatform, LastPlatform;
    Vector3 NextSpawnLocation;
    public GameObject PlatformsReference;
    public List<GameObject> SpawnedPlatforms;
    int sessionNumber, sessionCounter;
    public int sessionLenght;
    public float movementSpeed;

    void Awake()
    {
        sessionNumber = 0;
        sessionCounter = 1;
        for (int i = 0; i < sessionLenght; i++)
        {
            NextSpawnPoint();
            RandomPlatform();
            SpawnNextPlatform();
        }
      
    }

    
    private void NextSpawnPoint()
    {
        if (LastPlatform != null)
        {
            NextSpawnLocation.x = LastPlatform.transform.Find("NextPlatform").position.x;
            NextSpawnLocation.y = 0 + Random.Range(-2, 2);



        }
        else

        {
            NextSpawnLocation.x = 0;
            NextSpawnLocation.y = 0;
            NextSpawnLocation.z = 0;

        }

    }

    private void RandomPlatform()
    {
        if (sessionNumber == 0)
        {
            if (sessionCounter < sessionLenght)
            {
                sessionCounter += 1;
                NextPlatform = Platforms[Random.Range(0, 3)];
            }
            else
            {
               
                sessionNumber = 1;
                sessionCounter = 1;
            }

        }
        else if (sessionNumber == 1)
        {
            if (sessionCounter < sessionLenght)
            {
                sessionCounter += 1;
                NextPlatform = Platforms[Random.Range(3, 6)];
            }
            else
            {
                
                sessionNumber = 2;
                sessionCounter = 1;
            }
        }
        else if (sessionNumber == 2)
        {
            if (sessionCounter < sessionLenght)
            {
                sessionCounter += 1;
                NextPlatform = Platforms[Random.Range(6, 9)];
            }
            else
            {
               
                sessionNumber = 0;
                sessionCounter = 1;
            }

        }



    }

    private void SpawnNextPlatform()
    {
        LastPlatform = Instantiate(NextPlatform, NextSpawnLocation, Quaternion.identity);
        LastPlatform.transform.parent = PlatformsReference.transform;
        SpawnedPlatforms.Add(LastPlatform);
    }

    public void SpawnNewNextPlatform()
    {
        NextSpawnPoint();
        RandomPlatform();
        SpawnNextPlatform();
        SpawnedPlatforms.Add(LastPlatform);
    }

}
