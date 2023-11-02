using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region SINGLETON
    public static AudioManager Singleton;

    private void Awake()
    {
        if(Singleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion

    //[SerializeField] AudioClip[] soundEffects;
    [SerializeField] Sons[] sons;

    private List<AudioSource> audioSources = new List<AudioSource>();


    public void PlaySons(string nomDuSon)
    {
        foreach(Sons son in sons)
        {
            if(son.nomDuClip == nomDuSon)
            {
                PlaySons(son.audioClip);
            }
        }
        /*
        switch(nomDuSon)
        {
            case "fireball":
                //Play Fireball;
                PlaySons(0);
                break;
            case "iceball":
                //Play Iceball
                PlaySons(1);
                break;
        }*/
    }

   /* public void PlaySons(int soundIndex)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundEffects[soundIndex];
                audioSource.Play();
                return;
            }
        }

        AudioSource source = CreateNewAudioSource();
        source.clip = soundEffects[soundIndex];
        source.Play();
    }*/

    public void PlaySons(AudioClip soundClip)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
                return;
            }
        }

        AudioSource source = CreateNewAudioSource();
        source.clip = soundClip;
        source.Play();
    }

    private AudioSource CreateNewAudioSource()
    {
        //Creer un nouveau objet
        GameObject GO = new GameObject();
        GO.name = "AudioSource";
        GO.transform.parent = this.transform;

        //Ajoute un AudioSource au objet et au liste
        AudioSource source = GO.AddComponent<AudioSource>();
        audioSources.Add(source);

        return source;
    }
}

[System.Serializable]
public struct Sons
{
    public string nomDuClip;
    public AudioClip audioClip;
}
