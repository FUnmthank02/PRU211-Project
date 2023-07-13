using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    Scene scene1;
    private void Awake()
    {
        Instance = this;
        //if (Instance != null  && Instance != this)
        //{
        //    Destroy(this.gameObject);
        //    Instance = this;

        //}
        //else
        //{
        //    Instance = this;
        //}
       
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        scene1 = SceneManager.GetSceneByName("FirstScene");

        // Ki?m tra xem Scene có t?n t?i và ?ã n?p hoàn ch?nh ch?a
        if (scene1.IsValid() && scene1.isLoaded)
        {
            GameObject[] audioSources = scene1.GetRootGameObjects();

            foreach (GameObject audioSource in audioSources)
            {
                if (audioSource.gameObject.name == "Music Source")
                {
                    musicSource = audioSource.GetComponent<AudioSource>();


                    break;
                }
            }
        }
        else
        {
            Debug.Log("Scene 'Scene1' không t?n t?i ho?c ch?a ???c n?p.");
        }

        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();

        }
        else
        {
            Debug.Log("Sound not found");
        }
    }



    public void PlaySFX(string name)
    {
       
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s != null)
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
        else
        {
            Debug.Log("Sound not found");
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {

        
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
