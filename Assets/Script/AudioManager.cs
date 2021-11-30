using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonAudio;
    [SerializeField]
    private AudioSource hitAudio;
    [SerializeField]
    private AudioSource bgmAudio;
    [SerializeField]
    private AudioSource clearBgmAudio;
    [SerializeField]
    private AudioSource bossAudio;

    [SerializeField]
    private AudioClip menuSound;
    [SerializeField]
    private AudioClip buttonSound;
    [SerializeField]
    private AudioClip hitSound;
    [SerializeField]
    private AudioClip stage1_Bgm;
    [SerializeField]
    private AudioClip stage1_Clear_Bgm;
    [SerializeField]
    private AudioClip bossRushSound;

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
    public void PlayMenuButtonSound()
    {
        buttonAudio.clip = menuSound;
        buttonAudio.Play();
    }
    public void PlayButtonSound()
    {
        buttonAudio.clip = buttonSound;
        buttonAudio.Play();
    }
    public void PlayHitSound()
    {
        hitAudio.clip = hitSound;
        hitAudio.Play();
    }
    public void PlayStage1Bgm()
    {
        bgmAudio.clip = stage1_Bgm;
        bgmAudio.Play();
    }
    public void PlayStage1ClearBgm()
    {
        bgmAudio.Pause();
        clearBgmAudio.clip = stage1_Clear_Bgm;
        clearBgmAudio.Play();
    }
    public void PlayRushSound()
    {
        bossAudio.clip = bossRushSound;
        bossAudio.Play();
    }
}
