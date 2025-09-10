using UnityEngine;


public static class ansower
{
    public static int score = 0;
    public static string text = "君の得点は最高点だけど";
    public static string text2 = "評定はないと思ってね";


    public static bool isHorimoto=false;
}
public class StruckOutManager : MonoBehaviour
{
    public bool isCollided;
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 子に付いている ChildHitbox を全部購読
        var hitboxes = GetComponentsInChildren<ChildObjectManager>();
        foreach (var hitbox in hitboxes)
        {
            hitbox.OnHitboxCollisionEnter += HandleHitboxCollision;
            hitbox.OnHitboxTriggerEnter += HandleHitboxTrigger;
        }
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void HandleHitboxCollision(GameObject child, string type, Collision collision)
    {
        switch (type)
        {
            case "Frame":
                setScore(0);
               
                break;
            case "1":
                setScore(1);
                
                break;
            case "2":
                setScore(2);
               
                break;
            case "3":
                setScore(3);
                
                break;
            case "4":
                setScore(4);
               
                break;
            case "5":
                setScore(5);
               
                break;
            case "6":
                setScore(6);
               
                break;
            case "7":
                setScore(7);
                
                break;
            case "8":
                setScore(8);
                
                break;
            case "9":
                setScore(9);
                
                break;
            case "Human":
                horimoto();
               // setScore(100);
                
                break;
        }
        isCollided = true;
        GetScore();
    }

    void HandleHitboxTrigger(GameObject child, string type, Collider other)
    {
        Debug.Log($"[{type}] トリガー接触: {other.gameObject.name}");
    }
    public int setScore(int point)
    {
        ansower.score += point;

        return ansower.score; // 最新スコアを返す
    }

    public int GetScore()
    {
        return ansower.score; // 参照用
    }
    void horimoto()
    {
        setScore(1000);
        ansower.isHorimoto = true;
    }
}
