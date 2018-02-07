using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTextureScript : MonoBehaviour {
    [SerializeField]
    private Texture[] Textures;
    [SerializeField]
    private int CurrentTex;
    [SerializeField]
    private Material LedLightShader;
    [SerializeField]
    private Renderer rend;
    public characterEnum LedTextureType;

    [SerializeField]
    private Texture[] Ninja;

    [SerializeField]
    private Texture[] GifSecond;

    [SerializeField]
    private Texture[] GifThird;

    [SerializeField]
    private Texture[] SpongeBob;



    public enum characterEnum
    {
        JoyConAnim,
        RandomAnim,
        TrailerAnim,
        Ninja
    }

    void Start ()
    {
        rend = GetComponent<Renderer>();
        CurrentTex = 0;
        //StartCoroutine(JoyCon());
        //StartCoroutine(Trailer());
        StartCoroutine(NinjaTimer());
        //StartCoroutine(Gif2());
        //StartCoroutine(Gif3());
        //StartCoroutine(SpongeBobTimer());
    }

    public void Update()
    {
        if (LedTextureType == characterEnum.JoyConAnim)
        {
            Debug.Log("JoyCons");
            
        }

        if (LedTextureType == characterEnum.RandomAnim)
        {
            Debug.Log("Random");
        }

        if (LedTextureType == characterEnum.TrailerAnim)
        {
            Debug.Log("TrailerAnim");
        }

        if (LedTextureType == characterEnum.Ninja)
        {
            Debug.Log("Ninja");
        }
    }   

    IEnumerator JoyCon()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            if(CurrentTex == 1)
            {
                LedLightShader.SetTexture("_MainTex", Textures[0]);
                CurrentTex = 0;
            }
            else
            {
                LedLightShader.SetTexture("_MainTex", Textures[1]);
                CurrentTex = 1;
            }
            Debug.Log("Niels is cool");
            
        }
    }

    IEnumerator Trailer()
    {
        CurrentTex = 2;
        while (true || CurrentTex < Textures.Length)
        {
            yield return new WaitForSeconds(.5f);
            
                LedLightShader.SetTexture("_MainTex", Textures[CurrentTex]);
                CurrentTex++;
        }
    }

    IEnumerator NinjaTimer()
    {
        int NinjaTimer = 0;
        while (true)
        {
            yield return new WaitForSeconds(.06f);

            LedLightShader.SetTexture("_MainTex", Ninja[NinjaTimer]);
            NinjaTimer++;

            if (NinjaTimer == Ninja.Length)
            {
                NinjaTimer = 0;
            }
        }    
    }

    IEnumerator Gif2()
    {
        int GifTimer = 0;
        while (true)
        {
            yield return new WaitForSeconds(.1f);

            LedLightShader.SetTexture("_MainTex", GifSecond[GifTimer]);
            GifTimer++;

            if (GifTimer == GifSecond.Length)
            {
                GifTimer = 0;
            }
        }
    }

    IEnumerator Gif3()
    {
        int GifTimer = 0;
        while (true)
        {
            yield return new WaitForSeconds(.15f);

            LedLightShader.SetTexture("_MainTex", GifThird[GifTimer]);
            GifTimer++;

            if (GifTimer == GifThird.Length)
            {
                GifTimer = 0;
            }
        }
    }

    IEnumerator SpongeBobTimer()
    {
        int GifTimer = 0;
        while (true)
        {
            yield return new WaitForSeconds(.1f);

            LedLightShader.SetTexture("_MainTex", SpongeBob[GifTimer]);
            GifTimer++;

            if (GifTimer == SpongeBob.Length)
            {
                GifTimer = 0;
            }
        }


    }
}
