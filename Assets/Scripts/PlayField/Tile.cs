using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material _baseTexture, _offsetTexture;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    
    public void Init(bool isOffset){
        _renderer.material = isOffset ? _offsetTexture : _baseTexture;
    }

    void OnMouseEnter(){
        _highlight.SetActive(true);
    }

    void OnMouseExit(){
        _highlight.SetActive(false);
    }

}
