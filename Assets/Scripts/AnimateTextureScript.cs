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

    public enum characterEnum
    {
        JoyConAnim,
        RandomAnim,
        TrailerAnim
    }

    public characterEnum LedTextureType;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        CurrentTex = 0;
        StartCoroutine(Wait1sec());
	}

    public void Update()
    {
       
    }   

    IEnumerator Wait1sec()
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
}
