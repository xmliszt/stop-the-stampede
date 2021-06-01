using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera playerCamera;
    public Camera topCamera;

    private void Start()
    {
        playerCamera.enabled = true;
        topCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            topCamera.enabled = !topCamera.enabled;
            playerCamera.enabled = !playerCamera.enabled;
        }
    }
}
