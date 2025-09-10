using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // ← これが必要

public class SceneChanger : MonoBehaviour
{
    // 遷移先のシーン名（Inspectorで設定してもOK）
    [SerializeField] private string nextSceneName = "NextScene";

    // シーン遷移が有効かどうかを管理するフラグ
    private bool canChangeScene = false;

    [Header("シーン遷移するまでの時間")]
    [SerializeField] private float fadeTime = 5f;

    [Header("クリア時に出すエフェクト")]
    [SerializeField] private GameObject hitEffectPrefab;

    [Header("クリア時に出すエフェクトの座標")]
    [SerializeField] private Vector3 hitEffectPos;


    void Update()
    {
        // フラグが立ったらシーン遷移
        if (canChangeScene == true)
        {
            // エフェクトを出す
            Instantiate(hitEffectPrefab, hitEffectPos, Quaternion.identity);

            StartCoroutine(ChangeSceneAfterDelay(fadeTime)); // ○秒後にシーン遷移
        }
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }

    // フラグを自由に変更できる関数
    public void SetCanChangeScene(bool value)
    {
        canChangeScene = value;
    }
}
