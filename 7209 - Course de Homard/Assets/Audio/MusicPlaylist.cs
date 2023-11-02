using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlaylist : MonoBehaviour
{

    [SerializeField] private AudioClip[] playlist;

    private AudioSource audioSource;
    private int musicIndex = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        //PlayNextMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextMusic();
        }

    }

    private void PlayNextMusic()
    {
        audioSource.clip = playlist[musicIndex++];
        audioSource.Play();

        musicIndex %= playlist.Length;

        /*if(musicIndex >= playlist.Length)
        {
            musicIndex = 0;
        }*/
    }
}
