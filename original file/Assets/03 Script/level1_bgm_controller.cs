using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_bgm_controller : MonoBehaviour
{
 
    public AudioClip level_bgm;
    public AudioSource audioSrc;

    void Start()
    {
        audioSrc.clip = level_bgm;
        PlaySound();
    }

    public void PlaySound()
    {
        audioSrc.loop = true;
        audioSrc.Play();
    }

    public void stopbgm()
    {
        audioSrc.loop = false;
        audioSrc.Stop();
    }
    // 각항목에 추가할것 : Sound_manager.PlaySound("Character_jump");
}

