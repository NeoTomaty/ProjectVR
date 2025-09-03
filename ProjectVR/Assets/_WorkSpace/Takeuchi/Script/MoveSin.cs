using UnityEngine;

public class MoveSin : MonoBehaviour
{
    [Header("ƒTƒCƒ“”gİ’è")]
    public float amplitude = 1f; // U•
    public float frequency = 1f; // ü”g”i1•b‚ ‚½‚è‚ÌüŠúj

    private Vector3 startPos;

    void Start()
    {
        // Å‰‚ÌˆÊ’u‚ğ‹L˜^
        startPos = transform.position;
    }

    void Update()
    {
        // ƒTƒCƒ“”gŒvZ
        float yOffset = Mathf.Sin(Time.time * frequency * 2f * Mathf.PI) * amplitude;

        // Œ³‚ÌˆÊ’u‚É‰ÁZ‚µ‚ÄˆÚ“®
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
}
