using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource theAudio;

    [SerializeField]
    private AudioClip menuSound;
    [SerializeField]
    private AudioClip buttonSound;

    public static AudioManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }
    public void PlayMenuButtonSound()
    {
        theAudio.clip = menuSound;
        theAudio.Play();
    }
    public void PlayButtonSound()
    {
        theAudio.clip = buttonSound;
        theAudio.Play();
    }
}
