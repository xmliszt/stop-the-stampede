using UnityEngine;

public class AnimalMoveForward : MonoBehaviour
{
    private float[] speedRange = {3.0f, 8.0f};
    private float thresholdDistance = -20.0f; // z axis
    private float gameoverDistance = 0; // z axis

    private void Start()
    {
        Invoke("RandomInvokeAnimalSound", 2);
    }

    private void RandomInvokeAnimalSound()
    {
        float randomInverval = Random.Range(2.0f, 5.0f);
        InvokeRepeating("PlayAnimalSound", 0, randomInverval);
    }

    private void PlayAnimalSound()
    {
        string animalName = gameObject.tag;
        string[] choices;
        switch (animalName)
        {
            case "moose": case "stag":
                choices = new string[]{"moose", "moose2"};
                break;
            case "dog": case "bernard": case "ridgeback":
                choices = new string[] { "dog", "dog2" };
                break;
            case "cow":
                choices = new string[] { "cow" };
                break;
            default:
                choices = new string[] { "moose", "moose2", "dog", "dog2", "cow" };
                break;
        }
        int randomIdx = Random.Range(0, choices.Length);
        FindObjectOfType<AudioManager>().Play(choices[randomIdx]);
    }

    // Update is called once per frame
    void Update()
    {
        float animalSpeed = Random.Range(speedRange[0], speedRange[1]);
        transform.Translate(Vector3.forward * Time.deltaTime * animalSpeed);
        if (transform.position.z < thresholdDistance)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < gameoverDistance)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
