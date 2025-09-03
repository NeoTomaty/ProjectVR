using UnityEngine;

public class ThroughRing : MonoBehaviour
{
    // 投げるオブジェクトに付けたタグ名
    [SerializeField] private string targetTag = "Throwable";

    // トリガーに入った瞬間に呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // もし触れたオブジェクトが投げるオブジェクトなら
        if (other.CompareTag(targetTag))
        {
            Debug.Log("輪っかを通過しました！");
            // 成功判定の処理をここに書く
            // 例: スコア加算やエフェクト再生など
        }
    }
}
