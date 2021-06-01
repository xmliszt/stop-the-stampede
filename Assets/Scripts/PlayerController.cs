using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject food;

    private float playerSpeed = 20.0f;
    private float horizontalInput;
    private float boundaryRange = 20;
    private float foodReleaseHeight = 3f;

    public Animator playerAnim;
    public Animator barrelAnim;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -boundaryRange)
        {
            transform.position = new Vector3(-boundaryRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > boundaryRange)
        {
            transform.position = new Vector3(boundaryRange, transform.position.y, transform.position.z);
        }

        //Walking
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetBool("Run_b", true);
            barrelAnim.SetBool("Roll_b", true);
            barrelAnim.SetFloat("RollSpeed_f", horizontalInput);
            AudioManager audio = FindObjectOfType<AudioManager>();
            if (!audio.IsPlaying("walk"))
            {
                audio.Loop("walk");
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerAnim.SetBool("Run_b", false);
            barrelAnim.SetBool("Roll_b", false);
            AudioManager audio = FindObjectOfType<AudioManager>();
            if (audio.IsPlaying("walk"))
            {
                audio.Stop("walk");
            }
        }

        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("fire");
            playerAnim.SetBool("Shoot_b", true);
            Instantiate(food, new Vector3(transform.position.x, transform.position.y + foodReleaseHeight, transform.position.z), food.transform.rotation);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetBool("Shoot_b", false);
        }
    }
}
