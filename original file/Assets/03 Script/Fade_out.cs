using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_out : MonoBehaviour
{
    public Animator animator;


    public void Fade_out_enable()
    {
        animator.SetTrigger("Fade_out_trigger");
    }

}



