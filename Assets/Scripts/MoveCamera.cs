using System.Collections;
using DG.Tweening;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public float deltaT;
    private bool _isSleep;
    private Transform _tf;
    public static bool MoveFront;
    public static bool MoveBack;
    public static bool MoveRight;
    public static bool MoveLeft;

    void Start()
    {
        MoveFront = false;
        MoveBack = false;
        MoveRight = false;
        MoveLeft = false;
        _isSleep = true;
    }

    void Update() {
        _tf = transform;
        var pos = _tf.position;
        if (MoveFront && _isSleep && Setting.Graph.Graph[Setting.NowPoint].Front != null)
        {
            MoveFront = false;
            _isSleep = false;
            _tf.DOMove(pos + new Vector3(0f, 0f, 200f), deltaT);
            StartCoroutine(ChangeTexture(Setting.Graph.Graph[Setting.NowPoint].Front));
            StartCoroutine(Waiting());
        }

        if (MoveBack && _isSleep && Setting.Graph.Graph[Setting.NowPoint].Back != null)
        {
            MoveBack = false;
            _isSleep = false;
            _tf.DOMove(pos + new Vector3(0f, 0f, -200f), deltaT);
            StartCoroutine(ChangeTexture(Setting.Graph.Graph[Setting.NowPoint].Back));
            StartCoroutine(Waiting());
        }

        if (MoveRight && _isSleep && Setting.Graph.Graph[Setting.NowPoint].Right != null)
        {
            MoveRight = false;
            _isSleep = false;
            _tf.DOMove(pos + new Vector3(200f, 0f, 0f), deltaT);
            StartCoroutine(ChangeTexture(Setting.Graph.Graph[Setting.NowPoint].Right));
            StartCoroutine(Waiting());
        }

        if (MoveLeft&& _isSleep && Setting.Graph.Graph[Setting.NowPoint].Left != null)
        {
            MoveLeft = false;
            _isSleep = false;
            _tf.DOMove(pos + new Vector3(-200f, 0f, 0f), deltaT);
            StartCoroutine(ChangeTexture(Setting.Graph.Graph[Setting.NowPoint].Left));
            StartCoroutine(Waiting());
        }
    }

    private IEnumerator Waiting() {
        yield return new WaitForSeconds(deltaT);
        _tf.position = new Vector3(0f, 0f, 0f);
        _isSleep = true;
    }

    private IEnumerator ChangeTexture(string textureName) {
        Debug.Log(textureName);
        Setting.Outer.mainTexture = Setting.Graph.Graph[textureName].NowTexture.Texture;
        yield return new WaitForSeconds(deltaT / 2.0f);
        Setting.Center.mainTexture = Setting.Graph.Graph[textureName].NowTexture.Texture;
        Setting.NowPoint = textureName;
    }
}