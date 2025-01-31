using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 人物控制器 : MonoBehaviour
{
    public float 移动速度 = 50f;
    public 人物朝向控制器 人物朝向控制器;
    public 人物移动控制器 人物移动控制器;
    void Update()
    {
        Vector3 鼠标位置 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        鼠标位置.z = 0;
        人物朝向控制器.更新人物朝向(鼠标位置);
        if (Input.GetMouseButton(1))
        {
            人物移动控制器.移动(鼠标位置, 移动速度);
        }
    }
}
