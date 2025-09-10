using UnityEngine;
using UnityEngine.UI; // CanvasのTextを扱う場合

public class PassRing : MonoBehaviour
{
    // 投げるオブジェクトに付けたタグ名
    [SerializeField] private string targetTag = "Throwable";

    // UI管理オブジェクト
    [SerializeField] private RingUIManager ringUIManager;

    // シーン遷移管理オブジェクト
    [SerializeField] private SceneChanger sceneChanger;



    // トリガーに入った瞬間に呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // もし触れたオブジェクトが投げるオブジェクトなら
        if (other.CompareTag(targetTag))
        {
            Debug.Log("輪っかを通過しました！");


            // 親オブジェクトを削除
            if (transform.parent != null)
            {
                ringUIManager.RingPassed();
                Destroy(transform.parent.gameObject);
            }
            else
            {
                // 念のため、親がない場合は自分自身を削除
                Destroy(gameObject);
            }
        }

    }
}
