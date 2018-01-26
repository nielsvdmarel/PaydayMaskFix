Shader "Custom/PayDay2LEDShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondTex("SecondTex (RGB)", 2D) = "white"{}
		_BumpMap("Bumpmap", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
			// new stuff	
		_Glow("Glow Intensity", Range(0, 10)) = 1
		
	}
	SubShader {
		Tags{ "Queue" = "Geometry-9" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200
		Cull Off
		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _SecondTex;
		sampler2D _BumpMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_SecondTex;
			float2 uv_BumpMap;

		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		half _Glow;

		
		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			//fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			fixed4 c = _Glow *tex2D(_MainTex, IN.uv_MainTex).a;
			
			c *= tex2D(_MainTex, IN.uv_MainTex) * tex2D(_SecondTex, IN.uv_MainTex);

			o.Albedo = c.rgb;

			//
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			

			//
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		}
		ENDCG
	}
			Fallback "Transparent/VertexLit"
}
