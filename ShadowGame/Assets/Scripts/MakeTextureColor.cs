using UnityEngine;
using UnityEngine.Rendering;

public class MakeTextureColor : MonoBehaviour
{
    //[SerializeField] RenderTexture cameraTexture;
    //[SerializeField] RenderTexture shadowTexture;
    [SerializeField] Color ShadowColor;
    //[SerializeField] Texture2D shadowTex;

    //[SerializeField][Range(0,256*256)] int ind = 0; 
    //Texture2D shadowAlphaTexture;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setShadowTexture();
    }

    /*void setShadowTexture() 
    {
        Texture2D shadowAlphaTexture = new Texture2D(cameraTexture.width, cameraTexture.height);
        Graphics.CopyTexture(cameraTexture, 0, 0, shadowAlphaTexture, 0, 0);
        Color[] alpha = shadowAlphaTexture.GetPixels();
        Debug.Log(alpha[ind].a + " " + ind);
        Color[] result = new Color[alpha.Length];
        for (int i = 0; i < alpha.Length; i++) 
        {
            result[i] = new Color(ShadowColor.r, ShadowColor.g, ShadowColor.b, alpha[i].a);
        }
        Texture2D resultTex = new Texture2D(shadowAlphaTexture.width, shadowAlphaTexture.height);
        resultTex.SetPixels(result);
        shadowTex = resultTex;
        Graphics.CopyTexture(resultTex, 0, 0, shadowTexture, 0, 0);
    }*/
}
