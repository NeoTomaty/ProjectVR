using UnityEngine;


// 自由に重力を与えることができるスクリプト
[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    [Header("重力の方向")]
    public Vector3 gravityDirection = Vector3.down; // 重力の方向
    [Header("重力の強さ")]
    public float gravityStrength = 9.81f;           // 重力の強さ
    [Header("重力の加速度")]
    

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Unity標準の重力を無効化
    }

    void FixedUpdate()
    {
        Vector3 customGravity = gravityDirection.normalized * gravityStrength;
        rb.AddForce(customGravity, ForceMode.Acceleration);
    }
}
