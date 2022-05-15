using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Button.GetComponent<Button>().Select();
        //PlaySound();
    }

    // Update is called once per frame
    void Update()
    {

    }
}