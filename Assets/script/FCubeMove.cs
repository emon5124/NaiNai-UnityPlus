using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCubeMove : MonoBehaviour
{
    public AudioClip clappy;
    public AudioSource hiteffect;
    public GameObject Cubecreate;
    public GameObject KeyF;
    public GameObject ScoreText;
    Vector3 StartPosition;
    Vector3 EndPosition;
    float songPosition;
    float lastsongPosition;
    Vector3 move;
    public float hittime;
    float timechange;
    float SpeedPerSec;
    float Fpresstime;
    // Start is called before the first frame update
    void Start()
    {
        KeyF = GameObject.Find("F");

        if (gameObject.name == "FCube(Clone)")
        {
            gameObject.tag = "notes";
        }

        Fpresstime = KeyF.GetComponent<F>().presstimef;

        songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//目前時間
        lastsongPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//上一幀時間
        SpeedPerSec = Cubecreate.GetComponent<cubcreat>().SpeedPerSec;
        hittime = Cubecreate.GetComponent<cubcreat>().hittime;//生成時的拍子 - 提前的拍子 = 觸發的拍子
        StartPosition = Cubecreate.GetComponent<cubcreat>().FshortSpawn;//生成位置
        EndPosition = Cubecreate.GetComponent<cubcreat>().FshortRemove;//停止位置
        move = StartPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "notes")
        {

            songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;
            timechange = songPosition - lastsongPosition;//一幀時間變化
            Fpresstime = KeyF.GetComponent<F>().presstimef;
            //Debug.Log(hittime);

            if (Fpresstime < hittime + 0.125f && Fpresstime > hittime - 0.15f)
            {
                ScoreText.GetComponent<Score>().Combo += 1;
                hiteffect.PlayOneShot(clappy);
                gameObject.SetActive(false);
            }
            if (songPosition > hittime + 0.1f)
            {
                ScoreText.GetComponent<Score>().Combo = 0;
                gameObject.SetActive(false);
            }

            if (move.z >= EndPosition.z)
            {
                move.z -= SpeedPerSec * timechange;
                move = new Vector3(move.x, move.y, move.z);
                this.transform.position = move;
            }

            lastsongPosition = songPosition;//儲存上一幀時間
        }
    }
}
