using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFacePlayer : MonoBehaviour
{
    // this script will let my text prompts look at the player
    public GameObject player;

    
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
