using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Material _baseTexture, _offsetTexture; //Grabs alternating Materials in Unity with textures applied.
    [SerializeField] private MeshRenderer _renderer; //Renders a mesh around each instance of a tile.
    [SerializeField] public GameObject _highlight; //Grabs highlight GameObject in Unity.
    
    public void Init(bool isOffset){
        _renderer.material = isOffset ? _offsetTexture : _baseTexture; //Alternately applies textures to each generated Tile for checkerboard pattern.
    }

    void OnMouseEnter(){
        _highlight.SetActive(true); //Shows highlight object.
    }

    void OnMouseExit(){
        _highlight.SetActive(false); //Hides highlight object.
    }

    public void OnMouseDown()
    {
        CameraController.instance.followTransform = transform;
    }

}
