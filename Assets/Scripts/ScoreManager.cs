using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;
    }
}
