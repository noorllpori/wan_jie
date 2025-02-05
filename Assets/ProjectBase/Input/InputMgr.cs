using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


//[System.Serializable]
//public class InputActionData
//{
    //public string name;
    //public InputAction action;
//}




public class InputMgr : SingletonMono<InputMgr>
{
    //是否进行输入检测
    
    private bool isStart = false;

    //输入事件InputAction
    //public List<InputActionData> inputActionList;







    //鼠标加速度
    private float mouseAcceleratedSpeed;
    //鼠标速度变化量
    private float mousedetalV=0;


    //初始化
    private void Start()
    {
        if (!isStart)
            return;
       // for(int i=0;i<inputActionList.Count;i++)
        //{
           // inputActionList[i].action.Enable();
       // }
        
    }



    private void Update()
    {
        MyUpdate();
    }



    /// <summary>
    /// 是否开启或关闭 我的输入检测
    /// </summary>
    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;
    }



    /// <summary>
    /// 用于检测鼠标位置
    /// </summary>
    ///<param name="mouse"></param>
   public Vector2 GetMousePos()
    {
        return Mouse.current.position.ReadValue();
    }



    /// <summary>
    /// 检测鼠标帧位移
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMouseDetalMove()
    {
        return Mouse.current.delta.ReadValue();
    }



    /// <summary>
    /// 检测鼠标滚轮位移
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMouseScroll()
    {
        return Mouse.current.scroll.ReadValue();
    }



    /// <summary>
    /// 外部获得加速度
    /// </summary>
    /// <returns></returns>
    public float GetmouseAcceleratedSpeed()
    {
        return mouseAcceleratedSpeed;
    }



   /// <summary>
   /// 内部获得加速度
   /// </summary>
    private void CheckmouseAcceleratedSpeed()
    {
        float detalDistance = GetMouseDetalMove().magnitude;
        if(detalDistance==0)
        {
            mouseAcceleratedSpeed = 0;
            return;
        }
        float mouseV = detalDistance / Time.deltaTime;
        mousedetalV = mouseV - mousedetalV;
        if (mousedetalV==0)
        {
            mouseAcceleratedSpeed = 0;
            return;
        }
        mouseAcceleratedSpeed = mousedetalV / Time.deltaTime;
    }




    /// <summary>
    /// 用来检测按键抬起按下 分发事件的
    /// </summary>
    /// <param name="key"></param>
    public void CheckAction(InputAction key,
        Action<CallbackContext> startedFun,
        Action<CallbackContext> performedFun=null,
        Action<CallbackContext> canceledFun=null)
    {
        key.started += startedFun;

        if (performedFun != null)
            key.performed += performedFun;
        if (canceledFun == null)
            key.canceled += canceledFun;
    }



    /// <summary>
    /// 获得InputAction
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public InputAction GetInputAction(string name)
    {
        return GetComponent<PlayerInput>().actions.FindAction(name);
    }


    private void MyUpdate()
    {
        //没有开启输入检测 就不去检测 直接return
        if (!isStart)
            return;
        // 每帧获得加速度
        CheckmouseAcceleratedSpeed();
      
    }
	
}
