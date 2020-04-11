using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script changes the background audio track when Player crosses into another biome. Each time this
 * happens, it cuts all background audio and then plays the desired one. I could have probably have improved the
 * efficiency of this given more time but it works.
 */

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

    public void Start()
    {
        ForestAudio.clip = ForestAudioClip;
        GrasslandAudio.clip = GrasslandAudioClip;
        HillsAudio.clip = HillsAudioClip;
        DesertAudio.clip = DesertAudioClip;
        MountainousAudio.clip = MountainousAudioClip;
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ForestBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            ForestAudio.Play();
            
        }
        if (other.gameObject.CompareTag("GrasslandBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            GrasslandAudio.Play();
        }
        if (other.gameObject.CompareTag("HillsBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            HillsAudio.Play();
        }
        if (other.gameObject.CompareTag("DesertBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            DesertAudio.Play();
        }
        if (other.gameObject.CompareTag("MountainousBoundary"))
        {
            ForestAudio.Stop();
            GrasslandAudio.Stop();
            HillsAudio.Stop();
            DesertAudio.Stop();
            MountainousAudio.Stop();
            MountainousAudio.Play();
        }


    }
   
    
}
