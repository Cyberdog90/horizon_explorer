Shader "culloff_shader" {
    Properties {
        _Alpha("Alpha",Range(0,1.0)) = 1.0
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }
        Cull off
        LOD 200

        Pass {
            ZWrite ON
            ColorMask 0
        }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        uniform float _Alpha;
        fixed4 _Color;

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = (tex2D(_MainTex, IN.uv_MainTex) * _Color).rgb;
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}