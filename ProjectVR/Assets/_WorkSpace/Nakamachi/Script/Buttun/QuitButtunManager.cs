//QuitButtunManager.cs
//作成者:中町雷我
//最終更新日:2025/07/31
//アタッチ:Quitボタンにアタッチ
//[Log]
//07/31　中町　Quitボタンを押したらゲーム終了する処理

using UnityEngine; //Unityの基本機能を使用するための名前空間

public class QuitButtunManager : MonoBehaviour
{
    //終了ボタンが押されたときに呼び出される関数
    public void OnQuitButtonPressed()
    {
        //Unityエディター上で実行しているときの処理
        #if UNITY_EDITOR

        //エディターの再生モードを終了する(実際のアプリの終了じゃない)
        UnityEditor.EditorApplication.isPlaying = false;
        #else

        //ビルドされたアプリケーションのときはアプリを終了する
        Application.Quit();
        #endif
    }
}