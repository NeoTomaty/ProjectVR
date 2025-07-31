//StartButtonManager.cs
//作成者:中町雷我
//最終更新日:2025/07/31
//アタッチ:Startボタンにアタッチ
//[Log]
//07/31　中町　Startボタンを押したらステージセレクトシーンにシーン遷移する処理

using UnityEngine; //Unityの基本的な機能を使用するための名前空間
using UnityEngine.SceneManagement; //シーンの管理(切り替えなど)を行うための名前空間

public class StartButtonManager : MonoBehaviour
{
    //インスペクター上で設定可能な次のシーン名
    [SerializeField] private string NextSceneName = "StageSelectScene";

    //スタートボタンが押されたときに呼び出される関数
    public void OnStartButtonPressed()
    {
        //次のシーン名が空でないか確認(nullまたは空文字列でないか)
        if(!string.IsNullOrEmpty(NextSceneName))
        {
            //指定された名前のシーンに切り替える
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            //シーン名が設定されていないときは警告を表示(デバッグ用)
            Debug.LogWarning("次のシーン名が設定されていません！");
        }
    }
}