using UnityEngine;

public class SimpleForwardMovement : MonoBehaviour
{
    // Adjust this speed to control how fast the character moves
    public float movementSpeed = 5.0f;

    void Update()
    {
        // Move the character forward along its own forward axis
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}