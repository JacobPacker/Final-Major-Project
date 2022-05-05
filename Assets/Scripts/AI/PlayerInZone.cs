using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInZone : MonoBehaviour
{
    [HideInInspector]
    public bool playerInArea;
    // Start is called before the first frame update
    void Start()
    {
        playerInArea = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            print("player hit");
            playerInArea = true;
        }

        print(other.gameObject.tag);
    }

    void OnTriggerExit(Collider other)
    {


        if (other.tag == "Player")
        {
            print("player left");
            playerInArea = false;
        }

        print(other.gameObject.tag);
    }
}
