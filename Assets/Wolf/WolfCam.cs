using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCam : MonoBehaviour {

    public Shader replacementShader; 
    public RenderTexture renderTex;
    public Transform trackedObject;

    //Resultat
    public float visibility;
    public float visibilityMax = 0.1f;

    private Texture2D texture;

    void OnValidate()
    {
        GetComponent<Camera>().SetReplacementShader(replacementShader, "");
        Shader.SetGlobalVector("_TrackedObjectPos", trackedObject.position);

    }

    // Use this for initialization
    void Start () {
        texture = new Texture2D(renderTex.width, renderTex.height, TextureFormat.RGBA32, true);
    }

    void OnPreRender()
    {
        Shader.SetGlobalVector("_TrackedObjectPos", trackedObject.position);
    }

    void OnPostRender() {
        texture.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0, true);
        texture.Apply();
        Color[] colors = texture.GetPixels();

        double red = 0;
        foreach (Color c in colors)
            red += c.r;
        red /= colors.Length;
        red /= visibilityMax;
        visibility = (float)red;
    }
}
