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
    private Texture[] SpongeBob;
    [SerializeField]
    bool HasBinActivated = false;



    public enum characterEnum
    {
        Begin,
        JoyConAnim,
        RandomAnim,
        TrailerAnim,
        Ninja,
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
        //type = characterEnum.Begin;
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
            case characterEnum.JoyConAnim:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(JoyCon());
                        HasBinActivated = false;
                    }
                }         
                break;

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
            case characterEnum.RandomAnim:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(NinjaTimer());
                        HasBinActivated = false;
                    }
                }
                break;
            case characterEnum.TrailerAnim:
                if (HasBinActivated)
                {
                    {
                        NewLedTexture(Trailer());
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
                type = characterEnum.JoyConAnim;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            type -= 1;
            if(type == characterEnum.Begin)
            {
                type = characterEnum.Spongebob;
            }
            
        }
    }

    IEnumerator JoyCon()
    {
        while (true)
        {
            yield return new WaitForSeconds(.45f);
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
        CurrentTex = 2;
        while (true || CurrentTex < LagTex.Length)
        {
            yield return new WaitForSeconds(.1f);

            LedLightShader.SetTexture("_MainTex", LagTex[CurrentTex]);
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
            yield return new WaitForSeconds(.7f);
            
                LedLightShader.SetTexture("_MainTex", Textures[CurrentTex]);
                CurrentTex++;
            if(CurrentTex == Textures.Length)
            {
                StopAllCoroutines();
                StartCoroutine(JoyCon());
            }
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


    void NewLedTexture(IEnumerator current)
    {
        StopAllCoroutines();
        StartCoroutine(current);
    }
}
