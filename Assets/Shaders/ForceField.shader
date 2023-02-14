Shader "Custom/ForceField"
{
    Properties
    {
        _forceTexture("Texture", 2D) = "" {}
        _RimColor("Rim Color", Color) = (0, 0.5, 0.5, 0.0)
        _RimPower("Rim Power", Range(0.5, 8.0)) = 3.0
        _MaskPos("Mask Pos", vector) = (0,0,0,0)
        _GameTime("Time", float) = 0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent"}

        Pass {
            ZWrite On
            ColorMask 0
        }
        
        CGPROGRAM
        #pragma surface surf Lambert alpha:fade

        #pragma target 3.0
        struct Input
        {
            float3 viewDir;
            float2 uv_forceTexture;
        };

        float4 _RimColor;
        float4 _MaskPos;
        float _RimPower;
        float _GameTime;
        sampler2D _forceTexture;
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D (_forceTexture, IN.uv_forceTexture).rgb * _GameTime;
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow (rim, _RimPower) * 10;

            float3 worldPos = float3(_MaskPos.x, _MaskPos.y, _MaskPos.z);

            float distance = length(_WorldSpaceCameraPos - worldPos);
            float total = distance - _MaskPos.a;
            total = clamp(total, 0, 0.5f);
            
            o.Alpha = total + pow(rim, _RimPower);
        }

        
        ENDCG
    }
    FallBack "Diffuse"
}
