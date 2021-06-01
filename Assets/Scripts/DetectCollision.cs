using UnityEngine;
using System.Linq;

public class DetectCollision : MonoBehaviour
{
    public ParticleSystem bloodEmitter;
    private int score;
    private string[] animals;

    private void Start()
    {
        animals = FindObjectOfType<ScoreManager>().GetAllAnimalTypes();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.tag == "food" && animals.Contains<string>(collision.tag))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            string animalName = collision.tag;
            if (scoreManager.FindAnimalScoreByType(animalName) != null)
            {
                int toAdd = scoreManager.FindAnimalScoreByType(animalName).animalScore;
                Destroy(collision.gameObject);
                Instantiate(bloodEmitter, collision.gameObject.transform.position + new Vector3(0, 5, 0), bloodEmitter.transform.rotation);
                score = PlayerPrefs.GetInt("score", 0);
                score += toAdd;
                PlayerPrefs.SetInt("score", score);
                Destroy(gameObject);
            }
            
        }
        if (gameObject.tag == "Player" && animals.Contains<string>(collision.tag))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
