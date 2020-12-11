using System;
using UnityEngine;
using UnityEngine.Events;


public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();

    [SerializeField]
    private TriggerEvent onTriggerStay = new TriggerEvent();

    //現在のColliderDetectorは、Coliider内にオブジェクトが止まっていることしけ検出出来ませんので、オブジェクトがColldierに重なったときも検知できるようにしましょう。


    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }

    [Serializable]
    public class TriggerEvent: UnityEvent<Collider>
    {

    }
}
