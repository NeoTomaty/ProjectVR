using UnityEngine;
using UnityEngine.UI;

public class RingUIManager : MonoBehaviour
{
    [Header("カウントを表示するテキスト")]
    [SerializeField] private Text ringCountText;

    [Header("初期リング数")]
    [SerializeField] private int totalRings = 2;

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
        }
    }
}
