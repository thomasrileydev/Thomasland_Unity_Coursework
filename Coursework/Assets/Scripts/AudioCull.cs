using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCull : MonoBehaviour {
    public AudioSource ForestAudio;
    public AudioClip ForestAudioClip;
    public AudioSource GrasslandAudio;
    public AudioClip GrasslandAudioClip;
    public AudioSource HillsAudio;
    public AudioClip HillsAudioClip;
    public AudioSource DesertAudio;
    public AudioClip DesertAudioClip;
    public AudioSource MountainousAudio;
    public AudioClip MountainousAudioClip;




    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ForestBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            ForestAudio.clip = ForestAudioClip;
            ForestAudio.Play();
            
        }
        if (other.gameObject.CompareTag("GrasslandBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            GrasslandAudio.clip = GrasslandAudioClip;
            GrasslandAudio.Play();
        }
        if (other.gameObject.CompareTag("HillsBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            HillsAudio.clip = HillsAudioClip;
            HillsAudio.Play();
        }
        if (other.gameObject.CompareTag("DesertBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            DesertAudio.clip = DesertAudioClip;
            DesertAudio.Play();
        }
        if (other.gameObject.CompareTag("MountainousBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.clip = MountainousAudioClip;
            MountainousAudio.Play();
        }


    }
   
    
}
