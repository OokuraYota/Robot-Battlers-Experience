using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Playerに触れた瞬間、オブジェクトを表示する
/// </summary>
public class TheMomentYouTouchActive : MonoBehaviour
{
    /// <summary>
    /// タッチしたらScene遷移するgameObject
    /// </summary>
    [SerializeField]
    public GameObject gameObjectActive;

    [SerializeField]
    public GameObject explanationPanel;

    

    public void Start()
    {
        //gameObjectActiveを非アクティブにしておく。
        gameObjectActive.SetActive(false);
        explanationPanel.SetActive(false);
    }

    /// <summary>
    /// （isTriggerチェック時）触れている間、呼ばれる
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("今、" + collider.gameObject.name + "に接触し続けている。");
        
        //もし、接触し続けているのがPlayerのGameObjectなら
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Tagが、Playerなのでアクティブにします。");
            gameObjectActive.SetActive(true);
            explanationPanel.SetActive(true);

            //上記の状態で、Spaceボタンを押したらSceneの遷移を行う。
            if (Input.GetKey(KeyCode.Space))
            {


                //verticalInput

                //horizontalInput

                //Sceneの遷移を行う
                SceneManager.LoadScene("BattleScene");
            }
        }
    }

    /// <summary>
    /// (isTriggerチェック時)離れた時、呼ばれる
    /// </summary>
    /// <param name="collider"></param>
    public void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider + "と離れたので、対象のものを非表示にします。");
        gameObjectActive.SetActive(false);
        explanationPanel.SetActive(false);
    }
}