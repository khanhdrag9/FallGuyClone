using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorForRenderer : MonoBehaviour
{
    public Color[] colors = new Color[] { Color.red, Color.green, Color.yellow, Color.cyan, Color.blue };

    private void Start()
    {
        UpdateColorRandomly();
    }

    public void UpdateColorRandomly()
    {
        GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
        GetComponent<Renderer>().material.SetColor("_BaseColor", colors[Random.Range(0, colors.Length)]);
    }
}
