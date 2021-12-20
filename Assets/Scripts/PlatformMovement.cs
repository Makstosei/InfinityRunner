using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    float MoveSpeed;
    Vector3 PlatformLocation;
    public GameObject Platformsref;



    private void Start()
    {
        Platformsref = GameObject.Find("Platforms");
        MoveSpeed = Platformsref.GetComponent<PlatformSpawner>().movementSpeed; 
        PlatformLocation = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != null)
        {
            PlatformLocation.x -= 1 * MoveSpeed;
            this.transform.position = PlatformLocation;
        }



    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Platforms").transform.GetComponent<PlatformSpawner>().SpawnNewNextPlatform();
            Destroy(gameObject, 10);
        }
        else if (other.tag == "Destroyer")
        {

            Destroy(gameObject);

        }


    }

}
