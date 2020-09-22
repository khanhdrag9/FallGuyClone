using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateManyMovingCircleObjects))]
public class CreateManyMovingCircleObjectsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var mine = target as CreateManyMovingCircleObjects;
        int count = Mathf.Max(mine.circles.Count, mine.numberObjects);
        float angle = 360f / mine.numberObjects;
        for(int i = 0; i < count; ++i)
        {
            if(i >= mine.circles.Count)
            {
                mine.CreateCircleObject(angle * i);
            }
            else if(i >= mine.numberObjects)
            {
                for(int rI = i; rI < count; ++rI)
                    DestroyImmediate(mine.circles[i].gameObject);
                mine.circles.RemoveRange(i, count - i);
                break;
            }
            else if(mine.circles[i] == null)
            {
                CircleMovingObject obj = Instantiate(mine.prefab, mine.transform);
                mine.circles[i] = obj;
            }

            mine.SetCircleObject(mine.circles[i], angle * i);
        }

    }
}
