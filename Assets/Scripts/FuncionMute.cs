using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class FuncionMute : MonoBehaviour
{
    Toggle myToggle;
    public static float brightness = 1;
    
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        if(AudioListener.volume==0)
        {
            myToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            brightness = 0;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if (audioIn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }

    }

}
