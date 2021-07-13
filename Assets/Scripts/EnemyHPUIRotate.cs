using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPUIRotate : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayCamera;

    void Start()
    {
        PlayCamera = GameObject.Find("Main Camera");
    }

    void LateUpdate()
    {
        transform.rotation = PlayCamera.transform.rotation;
    }
}
