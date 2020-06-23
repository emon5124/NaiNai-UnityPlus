using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : MonoBehaviour
{

    public GameObject Cubecreate;
    Vector3 StartPosition;
    Vector3 EndPosition;
    float songPosition;
    float lastsongPosition;
    Vector3 move;
    float timechange;
    float SpeedPerSec;
    // Start is called before the first frame update
    void Start()
    {
        songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//目前時間
        lastsongPosition = Cubecreate.GetComponent<cubcreat>().songPosition;//上一幀時間
        SpeedPerSec = Cubecreate.GetComponent<cubcreat>().SpeedPerSec;
        StartPosition = Cubecreate.GetComponent<cubcreat>().LineSpawn;//生成位置
        EndPosition = Cubecreate.GetComponent<cubcreat>().LineRemove;//停止位置
        move = StartPosition;
    }


    // Update is called once per frame
    void Update()
    {
        songPosition = Cubecreate.GetComponent<cubcreat>().songPosition;
        timechange = songPosition - lastsongPosition;//一幀時間變化

        if (move.z >= EndPosition.z)
        {
            move.z -= SpeedPerSec * timechange;
            move = new Vector3(move.x, move.y, move.z);
            this.transform.position = move;
        }

        lastsongPosition = songPosition;
    }
}
