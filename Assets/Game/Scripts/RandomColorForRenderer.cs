using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RandomColorForRenderer : NetworkBehaviour
{
    public Color[] colors = new Color[] { Color.red, Color.green, Color.yellow, Color.cyan, Color.blue };

    [SyncVar(hook = nameof(UpdateColorRandomly))]
    public Color Color;
    public bool isChild = false;

    void Start()
    {
        if(isServer)
            Color = colors[Random.Range(0, colors.Length)];
    }

    public void UpdateColorRandomly(Color oldColor, Color newColor)
    {   
        Renderer renderer = null;
        if(isChild)
            renderer = GetComponentInChildren<Renderer>();
        else
            renderer = GetComponent<Renderer>();
        
        // renderer.material.color = Color;
        renderer.material.SetColor("_BaseColor", newColor);
    }
}
