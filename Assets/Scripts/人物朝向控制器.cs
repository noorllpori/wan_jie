using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 人物朝向控制器 : MonoBehaviour
{
    public GameObject[] 人物十六面朝向;
    public void 更新人物朝向(Vector3 鼠标位置)
    {
        Vector3 方向向量 = 鼠标位置 - transform.position;
        float 角度 = Mathf.Atan2(方向向量.y, 方向向量.x) * Mathf.Rad2Deg;
        if (角度 < 0)角度 += 360;
        int 朝向编号 = Mathf.RoundToInt(角度 / 22.5f);
        if (朝向编号 == 16)朝向编号 = 0;
        for (int i = 0; i < 人物十六面朝向.Length; i++)
        {
            if (i == 朝向编号)
            {
                人物十六面朝向[i].SetActive(true);
            }
            else
            {
                人物十六面朝向[i].SetActive(false);
            }
        }
        Debug.Log(朝向编号);
    }
}
