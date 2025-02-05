using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonPanel:BasePanel
{
    public Text txtTips;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        EventCenter.GetInstance().AddEventListener("StartOrWin", StartAction);
    }


    private void Start()
    {
        //EventCenter.GetInstance().AddEventListener("StartOrWin", StartAction);
    }
    private void StartAction()
    {
        if(GameMgr.GetInstance().isAdd==1)
        {
            txtTips.text = "��" + GameMgr.GetInstance().num1 + "��" + GameMgr.GetInstance().num2 + "����";
        }
        else
        {
            txtTips.text = "��" + GameMgr.GetInstance().num1 + "С" + GameMgr.GetInstance().num2 + "����";
        }
    }
}
