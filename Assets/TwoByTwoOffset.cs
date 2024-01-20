using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoByTwoOffset : MonoBehaviour
{
    public GameObject Piece;
    void Start()
    {

        // Set the internal position (what the game thinks)

        // Set the rendered position (what is actually displayed)
        MeshRenderer meshRenderer = Piece.GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            meshRenderer.enabled = true; // Make sure the mesh renderer is enabled
            meshRenderer.material.mainTextureOffset = new Vector2(1, 1);
        }

        // Add more game objects and apply the same logic...
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
