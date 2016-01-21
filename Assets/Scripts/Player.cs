using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int score = 0;

    public int enemyScore = 0;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(score);
        }
        else
        {
            enemyScore = (int)stream.ReceiveNext();   
        }
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return score;
    }

    public void setEnemyScore(int score)
    {
        this.enemyScore = score;
    }

    public int getEnemyScore()
    {
        return enemyScore;
    }
}
