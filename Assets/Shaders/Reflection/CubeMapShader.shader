Shader "Custom/CubeMapShader"
{
    Properties
    {
        _mainTex("Main Texture", 2D) = "white" { }
        _cubeMap("Cube Map", CUBE) = "" { }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        samplerCUBE _cubeMap;
        sampler2D _mainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldRefl;
        };
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = (tex2D(_mainTex, IN.uv_MainTex)).rgb;
            o.Emission = texCUBE(_cubeMap, IN.worldRefl).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
