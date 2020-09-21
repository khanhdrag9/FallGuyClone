using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManyMovingObjects : MonoBehaviour
{
    public MovingObject movingPrefab;
    public Vector3[] destinations;
    public int numberObjects;
    public float applySpeed;

    void Start()
    {
        //calculate distance between objects
        float totalLength = (destinations[0] - destinations[destinations.Length - 1]).magnitude;
        for(int i = 1; i < destinations.Length; ++i)
        {
            totalLength += (destinations[i - 1] - destinations[i]).magnitude;
        }
        float distanceBetweenObjects = totalLength / (float)numberObjects;

        Vector3 oPos = destinations[0];
        float tempDistance = 0f;

        for(int i = 0; i < destinations.Length; ++i)
        {
            Vector3 des1 = destinations[i];
            int indexDes2 = i == destinations.Length - 1 ? 0 : i + 1;
            Vector3 des2 = destinations[indexDes2];

            oPos = Vector3.MoveTowards(des1, des2, tempDistance);
            while((oPos - des2).magnitude >= distanceBetweenObjects)
            {
                CreateMovingObject(oPos, indexDes2);
                oPos = Vector3.MoveTowards(oPos, des2, distanceBetweenObjects);
            }

            if((oPos - des2).magnitude == 0)
                tempDistance = 0;
            else
                tempDistance = distanceBetweenObjects - (oPos - des2).magnitude;
        }
    }

    void CreateMovingObject(Vector3 position, int indexDes)
    {
        MovingObject obj = Instantiate(movingPrefab, transform);
        obj.transform.position = position;
        obj.destinations = destinations;
        obj.SetCurrentTo(indexDes);
        obj.movementSpeed = applySpeed;
    }
}
