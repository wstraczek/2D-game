using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public float volume = 0.5f;
    public float minVolume = 0.0f;
    public float maxVolume = 1.0f;
    

    private AudioSource myAudio;
    
    void Start(){
        myAudio = this.GetComponent<AudioSource>();
        myAudio.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(delegate { ChangeValue(); });
    }

    public void ChangeValue() {
        myAudio.volume = volumeSlider.value;
    }

}
