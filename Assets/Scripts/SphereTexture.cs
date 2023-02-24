using System;
using UnityEngine;

public class SphereTexture {
    public string TextureName { get; }
    public Texture2D Texture { get; private set; }

    public SphereTexture(string textureName) {
        TextureName = textureName;
        LoadTexture();
    }

    private void LoadTexture() {
        if (TextureName == "") return;
        var tn = TextureName.Split('.');
        Texture = Resources.Load<Texture2D>($"image/{tn[0]}");
        if (Texture == null) {
            Debug.Log($"読み込み失敗画像: {TextureName}");
            throw new NullReferenceException("テクスチャ読み込みに失敗したZOY☆");
        }
    }
}