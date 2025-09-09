using UnityEngine;

public class ChildObjectManager : MonoBehaviour
{
    public string hitboxType; // —á: "Head", "Body", "Leg" ‚È‚Ç

    public delegate void HitboxCollision(GameObject child, string type, Collision collision);
    public delegate void HitboxTrigger(GameObject child, string type, Collider other);

    public event HitboxCollision OnHitboxCollisionEnter;
    public event HitboxTrigger OnHitboxTriggerEnter;

    void OnCollisionEnter(Collision collision)
    {
        OnHitboxCollisionEnter?.Invoke(gameObject, hitboxType, collision);
    }

    void OnTriggerEnter(Collider other)
    {
        OnHitboxTriggerEnter?.Invoke(gameObject, hitboxType, other);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
