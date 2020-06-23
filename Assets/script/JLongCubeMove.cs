using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLongCubeMove : MonoBehaviour
{
    public AudioClip clappy;
    public AudioSource hiteffect;
    public GameObject Cubecreate;
    public GameObject KeyJ;
    public GameObject ScoreText;
    public Material[] materials;

    Vector3 StartPosition;
    Vector3 EndPosition;
    float songPosition;
    float lastsongPosition;
    Vector3 move;
    public float hittime;
    public float uptime;
    float timechange;
    float SpeedPerSec;
    float SecPerBeat;
    float Jpresstime;
    float longNoteBeatLenght;
    int longNoteBeatPos = 1;
    public bool Jkeeppress;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "JLongCube(Clone)")
        {
            gameObject.tag = "longnotes";
        }

        //Fpresstime = KeyF.GetComponent<F>().presstime;
        longNoteBeatLenght = Cubecreate.GetComponent<cubcreat>().JlongNoteBeatLenght;//方塊幾拍長
        songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//目前時間
        lastsongPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//上一幀時間
        SpeedPerSec = Cubecreate.GetComponent<cubcreat>().SpeedPerSec;
        SecPerBeat = Cubecreate.GetComponent<cubcreat>().SecPerBeat;
        hittime = Cubecreate.GetComponent<cubcreat>().hittime;//生成時的拍子 - 提前的拍子 = 觸發的拍子
        uptime = Cubecreate.GetComponent<cubcreat>().uptime;//觸發的拍子 +本身的長度拍子 = 鬆開的拍子
        StartPosition = Cubecreate.GetComponent<cubcreat>().JlongSpawn;//生成位置
        EndPosition = Cubecreate.GetComponent<cubcreat>().JlongRemove;//停止位置
        move = StartPosition;
    }
    public bool firsthit = false;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "longnotes")
        {

            songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;
            timechange = songPosition - lastsongPosition;//一幀時間變化
            Jpresstime = KeyJ.GetComponent<JKey>().presstimej;
            Jkeeppress = KeyJ.GetComponent<JKey>().keeppressj;
            //Debug.Log(timechange);
            if (!firsthit)
            {
                if (Jpresstime < hittime + 0.125f && Jpresstime > hittime - 0.15f)
                {
                    this.GetComponent<Renderer>().sharedMaterial = materials[1];
                    ScoreText.GetComponent<Score>().Combo += 1;
                    firsthit = true;
                    hiteffect.PlayOneShot(clappy);
                }
                else if (songPosition > hittime + 0.125f)
                {
                    Debug.Log(Jkeeppress);
                    ScoreText.GetComponent<Score>().Combo = 0;
                    gameObject.SetActive(false);
                }
            }
            else
            {
                if (songPosition < uptime + 0.125f)
                {
                    
                    if (Jkeeppress)
                    {
                        
                        if (longNoteBeatPos < (longNoteBeatLenght * 2) - 1 && songPosition > hittime + ((SecPerBeat / 2) * longNoteBeatPos))
                        {
                            ScoreText.GetComponent<Score>().Combo += 1;
                            longNoteBeatPos += 1;
                        }
                    }
                    else if (songPosition < uptime - 0.5f)
                    {
                        ScoreText.GetComponent<Score>().Combo = 0;
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        ScoreText.GetComponent<Score>().Combo += 1 + ((int)((longNoteBeatLenght * 2) - 1) - longNoteBeatPos);
                        gameObject.SetActive(false);
                    }

                }

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
