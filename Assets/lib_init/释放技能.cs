using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Reflection;

public class 释放技能 : MonoBehaviour
{
    //单例模式
    private static 释放技能 _instance;
    public static 释放技能 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindFirstObjectByType<释放技能>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("释放技能");
                    _instance = obj.AddComponent<释放技能>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }
    public Dictionary<string, string> 技能字典 = new Dictionary<string, string>()
    {
        {"asd","技能1" },
        {"blueboom","技能2"}
    };
    public GameObject 技能1特效;
    public GameObject 技能2特效;
    public void 释放(string 技能快捷键)
    {
        if (!技能字典.ContainsKey(技能快捷键))return;
        string 技能名 = 技能字典[技能快捷键];
        Type type = this.GetType();
        MethodInfo methodInfo = type.GetMethod(技能名);
        if (methodInfo != null)
        {
            methodInfo.Invoke(this, null);
        }
        else
        {
            Debug.Log("未找到技能");
        }
    }
    public void 技能1()
    {
        技能1特效.GetComponent<test_fx>().Play = true;
    }
    public void 技能2()
    {
        技能2特效.GetComponent<test_p2p_fx>().Play = true;
    }
}
