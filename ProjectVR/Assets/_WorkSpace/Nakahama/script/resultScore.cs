using UnityEngine;
using UnityEngine.UI;

public static class resultscorehold
{
    public static int SetResultScore=0;

}
public class resultScore : MonoBehaviour
{
    [SerializeField] Text resultText;
    int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = ansower.score-45;
        resultText.text = $"{score.ToString("D3")}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
