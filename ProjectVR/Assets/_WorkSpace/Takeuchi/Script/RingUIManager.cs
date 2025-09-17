using UnityEngine;
using TMPro;  // ← 追加

public class RingUIManager : MonoBehaviour
{
    [Header("カウントを表示するテキスト")]
    [SerializeField] private TextMeshPro ringCountText;  // ← Text ではなく TextMeshPro

    [Header("初期リング数")]
    [SerializeField] private int totalRings = 3;

    [Header("シーン管理オブジェクト")]
    [SerializeField] private SceneChanger sceneChanger;

    [Header("輪っかを通過した際の出現テキスト")]
    [SerializeField] private TextMeshPro successText;  // ← これも

    private int remainingRings;

    void Start()
    {
        remainingRings = totalRings;
        UpdateUI();
    }

    public void RingPassed()
    {
        remainingRings--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (ringCountText != null)
        {
            ringCountText.text = "Ring: " + Mathf.Max(remainingRings, 0);

            if (remainingRings == 0)
            {
                sceneChanger.SetCanChangeScene(true);

                if (successText != null)
                {
                    successText.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("参照テキストが指定されていません！");
                }
            }
        }
    }
}
