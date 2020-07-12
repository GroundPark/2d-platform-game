using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class dialogue
{
    public string NPC_name;

    [TextArea(3,10)]
    // 최소, 최대 텍스트 에어리어
    public string[] sentences;

}
