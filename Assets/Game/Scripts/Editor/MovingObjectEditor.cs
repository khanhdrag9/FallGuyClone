using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingObject))]
public class MovingObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        MovingObject movingObject = target as MovingObject;

        Handles.color = Color.green;
        for (int i = 0; i < movingObject.destinations.Length; ++i)
        {
            Vector3 point2 = movingObject.transform.TransformPoint(movingObject.destinations[i]);
            Vector3 edit = Handles.PositionHandle(point2, Quaternion.identity);
            movingObject.destinations[i] = movingObject.transform.InverseTransformPoint(edit);
            if (i != 0)
            {
                Vector3 point1 = movingObject.transform.TransformPoint(movingObject.destinations[i - 1]);
                Handles.DrawLine(point1, point2);
            }
        }
    }
}
