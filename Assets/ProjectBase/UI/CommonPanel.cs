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
            txtTips.text = "比" + GameMgr.GetInstance().num1 + "大" + GameMgr.GetInstance().num2 + "的数";
        }
        else
        {
            txtTips.text = "比" + GameMgr.GetInstance().num1 + "小" + GameMgr.GetInstance().num2 + "的数";
        }
    }
}
