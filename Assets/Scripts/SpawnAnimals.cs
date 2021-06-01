using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAnimals : MonoBehaviour
{
    public GameObject[] species;

    private float spawnZLocation = 40.0f;
    private float spawnXRange = 20.0f;
    private float invokeDelay = 2;
    private float invokeInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimal", invokeDelay, invokeInterval);
    }

    void SpawnAnimal()
    {
        int selectorIdx = Random.Range(0, species.Length);
        float randomXLocation = Random.Range(-spawnXRange, spawnXRange);
        GameObject animal = species[selectorIdx];
        animal.transform.rotation = Quaternion.Euler(0, 180, 0);
        Instantiate(animal, new Vector3(randomXLocation, 0, spawnZLocation), animal.transform.rotation);
    }
}

