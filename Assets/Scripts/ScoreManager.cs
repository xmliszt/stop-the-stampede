using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public AnimalScore[] animalScores;

    public AnimalScore FindAnimalScoreByType(string animalType)
    {
        foreach(AnimalScore score in animalScores)
        {
            if (score.animalType == animalType)
            {
                return score;
            }
        }
        return null;
    }

    public string[] GetAllAnimalTypes()
    {
        string[] allTypes = new string[animalScores.Length];
        
        for (int i=0; i<animalScores.Length; i++)
        {
            allTypes[i] = animalScores[i].animalType;
        }

        return allTypes;
    }
}
