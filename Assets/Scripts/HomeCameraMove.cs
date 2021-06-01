using UnityEngine;

public class HomeCameraMove : MonoBehaviour
{
    public GameObject focusPoint;

    private float lowestY = 3;
    private float highestY = 8;
    private float cameraMovementSpeed = 0.2f;
    private bool goingUp = true;

    private void Start()
    {
        transform.position = new Vector3(0.39f, lowestY, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(focusPoint.transform);
        if (!goingUp)
        {
            // move down
            transform.Translate(Vector3.down * Time.deltaTime * cameraMovementSpeed);
        }
        if (goingUp)
        {
            //move up
            transform.Translate(Vector3.up * Time.deltaTime * cameraMovementSpeed);
        }
        if (transform.position.y >= highestY)
        {
            goingUp = false;
        }
        if (transform.position.y <= lowestY)
        {
            goingUp = true;
        }
    }
}
