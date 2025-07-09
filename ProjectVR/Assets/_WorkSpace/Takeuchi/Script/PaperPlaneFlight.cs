using UnityEngine;

public class PaperPlaneFlight : MonoBehaviour
{
    [Header("揚力係数（大きいほど浮く）")]
    public float liftCoefficient = 0.5f;
    [Header("空気抵抗係数（大きいほど沈む）")]
    public float dragCoefficient = 0.05f;

    float area = 1.0f; // 翼面積
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.Log("PaperPlaneFlightスクリプトエラー：RigidBodyが見つかりません！");
        }

        // 翼面積を疑似的に計算
        Vector3 scale = transform.localScale;
        area = scale.x * scale.z;
    }

    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        if (velocity.sqrMagnitude < 0.01f) return; // ほぼ停止してたら計算しない

        Vector3 forward = transform.forward;         // 機体の前向き
        Vector3 velDir = velocity.normalized;        // 速度の向き
        float speed = velocity.magnitude;

        // 迎角を求める
        float angleOfAttack = Vector3.SignedAngle(forward, velDir, transform.right) * Mathf.Deg2Rad;

        // 揚力方向を求める
        Vector3 liftDirection = Vector3.Cross(velDir, transform.right).normalized;

        // 揚力計算
        float liftForceMag = 0.5f * liftCoefficient * area * speed * speed * Mathf.Sin(angleOfAttack);
        Vector3 liftForce = liftDirection * liftForceMag;

        // 空気抵抗
        Vector3 dragForce = -velDir * 0.5f * dragCoefficient * area * speed * speed;

        // 総合力を加える
        rb.AddForce(liftForce + dragForce);
    }
}
