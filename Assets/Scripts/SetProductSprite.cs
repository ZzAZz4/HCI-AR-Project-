using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetProductSprite : MonoBehaviour
{
    [SerializeField]
    GameObject product;
    [SerializeField]
    Mesh myMeshFilter;
    [SerializeField]
    Material newMaterial;
    
    public void UpdateSprite ()
    {
        MeshFilter productMeshFilter = product.GetComponent<MeshFilter>();
        productMeshFilter.sharedMesh = myMeshFilter;
        productMeshFilter.GetComponent<Renderer>().material = newMaterial;
    }
}
