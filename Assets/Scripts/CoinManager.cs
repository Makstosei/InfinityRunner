using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    float MoveSpeed;
    Vector3 coinLocation;
    GameObject Platformsref;

    private void Start()
    {
        Platformsref = GameObject.Find("Platforms");
        MoveSpeed = Platformsref.GetComponent<PlatformSpawner>().movementSpeed;
        coinLocation = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != null)
        {
           coinLocation.x -= 1 * MoveSpeed;
            this.transform.position = coinLocation;
        }



    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject,0);
        }
        


    }
}
