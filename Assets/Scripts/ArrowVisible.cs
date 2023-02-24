using System;
using UnityEngine;

public class ArrowVisible : MonoBehaviour
{
    [SerializeField] private GameObject arrowFront;
    [SerializeField] private GameObject arrowRight;
    [SerializeField] private GameObject arrowBehind;
    [SerializeField] private GameObject arrowLeft;
    private GameObject[] _arrows;
    private string _textureName;

    private void Start()
    {
        _arrows = new[] { arrowFront, arrowRight, arrowBehind, arrowLeft };
        _textureName = "";
    }

    private void Update()
    {
        if (_textureName == Setting.NowPoint) return;
        _textureName = Setting.NowPoint;
        foreach (var arrow in _arrows) arrow.SetActive(true);
        if (Setting.Graph.Graph[_textureName].Front == null) arrowFront.SetActive(false);
        if (Setting.Graph.Graph[_textureName].Right == null) arrowRight.SetActive(false);
        if (Setting.Graph.Graph[_textureName].Back == null) arrowBehind.SetActive(false);
        if (Setting.Graph.Graph[_textureName].Left == null) arrowLeft.SetActive(false);
    }
}