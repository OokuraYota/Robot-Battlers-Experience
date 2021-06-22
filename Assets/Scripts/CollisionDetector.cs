using System;
using UnityEngine;
using UnityEngine.Events;


public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();

    [SerializeField]
    private TriggerEvent onTriggerStay = new TriggerEvent();

    [SerializeField]
    private TriggerEvent onTriggerExit = new TriggerEvent();

    //現在のColliderDetectorは、Coliider内にオブジェクトが止まっている事しか検出出来ない。
    //オブジェクトがColldierに重なったときも検知出来るようにしたい。

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }
    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other);
    }

    [Serializable]
    public class TriggerEvent: UnityEvent<Collider>
    {

    }
}