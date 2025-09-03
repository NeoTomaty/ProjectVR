using UnityEngine;
using UnityEngine.UI; // CanvasのTextを扱う場合

public class ThroughRing : MonoBehaviour
{
    // 投げるオブジェクトに付けたタグ名
    [SerializeField] private string targetTag = "Throwable";

    // UI管理オブジェクト
    [SerializeField] private RingUIManager ringUIManager;

    [Header("輪っかを通過した際の出現テキスト")]
    [SerializeField] private Text successText;


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
                Destroy(transform.parent.gameObject);
                ringUIManager.RingPassed();
            }
            else
            {
                // 念のため、親がない場合は自分自身を削除
                Destroy(gameObject);
            }
        }

        // Canvasのテキストを表示
        if (successText != null)
        {
            successText.gameObject.SetActive(true); // 表示
        }
        else
        {
            Debug.Log("参照テキストが指定されていません！");
        }
    }
}
