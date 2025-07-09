using UnityEngine; //Unityの基本的な機能を使用するための名前空間
using UnityEngine.SceneManagement; //シーンの管理(切り替えなど)を行うための名前空間

public class StartButtonManager : MonoBehaviour
{
    //インスペクター上で
    [SerializeField] private string NextSceneName = "StageSelectScene";

    public void OnStartButtonPressed()
    {
        if(!string.IsNullOrEmpty(NextSceneName))
        {
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            Debug.LogWarning("次のシーン名が設定されていません！");
        }
    }
}