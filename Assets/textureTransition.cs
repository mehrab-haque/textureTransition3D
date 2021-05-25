using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureTransition : MonoBehaviour
{
	
	public Texture[] textures;
	private Renderer renderer;
	
    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<Renderer> ();
        renderer.material.SetTexture("_MainTex",textures[0]);
        renderer.material.SetTexture("_Texture2",textures[1]);
        renderer.material.SetFloat("_Blend",0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetSliderValue(float newValue){
    	float rangeSize=1f/(textures.Length-1);
    	int sliderPos=(int)(newValue/rangeSize);
    	float currentBlend=(newValue-sliderPos*rangeSize)/rangeSize;
    	renderer.material.SetTexture("_MainTex",textures[sliderPos]);
    	if(sliderPos<textures.Length-1)renderer.material.SetTexture("_Texture2",textures[sliderPos+1]);
        renderer.material.SetFloat("_Blend",currentBlend);
    }
}