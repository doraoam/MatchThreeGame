using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int score = 0;

    public int enemyScore = 0;

    ShapesManager main;

    void Awake()
    {
        main = GameObject.FindGameObjectWithTag("shapesmanager").GetComponent<ShapesManager>();
    }

    public void setScore()
    {
        score = main.getScore();        
    }

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
}
