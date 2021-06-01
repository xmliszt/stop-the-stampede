using UnityEngine;

public class FoodMoveForward : MonoBehaviour
{
    private float foodFlyingSpeed = 20.0f;
    private float thresholdDistance = 30.0f; // z axis

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * foodFlyingSpeed);
        if (transform.position.z > thresholdDistance)
        {
            Destroy(gameObject);
        }
    }
}
