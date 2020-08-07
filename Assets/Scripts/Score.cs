using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text score;
    public static int scoreByEnemy = 0;
    public static int scoreByGems = 0;
    public static int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = scoreByEnemy + scoreByGems;
        score.text = "Score: " + scoreValue.ToString();
    }
}
