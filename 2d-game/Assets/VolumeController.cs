using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{

    public float volume = 0.5f;
    public float minVolume = 0.0f;
    public float maxVolume = 1.0f;

    private AudioSource myAudio;
    
    void Start(){
        myAudio = this.GetComponent<AudioSource>();
    }

    void Update(){
        myAudio.volume = volume;
    }

    void OnGUI(){
        GUI.Label (new Rect (100,30,100,30),"Volume");
        volume = GUI.HorizontalSlider(new Rect (100,60,100,30),volume, minVolume, maxVolume);
    }
}
