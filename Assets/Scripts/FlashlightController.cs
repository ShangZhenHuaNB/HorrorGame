using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject flashlight;
    private bool isActive;
    private AudioSource flashlightAudio;
    public AudioClip flashlightAudioClip;
    private Light flashlightlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlightlight = GetComponent<Light>();
        flashlightlight.intensity=0;
        isActive = false;
        flashlightAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flashlighOnOff()
    {
        if (isActive)
        {
            flashlightAudio.PlayOneShot(flashlightAudioClip,1);
            flashlightlight.intensity = 0;
            isActive = false;
        } else
        {
            flashlightAudio.PlayOneShot(flashlightAudioClip,1);
            flashlightlight.intensity = 2;
            flashlight.SetActive(true);
            isActive = true;
        }
       
        

    }
}
