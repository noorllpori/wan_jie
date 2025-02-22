using System;
using UnityEngine;

public class actor_base2x5D_SP : MonoBehaviour
{
    public int directSplit = 24;

    public bool Void_Dir_obj_show = true;
    // public bool Void_EasyFacetto = false;

    public GameObject DIR_DEG = null;
    public GameObject DIR_24INT = null;

    public int Var_Charactor_customStutas = 0;

    public Vector3 usedVar_CharTarget2V3;
    public float Var_Charactor_floatDir;
    public int sysVar_Charactor_DirIntSplit;
    public int sysVar_Charactor_leftrightFaceTo;// 0 是右 1 是左
    public int sysVar_Charactor_updownFaceTo = 0;    //1是下 0是上
    public bool Void_Charactor_facetoSwitch = false;

    public Vector3 sysVar_Char_DirVector;
    public float Var_SpeedCurret = 0;
    public float Var_SpeedMxx = 0.1f;
    public GameObject 正面;
    public GameObject 背面;
        
    protected virtual void varReady()
    {
        Void_Charactor_facetoSwitch = false;
    }

    protected virtual void Sc_Update()
    {
        if (usedVar_CharTarget2V3.magnitude > 0 )
        {
            Vector3 mPos = this.transform.position;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(mPos);

            Vector3 dir_DegV3 = screenPosition - usedVar_CharTarget2V3;
            float angleInRadians = Mathf.Atan2(dir_DegV3.x, dir_DegV3.y);
            Var_Charactor_floatDir = -(angleInRadians * Mathf.Rad2Deg - 180f) / 360f;
            usedVar_CharTarget2V3 = Vector3.zero;
        }

        Var_Charactor_floatDir = Var_Charactor_floatDir > 1 ? 1 : (Var_Charactor_floatDir < 0 ? 0 : Var_Charactor_floatDir);

        sysVar_Charactor_DirIntSplit = (int)Math.Round(Var_Charactor_floatDir * directSplit);
        DIR_DEG.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Var_Charactor_floatDir * 360f);
        DIR_24INT.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, sysVar_Charactor_DirIntSplit * 360f / directSplit);
        DIR_DEG.SetActive(Void_Dir_obj_show); DIR_24INT.SetActive(Void_Dir_obj_show);
        sysVar_Charactor_leftrightFaceTo = Var_Charactor_floatDir < 0.5f ? 1 : 0;
        if(Var_Charactor_floatDir>0.25f && Var_Charactor_floatDir<0.75f) sysVar_Charactor_updownFaceTo = 1;
        else sysVar_Charactor_updownFaceTo = 0;

        if (Void_Charactor_facetoSwitch)
        {
            sysVar_Charactor_leftrightFaceTo = sysVar_Charactor_leftrightFaceTo == 1 ? 0 : 1;
            Void_Charactor_facetoSwitch = false;
        }
        if(sysVar_Charactor_updownFaceTo == 1)
        {
            正面.SetActive(true);
            背面.SetActive(false);
        }
        else
        {
            正面.SetActive(false);
            背面.SetActive(true);
        }
    }
}
