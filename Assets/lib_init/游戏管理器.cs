using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 游戏管理器 : MonoBehaviour
{
    void Start()
    {
        MusicMgr.GetInstance().PlayBkMusic("金属 命运交响曲(3)_1_1");
    }
}
