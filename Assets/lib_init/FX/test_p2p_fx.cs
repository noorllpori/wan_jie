using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class test_p2p_fx : Fx_init
{
    private int stuta;
    private int start_id;
    private int cycle_id;
    private int end_id;
    private int start_max;
    private int cycle_max;
    private int end_max;
    private float stutaTime;
    private float curtTime;
    MeshRenderer meshRenderer;
    public GameObject Api;
    camera_api cam_api;

    public GameObject start_obj;
    public Vector3 start_pos;
    public GameObject end_obj;
    public Vector3 end_pos;


    void Start()
    {
        base._update();
        Api = GameObject.Find("API");
        cam_api = Api.GetComponent<camera_api>();
        meshRenderer = FxMesh_Render.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    void Update()
    {
        if (Play)
        {
            this.transform.position = start_obj.transform.position + new Vector3(0,0.4f,0); 
            this.gameObject.transform.rotation = Quaternion.Euler(0f, -(cam_api.main_charactor.sysVar_Charactor_DirIntSplit * 360f / cam_api.main_charactor.directSplit) +270, 0f); 
            float t = cam_api.main_charactor.sysVar_Charactor_DirIntSplit > (cam_api.main_charactor.directSplit / 2f) ? 1f : -1f * Mathf.PingPong( (float) (cam_api.main_charactor.sysVar_Charactor_DirIntSplit - (cam_api.main_charactor.directSplit) / 2f)/ (float)(cam_api.main_charactor.directSplit / 2f),0.5f );
            // Debug.Log(t);
            meshRenderer.gameObject.transform.localRotation = Quaternion.Euler(-90f - t * 50f, 0f, -90f);
            meshRenderer = FxMesh_Render.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
            Play = false; _isPlaying = true;
            stuta = 0; start_id = 0; cycle_id = 0; end_id= 0;
            start_max = start_flip.Length - 1;
            // cycle_max = cycle_flip.Length - 1;
            cycle_max = (int) (cycle_time / time_rate);
            end_max = end_flip.Length - 1;
            stutaTime = Time.time;
            curtTime = Time.time+ time_rate;
            cam_api._fx = true;
        }

        if (_isPlaying)
        {
            base._update();
            if (stuta == 0)
            {
                if( (curtTime - stutaTime) > time_rate)
                {
                    stutaTime = curtTime;
                    setMainTex(start_flip[start_id]);
                    start_id++;
                    if (start_id > start_max) { stuta++; }
                }
            }
            else if(stuta == 1)
            {
                if ((curtTime - stutaTime) > time_rate)
                {
                    stutaTime = curtTime;
                    setMainTex(cycle_flip[(cycle_id % (cycle_flip.Length))]);
                    cycle_id++;
                    if (cycle_id > cycle_max) { stuta++; cam_api._fx = false; }
                }
            }
            else if (stuta == 2)
            {
                if ((curtTime - stutaTime) > time_rate)
                {
                    stutaTime = curtTime;
                    setMainTex(end_flip[end_id]);
                    end_id++;
                    if (end_id > end_max) { stuta++; }
                }
            }
            else if (stuta == 3)
            {
                meshRenderer.enabled = false;
                _isPlaying = false;
            }
            curtTime += Time.deltaTime;
        }
    }

    void setMainTex( Texture tex )
    {
        MeshRenderer meshRenderer = FxMesh_Render.GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_FX_TEX", tex);
    }
}
