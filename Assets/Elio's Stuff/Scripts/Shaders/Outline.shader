Shader "Toon/Outline"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_OutlineColor("Outline Color",Color) = (0.1,0.1,0.1,1)
		_OutlineWidth("Outline Width",Range(0.001,0.01)) = 0.001

		_MainColor("Main Color", Color) = (1, 1, 1, 1)
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			Name "OUTLINEPASS"

			ZWrite off

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
			};

			float4 _OutlineColor;
			float _OutlineWidth;

			v2f vert(appdata IN)
			{
				v2f o;
				float camDist = distance(UnityObjectToWorldDir(IN.vertex), _WorldSpaceCameraPos);
				IN.vertex.xyz += normalize(IN.normal) * camDist * _OutlineWidth;
				o.pos = UnityObjectToClipPos(IN.vertex);
				return o;
			}

			float4 frag(v2f IN) : SV_TARGET
			{
				return _OutlineColor;
			}

			ENDCG
		}

		Pass
		{

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag


			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;

				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainColor;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv) * _MainColor;
				// apply fog
			
				return col;
			}
		    ENDCG
	    }
		//Your own shader pass
	}
}
	