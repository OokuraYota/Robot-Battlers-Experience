/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundCamera : MonoBehaviour
{
    [SerializeField]
    float lookAroundSpeed = 1.0f;

    float yRotation;

    //矢印に合わせてカメラを回転させる。
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右矢印キーを押したら右方向に回転する。
            yRotation += Input.GetAxis("Horizontal");
            Debug.Log("右方向に回転");
            transform.eulerAngles = new Vector3(0, yRotation, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            //左矢印キーを押したら左方向に回転する。
            yRotation -= Input.GetAxis("Horizontal");
            Debug.Log("左方向に回転");
            transform.eulerAngles = new Vector3(0, yRotation, 0);
        }
    }
}*/