using UnityEngine;
using UnityEngine.InputSystem;

public class ChaseCamera : MonoBehaviour
{
    public Transform target;          // 紙飛行機
    public float distance = 10f;      // 追従距離
    public float rotationSpeed = 50f; // 回転速度

    public enum StickChoice { Left, Right }
    public StickChoice activeStick = StickChoice.Right;

    private Vector2 input;

    void Update()
    {
        if (target == null) return;


        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ToggleStick(); // Tキーでスティック切り替え
        }

        // 入力取得（XR Controllerでも可、ここではInputSystem）
        input = GetStickInput();

        // 紙飛行機を中心にカメラを回転させる
        RotateAroundTarget(input);

        // 常にターゲットから一定距離に保ちつつ、向く
        MaintainDistanceAndLook();
    }

    private Vector2 GetStickInput()
    {
        Vector2 result = Vector2.zero;

        if (activeStick == StickChoice.Left)
        {
            result = Gamepad.current?.leftStick.ReadValue() ?? Vector2.zero;
        }
        else
        {
            result = Gamepad.current?.rightStick.ReadValue() ?? Vector2.zero;
        }

        return result;
    }

    private void RotateAroundTarget(Vector2 stickInput)
    {
        if (stickInput == Vector2.zero) return;

        // 水平回転（左右） → Y軸回転
        transform.RotateAround(target.position, Vector3.up, stickInput.x * rotationSpeed * Time.deltaTime);

        // 垂直回転（上下） → カメラの右方向を軸に仰俯角回転
        Vector3 right = transform.right;
        transform.RotateAround(target.position, right, -stickInput.y * rotationSpeed * Time.deltaTime);
    }

    private void MaintainDistanceAndLook()
    {
        Vector3 dir = (transform.position - target.position).normalized;
        transform.position = target.position + dir * distance;
        transform.LookAt(target.position);
    }

    // 切り替え用関数（外部から呼び出し）
    public void ToggleStick()
    {
        activeStick = (activeStick == StickChoice.Left) ? StickChoice.Right : StickChoice.Left;
    }
}
