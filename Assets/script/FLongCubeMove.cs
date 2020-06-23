using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLongCubeMove : MonoBehaviour
{
    public AudioClip clappy;
    public AudioSource hiteffect;
    public GameObject Cubecreate;
    public GameObject KeyF;
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
    float Fpresstime;
    float longNoteBeatLenght;
    int longNoteBeatPos=1;
    public bool Fkeeppress;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "FLongCube(Clone)")
        {
            gameObject.tag = "longnotes";
        }
        longNoteBeatLenght = Cubecreate.GetComponent<cubcreat>().FlongNoteBeatLenght;//方塊幾拍長
        songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//目前時間
        lastsongPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//上一幀時間
        SpeedPerSec = Cubecreate.GetComponent<cubcreat>().SpeedPerSec;
        SecPerBeat = Cubecreate.GetComponent<cubcreat>().SecPerBeat;
        hittime = Cubecreate.GetComponent<cubcreat>().hittime;//生成時的拍子 - 提前的拍子 = 觸發的拍子
        uptime = Cubecreate.GetComponent<cubcreat>().uptime;//觸發的拍子 +本身的長度拍子 = 鬆開的拍子
        StartPosition = Cubecreate.GetComponent<cubcreat>().FlongSpawn;//生成位置
        EndPosition = Cubecreate.GetComponent<cubcreat>().FlongRemove;//停止位置
        move = StartPosition;
    }

    bool firsthit = false;
    void Update()
    {
        if (gameObject.tag == "longnotes")
        {
            
            songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;
            timechange = songPosition - lastsongPosition;//一幀時間變化
            Fpresstime = KeyF.GetComponent<F>().presstimef;
            Fkeeppress = KeyF.GetComponent<F>().keeppressf;
            if (!firsthit)
            {
                if (Fpresstime < hittime + 0.125f && Fpresstime > hittime - 0.15f)
                {
                    
                    this.GetComponent<Renderer>().sharedMaterial = materials[1];
                    
                    ScoreText.GetComponent<Score>().Combo += 1;
                    firsthit = true;
                    hiteffect.PlayOneShot(clappy);
                }
                else if (songPosition > hittime + 0.1f)
                {
                    ScoreText.GetComponent<Score>().Combo = 0;
                    gameObject.SetActive(false);
                }
            }
            else
            {
                if (songPosition < uptime+0.125f )
                {
                    if (Fkeeppress)
                    {
                        if (longNoteBeatPos < (longNoteBeatLenght*2)-1 && songPosition > hittime + ((SecPerBeat/2)*longNoteBeatPos))
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
                        ScoreText.GetComponent<Score>().Combo += 1+ ((int)((longNoteBeatLenght * 2) - 1)- longNoteBeatPos);
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
