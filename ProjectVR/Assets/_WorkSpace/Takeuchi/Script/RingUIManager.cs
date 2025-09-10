using UnityEngine;
using UnityEngine.UI;

public class RingUIManager : MonoBehaviour
{
    [Header("カウントを表示するテキスト")]
    [SerializeField] private Text ringCountText;

    [Header("初期リング数")]
    [SerializeField] private int totalRings = 3;

    [Header("シーン管理オブジェクト")]
    [SerializeField] private SceneChanger sceneChanger;

    [Header("輪っかを通過した際の出現テキスト")]
    [SerializeField] private Text successText;

    private int remainingRings;

    void Start()
    {
        remainingRings = totalRings;
        UpdateUI();
    }

    // リング通過時に呼び出す
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

            // リングの数が０の場合
            if (remainingRings == 0)
            {
                sceneChanger.SetCanChangeScene(true);

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
    }
}
