using System;
using UnityEngine;

public class actor_base_SP : MonoBehaviour
{
    public float SysDeltatime;

    public int directSplit = 24;

    public bool Void_Dir_obj_show = true;
    // public bool Void_EasyFacetto = false;

    public GameObject DIR_DEG = null;
    public GameObject DIR_24INT = null;

    public int Var_Charactor_customStutas = 0;

    public Vector3 usedVar_CharTarget2V3;
    public float Var_Charactor_floatDir;
    public int sysVar_Charactor_DirIntSplit;
    public int sysVar_Charactor_leftrightFaceTo = 0;    // 0 ÊÇÓÒ 1 ÊÇ×ó

    public bool Void_Charactor_facetoSwitch = false;

    public Vector3 sysVar_Char_DirVector;
    public float Var_SpeedCurret = 0;
    public float Var_SpeedMxx = 0.1f;
        
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

        if (Void_Charactor_facetoSwitch)
        {
            sysVar_Charactor_leftrightFaceTo = sysVar_Charactor_leftrightFaceTo == 1 ? 0 : 1;
            Void_Charactor_facetoSwitch = false;
        }

        Var_SpeedCurret = Mathf.Lerp(0, Var_SpeedCurret, Time.deltaTime * Var_SpeedMxx);

        float radians = Var_Charactor_floatDir *360f * Mathf.Deg2Rad;
        float x = -Mathf.Sin(radians); float y = Mathf.Cos(radians);
        sysVar_Char_DirVector = new Vector3(x, y, 0);

        this.transform.position += sysVar_Char_DirVector * Var_SpeedCurret * Time.deltaTime;
    }
}
