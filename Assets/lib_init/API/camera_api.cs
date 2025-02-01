using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class camera_api : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public VolumeProfile volume;

    // FX fov
    public bool _fx = false;
    public Vector2 volume_fx_CA;
    public Vector2 volume_fx_Len;
    public Vector2 volume_fx_LenScale;

    private float back_fx = 0;
    public float back_add = 3;

    public Vector2 cam_freq;

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
        virtualCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.Lerp(cam_freq.x, cam_freq.y, back_fov_curret);

        if (volume.TryGet(out ChromaticAberration chromaticAberration))
        {
            chromaticAberration.intensity.value = Mathf.Lerp(volume_fx_CA.x, volume_fx_CA.y, back_fov_curret); ;
        }
        if (volume.TryGet(out LensDistortion lensDistortion))
        {
            lensDistortion.intensity.value = Mathf.Lerp(volume_fx_Len.x, volume_fx_Len.y, back_fov_curret);
            lensDistortion.scale.value = Mathf.Lerp(volume_fx_LenScale.x, volume_fx_LenScale.y, back_fov_curret);
        }
    }
}
