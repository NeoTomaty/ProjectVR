using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PaperPlaneGrabHandler : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    public Camera mainCamera;       // VRアバターのカメラ（視線）
    public Camera chaseCamera;      // 紙飛行機を追いかけるサブカメラ

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // 掴んだときのイベント登録
        grabInteractable.selectEntered.AddListener(OnGrab);

        // 離したときのイベント登録
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("紙飛行機を掴んだ！");

    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("紙飛行機を離した！");

        // カメラ切り替え処理
        if (chaseCamera != null) chaseCamera.enabled = true;

        Debug.Log("subcameraを追加しました");

        if (mainCamera != null) mainCamera.enabled = false;

        Debug.Log("maincameraを削除しました");

    }
}
