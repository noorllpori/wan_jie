using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Main_Charactor : actor_base2x5D_SP
{
    private enum 状态
    {
        移动,
        搓招
    }
    private 状态 当前状态;
    public int FrameRate = 60;
    public GameObject Center_mainOBJ;
    public bool TargettoMouse = false;
    public bool Bt_EasyFace2Test = false;
    public float SpeedMax;
    public GameObject 搓招栏;
    public GameObject 搓招栏括号;
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

        TargettoMouse = Input.GetMouseButton(0)?true:false;
        usedVar_CharTarget2V3 = Input.mousePosition;
        usedVar_CharTarget2V3 = Input.GetMouseButtonDown(1) ? Input.mousePosition : usedVar_CharTarget2V3;
        //状态机设计模式
        判定目前处于的状态();
        执行状态对应的操作();
    }
    void 判定目前处于的状态()
    {
        if(TargettoMouse)当前状态 = 状态.移动;
        else 当前状态 = 状态.搓招;
    }
    void 执行状态对应的操作()
    {
        switch (当前状态)
        {
            case 状态.移动:
                人物移动();
                break;
            case 状态.搓招:
                搓招();
                break;
        }
    }
    void 人物移动()
    {
        Var_SpeedCurret = SpeedMax;
        搓招栏.GetComponent<TextMeshProUGUI>().text = "";
        搓招栏括号.GetComponent<TextMeshProUGUI>().text = "";

        if (Bt_EasyFace2Test)
        {
            Center_mainOBJ.transform.localScale = new Vector3(sysVar_Charactor_leftrightFaceTo == 0 ? 1f:-1f, 1f, 1f) ;
        }
        else
        {
            Center_mainOBJ.transform.localScale = Vector3.one;
        }
    }
    void 搓招()
    {
        搓招栏括号.GetComponent<TextMeshProUGUI>().text = "<                    >";
        Var_SpeedCurret = 0;
        for(char i = 'a'; i <= 'z'; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                搓招栏.GetComponent<TextMeshProUGUI>().text += i.ToString();
                if(搓招栏.GetComponent<TextMeshProUGUI>().text.Length > 8)
                {
                    搓招栏.GetComponent<TextMeshProUGUI>().text = 搓招栏.GetComponent<TextMeshProUGUI>().text.Substring(1);
                }
                for(int j = 0; j < 搓招栏.GetComponent<TextMeshProUGUI>().text.Length; j++)
                {
                    if(释放技能.Instance.技能字典.ContainsKey(搓招栏.GetComponent<TextMeshProUGUI>().text.Substring(j)))
                    {
                        释放技能.Instance.释放(搓招栏.GetComponent<TextMeshProUGUI>().text.Substring(j));
                        搓招栏.GetComponent<TextMeshProUGUI>().text = "";
                        break;
                    }
                }
            }
        }
    }
}
