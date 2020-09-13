using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreationHelper
{
    public static void SetLayer(Transform source, int layer, bool excluseParent)
    {
        if(!excluseParent) 
            source.gameObject.layer = layer;

        foreach (Transform trans in source)
            trans.gameObject.layer = layer;
    }
}
