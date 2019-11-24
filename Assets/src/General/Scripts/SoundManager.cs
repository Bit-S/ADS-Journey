using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;

    public AudioClip[] audioClips;

    AudioSource audioSource;
    int index;

    void Start(){
        DestroyIfAlreadyExists();
        DontDestroyOnLoad(gameObject);
        audioClips = new AudioClip[4]{clip1, clip2, clip3, clip4};
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if(!audioSource.isPlaying)
            ChangeSongAndPlay();
    }

    public void ChangeSongAndPlay(){
        index = audioSource.clip == null ? 
                Random.Range(0,4) : index == 3 ? 
                                    0 : index + 1;
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    void DestroyIfAlreadyExists(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
            Destroy(gameObject);
        
    }
}
