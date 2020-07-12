using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public float offsetX = 1f;
    public float offsetY = 2f;
    public float offsetZ = 0f;

    Vector3 GUIpos;
    private GameObject GetplayerPos;

    private void Start()
    {
        GetplayerPos = GameObject.FindGameObjectWithTag("Player");
    }
    //Player태그가진 캐릭터 vector3 pos가져와서 UI vector3에 각각 넣어줌 = UI가 플레이어 따라감
    //Flip 메소드때문에 따로 생성함

    private void Update()
    {
        GUIpos.x = GetplayerPos.transform.position.x + offsetX;
        GUIpos.y = GetplayerPos.transform.position.y + offsetY;
        GUIpos.z = GetplayerPos.transform.position.z + offsetZ;

        transform.position = GUIpos;
    }
}

