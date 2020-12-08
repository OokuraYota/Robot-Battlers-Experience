using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    private TriggerEvent onTringgerStay = new TriggerEvent();

    private void OnTriggerStay(Collider other)
    {
        //onTriggerStayで指定された処理を実行する
        onTringgerStay.Invoke(other);
    }

    //UnityEvnetを継承したクラスに[Serializable]属性を付与することで、Inspectorウインドウ上に表示が出来るようになる
    [Serializable]
    private class TriggerEvent : UnityEvent<Collider>
    {
        /*
         * UnityEventを使用することで、Inspectorウインドウ上から『任意のタイミングで呼び出したいメソッド』を指定できるようになる。
         * 今回のスクリプトでは、CollisionDetectorと別のColliderが重なっているときにonTriggerStayで指定したメソッドを呼び出し、重なったColliderのインスタンスを渡すよう実装しています。
         * この書き方であれば、onTriggerStayで実行されるメソッドをInspectorウインドウ上から設定出来ますので、CollisionDetectorの衝突判定の結果を、任意のオブジェクトの任意メソッドで受け取れるようにしました。
        */
    }
}