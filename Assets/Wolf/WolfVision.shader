Shader "Unlit/BlackExceptTracked"
{
	Properties
	{
		_TrackedObjectPos("Tracked Object Position",Vector) = (0,0,0,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _TrackedObjectPos;
			
			v2f vert (appdata v)
			{
				v2f o;
				float3 toObjSpace = mul(unity_WorldToObject, float4(_TrackedObjectPos.xyz, 1.0));
				float red = saturate(1.0 - pow(length(toObjSpace)/0.2, 20));
				o.color = float4(red, 0, 0, 1);

				
				o.vertex = UnityObjectToClipPos(v.vertex);
			  
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{				
				return fixed4(i.color);
			}
			ENDCG
		}
	}
}
