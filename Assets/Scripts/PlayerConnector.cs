using UnityEngine;
using System.Collections;

public class PlayerConnector : ShapesManager
{
    public int score = 0;

    public int enemyScore = 0;

    Player player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("shapesmanager").GetComponent<Player>();
    }

    void Update()
    {
        player.setScore(getScore());
        enemyScore = player.getEnemyScore();
    }
}
