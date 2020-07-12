using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthCnt2 : MonoBehaviour
{
    public GameObject Heart2;
    SpriteRenderer render;
    private PlayerController chamgo;

    private void Start()
    {
        chamgo = FindObjectOfType<PlayerController>();
        render = GetComponent<SpriteRenderer>();
        Alpha255();
    }

    private void Alpha255()
    {
        render.color = new Color32(255, 255, 255, 255);
    }

    private void Alpha0()
    {
        render.color = new Color32(255, 255, 255, 0);
    }




    private void Update()
    {
        switch (chamgo.Health)
        {
            case 3:
                Alpha255();
                break;
            case 2:
                Alpha255();
                break;
            case 1:
                Alpha0();
                break;
            case 0:
                Alpha0();
                break;
        }
    }
}
