using UnityEngine;
using System.Collections;

public class MalfunctionMove : MonoBehaviour
{
    public GameObject objTarget;
    public Vector3 offset;

    void Start()
    {
        updatePosition();   
    }

    void LateUpdate()
    {
        updatePosition();   
    }

    void updatePosition()
    {
        Vector3 pos = objTarget.transform.localPosition;
    }
}