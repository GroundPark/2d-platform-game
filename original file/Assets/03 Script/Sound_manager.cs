using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_manager : MonoBehaviour
{
    public static AudioClip jumpsound;
    public static AudioClip swordsound;
    public static AudioClip hammersound;
    public static AudioClip arrowsound;

    static AudioSource audioSrc;

    void Start()
    {
        jumpsound = Resources.Load<AudioClip>("Character_jump");
        swordsound = Resources.Load<AudioClip>("Character_swording");
        hammersound = Resources.Load<AudioClip>("Character_hammering");
        arrowsound = Resources.Load<AudioClip>("Character_arrowing");
        audioSrc = GetComponent<AudioSource>();
    }

   public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Character_jump":
                audioSrc.PlayOneShot(jumpsound);
                break;
            case "Character_swording":
                audioSrc.PlayOneShot(swordsound);
                break;
            case "Character_hammering":
                audioSrc.PlayOneShot(hammersound);
                break;
            case "Character_arrowing":
                audioSrc.PlayOneShot(arrowsound);
                break;
        }
    }

    // 각항목에 추가할것 : Sound_manager.PlaySound("Character_jump");
   


}
