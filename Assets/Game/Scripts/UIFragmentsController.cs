using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFragmentsController : MonoBehaviour
{
    public RectTransform[] fragments;

    void Awake()
    {
        foreach (var fragment in fragments)
        {
            fragment.anchoredPosition = Vector3.zero;
            fragment.gameObject.SetActive(false);
        }
    }

}
