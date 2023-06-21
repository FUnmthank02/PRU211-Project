using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour

{
    public Transform target; // Reference to the player's transform

    public float followSpeed = 2f; // Speed at which the camera follows the player
    public float halfScreenWidthPercentage = 0.5f; // Percentage of the screen width where the camera starts following
    public float verticalOffset = 2f; // Offset in the vertical direction between the camera and the player

    private float screenWidth;
    private float screenHeight;
    private float targetYPosition;
    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = target.position;
        Vector3 currentPosition = transform.position;

        float halfScreenWidth = screenWidth * halfScreenWidthPercentage;
        float targetXPosition = Mathf.Clamp(targetPosition.x, currentPosition.x - halfScreenWidth, currentPosition.x + halfScreenWidth);

        float targetHeight = targetPosition.y + verticalOffset;
        targetYPosition = Mathf.Lerp(targetYPosition, targetHeight, followSpeed * Time.deltaTime);

        Vector3 desiredPosition = new Vector3(targetXPosition, targetYPosition, currentPosition.z);

        transform.position = Vector3.Lerp(currentPosition, desiredPosition, followSpeed * Time.deltaTime);
    }
}
