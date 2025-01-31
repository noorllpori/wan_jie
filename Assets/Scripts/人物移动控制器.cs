using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class 人物移动控制器 : MonoBehaviour
{
    public void 移动(Vector3 鼠标位置,float 移动速度)
    {
        if(Vector3.Distance(new Vector3(transform.position.x,transform.position.y,0),鼠标位置)<transform.GetComponent<BoxCollider2D>().size.x/2)return;
        Vector3 移动向量 = 鼠标位置 - transform.position;
        移动向量.z = 0;
        transform.DOMove(transform.position+移动向量.normalized*移动速度*Time.deltaTime, 0.2f);
    }
}
