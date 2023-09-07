using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{

    private MeshRenderer _mesh;
    public float animationSpeed = 1f;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
           _mesh.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

}
