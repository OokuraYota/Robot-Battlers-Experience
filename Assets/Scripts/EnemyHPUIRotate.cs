using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPUIRotate : MonoBehaviour
{
    
    void Start()
    {

    }

    void Update()
    {

    }

    void LateUpdate()
    {
        //  カメラと同じ向きに設定
        //  CameraContorollerを自分が昔Cameraにしていて、それだと自分で作ったクラスが無視されるのでmainメンバは使えない。
        //  だから、Camera.mainのCameraの定義を確認してみる。
        transform.rotation = Camera.main.transform.rotation;
    }
}
