using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Main_Charactor : actor_base2x5D_SP
{
    public int FrameRate = 60;
    public GameObject Center_mainOBJ;

    public bool TargettoMouse = false;

    public bool Bt_EasyFace2Test = false;

    public float SpeedMax;

    void Start()
    {
        Application.targetFrameRate = FrameRate;

        base.varReady();
        Center_mainOBJ.gameObject.transform.localPosition = Vector3.zero;
    }

    private void FixedUpdate()
    {
        // Var_SpeedCurret = Mathf.Lerp(0, Var_SpeedCurret, Time.deltaTime * Var_SpeedMxx);

        float radians = Var_Charactor_floatDir * 360f * Mathf.Deg2Rad;
        float x = -Mathf.Sin(radians); float y = Mathf.Cos(radians);
        sysVar_Char_DirVector = new Vector3(x, 0, y);

        this.transform.position += sysVar_Char_DirVector * Var_SpeedCurret * Time.deltaTime;
    }

    void Update()
    {
        base.Sc_Update();

        Vector3 mousePosition = Input.mousePosition;

        TargettoMouse = Input.GetMouseButton(0)?true:false;

        usedVar_CharTarget2V3 = Input.GetMouseButtonDown(1) ? mousePosition : usedVar_CharTarget2V3;

        if (TargettoMouse)
        {
            usedVar_CharTarget2V3 = mousePosition;
            Var_SpeedCurret = SpeedMax;
        }
        else
        {
            Var_SpeedCurret = 0;
        }

        if (Bt_EasyFace2Test)
        {
            Center_mainOBJ.transform.localScale = new Vector3(sysVar_Charactor_leftrightFaceTo == 0 ? 1f:-1f, 1f, 1f) ;
        }
        else
        {
            Center_mainOBJ.transform.localScale = Vector3.one;
        }
    }
}
