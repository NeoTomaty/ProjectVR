using UnityEngine;
using UnityEngine.UI;

public static class resultscorehold
{
    public static int SetResultScore=0;

}
public class resultScore : MonoBehaviour
{
    [SerializeField] Text resultText;
    [SerializeField] Text HorimotoText;
    [SerializeField] Text HorimotoText2;
    int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        score = ansower.score-45;
        
        resultText.text = $"{score.ToString("D3")}";
        Debug.Log(resultText.text);
        if (ansower.isHorimoto == true)
        {
            HorimotoText.text = ansower.text;
            HorimotoText2.text = ansower.text2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
