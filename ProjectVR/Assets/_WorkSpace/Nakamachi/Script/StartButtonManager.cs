using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
    [SerializeField] private string NextSceneName = "StageSelectScene";

    public void OnStartButtonPressed()
    {
        if(!string.IsNullOrEmpty(NextSceneName))
        {
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            Debug.LogWarning("Ÿ‚ÌƒV[ƒ“–¼‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñI");
        }
    }
}