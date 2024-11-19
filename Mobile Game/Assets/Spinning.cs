using UnityEngine;

public class OrbitingObjectWithBoost : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform centerObject; // The object to orbit around
    public float orbitRadius = 2f; // Radius of the orbit
    public float orbitSpeed = 50f; // Normal speed of the orbit
    public float boostSpeed = 150f; // Speed during boost (holding left mouse button)

    private float angle; // Current angle of rotation
    private int direction = 1; // 1 for clockwise, -1 for counterclockwise

    void Update()
    {
        if (centerObject == null)
        {
            Debug.LogWarning("Center object is not assigned!");
            return;
        }

        // Check for left mouse button to toggle direction
        if (Input.GetMouseButtonDown(0)) // On mouse click
        {
            direction *= -1; // Toggle direction
        }

        // Determine speed (normal or boosted)
        float currentSpeed = Input.GetMouseButton(0) ? boostSpeed : orbitSpeed;

        // Increment the angle based on speed, direction, and time
        angle += direction * currentSpeed * Time.deltaTime;

        // Convert angle to radians
        float angleInRadians = angle * Mathf.Deg2Rad;

        // Calculate the new position
        float x = centerObject.position.x + Mathf.Cos(angleInRadians) * orbitRadius;
        float y = centerObject.position.y + Mathf.Sin(angleInRadians) * orbitRadius;

        // Apply the new position
        transform.position = new Vector2(x, y);
    }
}
