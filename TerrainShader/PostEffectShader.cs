using UnityEngine;
using System.Collections;

public class PostEffectShader : MonoBehaviour {

    public Material mat;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // src is the full rendered scene that will normally render.
        // 


        //Graphics.Blit(src, dest, mat);
    }
}
