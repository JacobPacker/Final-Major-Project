using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen = false;
    private Animator doorAnim;
    public GameObject door;

    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!isOpen)
        {
            isOpen = true;
            doorAnim.Play("OtherOpen", 0, 0.0f);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (isOpen)
        {
            isOpen = false;
            doorAnim.Play("OtherClose", 0, 0.0f);
        }
    }

    void Update()
    {
        if(isOpen)
        {
            Debug.Log("pressed");
        }
    }
}
