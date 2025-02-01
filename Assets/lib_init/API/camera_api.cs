using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class camera_api : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public Volume volume;

    // FX fov
    public bool _fx = false;
    private float back_fx = 0;
    public float back_add = 3;

    public Vector3 fx_fov_pos;

    public float pov_default = 22;
    public float pov_back;

    private float back_fov_curret;

    void Start()
    {
        
    }

    void Update()
    {
        FX();
    }

    void FX()
    {

        back_fov_curret = Mathf.Lerp(back_fov_curret, back_fx, back_add * Time.deltaTime * 0.5f);
        back_fx = _fx ? 1 : 0;
        Mathf.Clamp01(back_fov_curret); Mathf.Clamp01(back_fx);
        virtualCam.m_Lens.FieldOfView = Mathf.Lerp(pov_default, pov_back, back_fov_curret);
    }
}
