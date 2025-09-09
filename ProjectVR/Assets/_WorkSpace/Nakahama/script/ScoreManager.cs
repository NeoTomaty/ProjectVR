using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] int timeLimit;
    [SerializeField] Text timerText;
    float time;
    int score;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        int remaining = timeLimit - (int)time;
        //timerTextを更新していく
        timerText.text = $"のこり：{remaining.ToString("D3")}";
        if (remaining == 0)
        {
            resultscorehold.SetResultScore = ansower.score;
            SceneManager.LoadScene("reult");
        }

    }
    // シーンを切り替えるメソッド
    

}
