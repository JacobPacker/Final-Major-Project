using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class FinalDoorScript : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen = false;
    private Animator doorAnim;
    private Animator doorAnim2;
    private Animator godsAnim;
    public GameObject door;
    public GameObject door2;
    public GameObject godsTransendance;
    public AudioSource music;
    public AudioSource fearOfGod;
    public Light[] lights;

    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
        doorAnim2 = door2.GetComponent<Animator>();
        godsAnim = godsTransendance.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (!isOpen)
            {
                isOpen = true;
                doorAnim.Play("Final door", 0, 0.0f);
                doorAnim2.Play("Final Other door", 0, 0.0f);
                music.Pause();
                foreach (Light obj in lights)
                {
                    obj.enabled = false;
                }
                RenderSettings.ambientLight = Color.black;
                fearOfGod.Play();
                godsAnim.Play("GodSpawn", 0, 0.0f);
            }
        }
    }
    void Update()
    {
        if (isOpen)
        {
            Debug.Log("Activated");
        }
    }
}
