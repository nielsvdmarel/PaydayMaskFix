using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTextureScript : MonoBehaviour {
    [SerializeField]
    private int CurrentTex;
    [SerializeField]
    private Material LedLightShader;
    [SerializeField]
    private Renderer rend;
    public characterEnum LedTextureType;
    [SerializeField]
    private Texture[] Textures;
    [SerializeField]
    private Texture[] LagTex;
    [SerializeField]
    private Texture[] Ninja;
    [SerializeField]
    private Texture[] GifSecond;
    [SerializeField]
    private Texture[] GifThird;
    [SerializeField]
    private Texture[] WhiteLoadTex;
    [SerializeField]
    private Texture[] SpongeBob;
    [SerializeField]
    bool HasBinActivated = false;
    private float waitTimeLag;



    public enum characterEnum
    {
        Begin,
        Ninja,
        HeroGif,
        SunRise,
        Spongebob,
        Lag,
        End
        
    }
    public characterEnum type;
    private characterEnum currentype;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        CurrentTex = 0;
        type = characterEnum.Lag;
    }

    public void Update()
    {
        if (currentype != type)
        {
            HasBinActivated = true;
            currentype = type;
        }
        switch (type)
        {
            case characterEnum.Lag:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(Lag());
                        HasBinActivated = false;
                    }
                }
                break;
            case characterEnum.Ninja:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(NinjaTimer());
                        HasBinActivated = false;
                    }
                }
                break;

            case characterEnum.HeroGif:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(Gif2());
                        HasBinActivated = false;
                    }
                }
                break;

            case characterEnum.SunRise:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(Gif3());
                        HasBinActivated = false;
                    }
                }
                break;
            case characterEnum.Spongebob:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(SpongeBobTimer());
                        HasBinActivated = false;
                    }
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            type += 1;
            if (type == characterEnum.End)
            {
                type = characterEnum.Ninja;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            type -= 1;
            if(type == characterEnum.Begin)
            {
                type = characterEnum.Lag;
            }
            
        }
    }

    IEnumerator JoyCon()
    {
        while (true)
        {
            LedLightShader.SetFloat("_Glow", 5);
            yield return new WaitForSeconds(1f);
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

    IEnumerator Lag()
    {
        CurrentTex = 0;
        while (true || CurrentTex < LagTex.Length)
        {
            LedLightShader.SetTexture("_MainTex", LagTex[CurrentTex]);
            LedLightShader.SetFloat("_Glow", Random.Range(1f, 3));
            yield return new WaitForSeconds(Random.Range(.07f,.09f));
            CurrentTex++;
            if (CurrentTex == LagTex.Length)
            {
                StopAllCoroutines();
                StartCoroutine(Trailer());
            }
        }
    }

    IEnumerator Trailer()
    {
        CurrentTex = 2;
        while (true || CurrentTex < Textures.Length)
        {
            LedLightShader.SetFloat("_Glow", 5);
            LedLightShader.SetTexture("_MainTex", Textures[CurrentTex]);
            yield return new WaitForSeconds(.7f);
            CurrentTex++;
            if(CurrentTex == Textures.Length)
            {
                StopAllCoroutines();
                StartCoroutine(WhiteLoad());
            }
        }
    }

    IEnumerator NinjaTimer()
    {
        int NinjaTimer = 0;
        while (true)
        {
            LedLightShader.SetFloat("_Glow", 5);
            LedLightShader.SetTexture("_MainTex", Ninja[NinjaTimer]);
            yield return new WaitForSeconds(.06f);
            NinjaTimer++;

            if (NinjaTimer == Ninja.Length)
            {
                NinjaTimer = 0;
            }
        }    
    }

    IEnumerator WhiteLoad()
    {
        int WhiteTimer = 0;
        while (true)
        {
            LedLightShader.SetFloat("_Glow", 5);
            LedLightShader.SetTexture("_MainTex", WhiteLoadTex[WhiteTimer]);
            yield return new WaitForSeconds(.04f);
            WhiteTimer++;
            if (WhiteTimer == WhiteLoadTex.Length)
            {
                Debug.Log("Nu gebeurt het");
                StopAllCoroutines();
                StartCoroutine(JoyCon());
            }

        }
    }

    IEnumerator Gif2()
    {
        int GifTimer = 0;
        while (true)
        {
            LedLightShader.SetFloat("_Glow", 5);
            LedLightShader.SetTexture("_MainTex", GifSecond[GifTimer]);
            yield return new WaitForSeconds(.1f);
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
            LedLightShader.SetFloat("_Glow", 5);
            LedLightShader.SetTexture("_MainTex", GifThird[GifTimer]);
            yield return new WaitForSeconds(.15f);
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
            LedLightShader.SetFloat("_Glow", 5);
            LedLightShader.SetTexture("_MainTex", SpongeBob[GifTimer]);
            yield return new WaitForSeconds(.1f);
            GifTimer++;

            if (GifTimer == SpongeBob.Length)
            {
                GifTimer = 0;
            }
        }


    }


    void NewLedTexture(IEnumerator current)
    {
        StopAllCoroutines();
        StartCoroutine(current);
    }
}
