// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/Tutorial/Kat"{

	//Varibles
	Properties{
		_MainTexture("Main Colour (RGB) Hello",2D) = "White"{}
		_WaterTexture("Water Colour (RGB) Hello",2D) = "White"{}
		_SandTexture("Sand Colour (RGB) Hello",2D) = "White"{}
		_GrassTexture("Grass Colour (RGB) Hello",2D) = "White"{}
		_RockTexture("Rock Colour (RGB) Hello",2D) = "White"{}
		_SnowTexture("Snow Colour (RGB) Hello",2D) = "White"{}

		_WaterLevel("Water Level", float) = 1
		_SandLevel("Sand Level", float) = 1
		_GrassLevel("Grass Level", float) = 1
		_RockLevel("Rock Level", float) = 1
		_SnowLevel("Snow Level", float) = 1

		_GradentBlendAmount("Gradent Blend Amount", float) = 1

		_WaterWidth("Water Width", float) = 1
		_SandWidth("Sand Width", float) = 1
		_GrassWidth("Grass Width", float) = 1
		_RockWidth("Rock Width", float) = 1
		_SnowWidth("Snow Width", float) = 1

		_LevelOrWidth("Height or Width", int) = 0


	}

	SubShader{

		Pass{

			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 position : SV_POSITION;
				float3 worldPosition : TEXCOORD0;
				float2 uv : TEXCOORD1;
			};
			

			float _GradentBlendAmount;

			sampler2D _MainTexture;
			sampler2D _WaterTexture;
			sampler2D _SandTexture;
			sampler2D _GrassTexture;
			sampler2D _RockTexture;
			sampler2D _SnowTexture;

			float _WaterLevel;
			float _SandLevel;
			float _GrassLevel;
			float _RockLevel;
			float _SnowLevel;

			float _WaterWidth;
			float _SandWidth;
			float _GrassWidth;
			float _RockWidth;
			float _SnowWidth;

			int _LevelOrWidth;

			//Vertex
			// Build the Object.
			v2f vertexFunction(appdata IN){

				v2f OUT;

				OUT.position = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.worldPosition = mul(unity_ObjectToWorld, IN.vertex).xyz;
				OUT.uv = IN.uv;

				return OUT;
			}

			//Fragement
			// Colour It;
			fixed4 fragmentFunction(v2f IN) :SV_Target{

				float4 MAINtextureColour = tex2D(_MainTexture, IN.uv);
				float4 WaterTC = tex2D(_WaterTexture, IN.uv);
				float4 SandTC = tex2D(_SandTexture, IN.uv);
				float4 GrassTC = tex2D(_GrassTexture, IN.uv);
				float4 RockTC = tex2D(_RockTexture, IN.uv);
				float4 SnowTC = tex2D(_SnowTexture, IN.uv);

				float depth = IN.worldPosition.y;

				float4 colour = float4(1, 1, 1, 0);


				if (_LevelOrWidth == 0)
				{
					if (depth < _WaterLevel)
					{
						colour = WaterTC;
					}
					else if (depth < _SandLevel)
					{
						if (depth < _WaterLevel + _GradentBlendAmount)
						{
							colour = lerp(WaterTC, SandTC, (depth - _WaterLevel) / _GradentBlendAmount);
						}
						else
						{
							colour = SandTC;
						}
					}
					else if (depth < _GrassLevel)
					{
						if (depth < _SandLevel + _GradentBlendAmount)
						{
							colour = lerp(SandTC, GrassTC, (depth - _SandLevel) / _GradentBlendAmount);
						}
						else
						{
							colour = GrassTC;
						}
					}
					else if (depth < _RockLevel)
					{
						if (depth < _GrassLevel + _GradentBlendAmount)
						{
							colour = lerp(GrassTC, RockTC, (depth - _GrassLevel) / _GradentBlendAmount);
						}
						else
						{
							colour = RockTC;
						}
					}
					else 
					{
						if (depth < _RockLevel + _GradentBlendAmount)
						{
							colour = lerp(RockTC, SnowTC, (depth - _RockLevel) / _GradentBlendAmount);
						}
						else
						{
							colour = SnowTC;
						}
					}
					
				}
				else
				{
					if (depth < _WaterLevel)
					{
						colour = WaterTC;
					}
					
				}
				
				// Contor 
				float3 f = abs(frac(IN.worldPosition.y * 1) );
				float3 df = fwidth(IN.worldPosition.y * 1.0);

				float mi = max(0.0, 1.0 - 1.0), ma = max(1.0, 1.0);
				float3 g = clamp((f - df*mi) / (df*(ma - mi)), max(0.0, 1.0 - 1.0), 1.0);
				float c = g.x * g.y * g.z;
				float4 gl_FragColor = float4(c, c, c, 1.0);


				return colour *gl_FragColor;

			}


			ENDCG



		}
	}

}