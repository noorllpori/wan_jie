using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fx_init : MonoBehaviour
{
    public bool _test_play;

    public int PlayRate;
    [SerializeField]
    public float time_rate;

    public float cycle_time;

    public bool Play;

    [HideInInspector]
    public bool _isPlaying;

    public GameObject FxMesh_Render;

    public Texture[] start_flip;
    public Texture[] cycle_flip;
    public Texture[] end_flip;

    protected virtual void _update()
    {
        time_rate = 1f / PlayRate;
    }
}
