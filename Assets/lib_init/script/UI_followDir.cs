using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_followDir : MonoBehaviour
{
    public Main_Charactor MainC;

    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, MainC.sysVar_Charactor_DirIntSplit * 360f / MainC.directSplit);
    }
}
