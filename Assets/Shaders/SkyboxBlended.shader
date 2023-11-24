Shader "Custom/SkyboxBlended" {
  Properties {
      _MainTex ("Day Skybox", Cube) = "" {}
      _SecondTex ("Night Skybox", Cube) = "" {}
      _CurrentTimeOfDay ("Current Time of Day", Range(0, 1)) = 0
  }
   SubShader {
       Tags { "Queue"="Background" "RenderType"="Background" }
       Cull Off ZWrite Off
       Pass {
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
           #include "UnityCG.cginc"

           struct appdata_t {
               float4 vertex : POSITION;
               float2 uv : TEXCOORD0;
           };

           struct v2f {
               float2 uv : TEXCOORD0;
               float3 worldPos : TEXCOORD1;
               float3 worldNormal : TEXCOORD2;
               float4 vertex : SV_POSITION;
           };

           samplerCUBE _MainTex;
           samplerCUBE _SecondTex;

           v2f vert (appdata_t v) {
               v2f o;
               o.vertex = UnityObjectToClipPos(v.vertex);
               o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
               o.worldNormal = UnityObjectToWorldNormal(v.vertex.xyz);
               o.uv = v.uv;
               return o;
           }

           fixed4 frag (v2f i) : SV_Target {
               // Convert the 2D UV coordinates to a 3D direction vector
               float3 dir = i.worldPos - _WorldSpaceCameraPos;
               dir = normalize(dir);

               // Get the current time of day
               float timeOfDay = TimeManager.GetCurrentTimeOfDay();

               // Sample the textures
               fixed4 dayColor = texCUBE(_MainTex, dir);
               fixed4 nightColor = texCUBE(_SecondTex, dir);

               // Blend the colors based on the current time of day
               return lerp(nightColor, dayColor, timeOfDay);
           }
           ENDCG
       }
   }
}
