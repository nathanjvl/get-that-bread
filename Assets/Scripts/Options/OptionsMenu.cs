using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("First") != 1)
        {
            PlayerPrefs.SetInt("First", 1);
            PlayerPrefs.SetFloat("Volume", 1);
        }

        musicVolume.value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float v)
    {
        PlayerPrefs.SetFloat("Volume", musicVolume.value);
    }
}
