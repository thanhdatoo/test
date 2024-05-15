using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform target; // Tham chiếu đến transform của nhân vật
    public Vector2 minXAndY; // Giới hạn tối thiểu của vị trí Camera
    public Vector2 maxXAndY; // Giới hạn tối đa của vị trí Camera

    void LateUpdate()
    {
        if (target != null)
        {
            // Lấy vị trí mong muốn của Camera
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Giới hạn vị trí Camera
            float clampedX = Mathf.Clamp(desiredPosition.x, minXAndY.x, maxXAndY.x);
            float clampedY = Mathf.Clamp(desiredPosition.y, minXAndY.y, maxXAndY.y);

            // Cập nhật vị trí của Camera
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
