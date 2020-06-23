using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//                            _ooOoo_    
//                           o8888888o    
//                           88" . "88    
//                           (| -_- |)    
//                            O\ = /O    
//                        ____/`---'\____    
//                      .   ' \\| |// `.    
//                       / \\||| : |||// \    
//                     / _||||| -:- |||||- \    
//                       | | \\\ - /// | |    
//                     | \_| ''\---/'' | |    
//                      \ .-\__ `-` ___/-. /    
//                   ___`. .' /--.--\ `. . __    
//                ."" '< `.___\_<|>_/___.' >'"".    
//               | | : `- \`.;`\ _ /`;.`/ - ` : | |    
//                 \ \ `-. \_ __\ /__ _/ .-` / /    
//         ======`-.____`-.___\_____/___.-`____.-'======    
//                            `=---='    
//    
//         .............................................    
//                  佛祖保佑             永无BUG
public class cubcreat : MonoBehaviour
{
    public AudioSource audio;
    public GameObject JCube;
    public GameObject JLongCube;
    public GameObject FCube;
    public GameObject FLongCube;
    public GameObject DCube;
    public GameObject DLongCube;
    public GameObject KCube;
    public GameObject KLongCube;
    public GameObject PauseManu;
    public GameObject PauseManu_Main;
    public GameObject BeatLine;

    public float hittime;
    public float uptime;
    public float bpm;
    
    public float totaltime;
    public float songPosition;
    public float songPosInBeats;
    public float songLenght;
    
    public float BeatPerSec;//每秒節拍數
    public float SecPerBeat;//节拍的持续时间
    public float SpeedPerSec;//每秒速度
    public float SpeedPerBeat;//每拍移動距離

    public Vector3 DshortSpawn;
    public Vector3 DshortRemove;
    public Vector3 DlongSpawn;
    public Vector3 DlongRemove;

    public Vector3 FshortSpawn;
    public Vector3 FshortRemove;
    public Vector3 FlongSpawn;
    public Vector3 FlongRemove;

    public Vector3 JshortSpawn;
    public Vector3 JshortRemove;
    public Vector3 JlongSpawn;
    public Vector3 JlongRemove;

    public Vector3 KshortSpawn;
    public Vector3 KshortRemove;
    public Vector3 KlongSpawn;
    public Vector3 KlongRemove;

    public Vector3 LineSpawn;
    public Vector3 LineRemove;

    public float advanceBeat;//提前的拍子
    public float afterBeat;//過線後的拍子
    public float BeatAdvanceTime;//提前的秒數
    public float playtime = 3f;//幾秒後撥音樂
    public float PauseTime;
    public float ReplayTime;
    public float totalPauseTime = 0f;

    public float[] DshortNotes;
    public int Dshortnote = 0;

    public float[] FshortNotes;
    public int Fshortnote = 0;

    public float[] JshortNotes;
    public int Jshortnote = 0;

    public float[] KshortNotes;
    public int Kshortnote = 0;

    public float[] DlongNotes;
    public float[] DlongNotesBest;
    public float DlongNoteBeatLenght;
    float DLongCubeLenght;
    public int Dlongnote = 0;

    public float[] FlongNotes;
    public float[] FlongNotesBest;
    public float FlongNoteBeatLenght;
    float FLongCubeLenght;
    public int Flongnote = 0;

    public float[] JlongNotes;
    public float[] JlongNotesBest;
    public float JlongNoteBeatLenght;
    float JLongCubeLenght;
    public int Jlongnote = 0;

    public float[] KlongNotes;
    public float[] KlongNotesBest;
    public float KlongNoteBeatLenght;
    float KLongCubeLenght;
    public int Klongnote = 0;
    float linenote = 0;


    void Start()

    {
        SecPerBeat = 60f / bpm;//一拍幾秒
        BeatPerSec = bpm /60f;//一秒幾拍
        SpeedPerBeat = SpeedPerSec / BeatPerSec;
        BeatAdvanceTime = advanceBeat * SecPerBeat;
        JshortSpawn =new Vector3(11.75f,0,( 5 + (advanceBeat * SpeedPerBeat)));//J短方塊生成點
        JshortRemove = new Vector3(11.75f, 0, (5 - (afterBeat * SpeedPerBeat)));//J短方塊移除點
        FshortSpawn = new Vector3(-11.75f, 0, (5 + (advanceBeat * SpeedPerBeat)));//F短方塊生成點
        FshortRemove = new Vector3(-11.75f, 0, (5 - (afterBeat * SpeedPerBeat)));//F短方塊移除點
        DshortSpawn = new Vector3(-35.25f, 0, (5 + (advanceBeat * SpeedPerBeat)));//D短方塊生成點
        DshortRemove = new Vector3(-35.25f, 0, (5 - (afterBeat * SpeedPerBeat)));//D短方塊移除點
        KshortSpawn = new Vector3(35.25f, 0, (5 + (advanceBeat * SpeedPerBeat)));//K短方塊生成點
        KshortRemove = new Vector3(35.25f, 0, (5 - (afterBeat * SpeedPerBeat)));//K短方塊移除點
        LineSpawn = new Vector3(0, 0, (5 + (advanceBeat * SpeedPerBeat)));
        LineRemove = new Vector3(0, 0, (5 - (afterBeat * SpeedPerBeat)));
    }
    bool played = false;
    bool pause= false;
    void Update()
    {
        totaltime = gameObject.GetComponent<TimeCount>().totaltime - totalPauseTime;

        songPosition = totaltime - playtime;//目前歌曲秒數
        songPosInBeats = songPosition / SecPerBeat;//目前節奏數
        if (totaltime > playtime && !played)
        {
            audio.Play();
            played = true;
        }
        if (Input.GetKeyDown("escape")&&!pause)
        {
            gameObject.GetComponent<TimeCount>().enabled = false;
            PauseTime = (float)AudioSettings.dspTime;
            audio.Pause();
            PauseManu.SetActive(true);
            pause = true;
        }
        else if (pause&& Input.GetKeyDown("escape") || PauseManu_Main.GetComponent<PauseManu>().backtoplay)
        {
            gameObject.GetComponent<TimeCount>().enabled = true;
            ReplayTime = (float)AudioSettings.dspTime;
            totalPauseTime += ReplayTime - PauseTime;
            PauseManu.SetActive(false);
            audio.Play();
            pause = false;
            PauseManu_Main.GetComponent<PauseManu>().backtoplay = false;
        }
        //J短生成
        if (Jshortnote < JshortNotes.Length && (JshortNotes[Jshortnote] * SecPerBeat) +playtime - BeatAdvanceTime < totaltime)
        {
            Jnotespawn();
        }
        //F短生成
        if (Fshortnote < FshortNotes.Length && (FshortNotes[Fshortnote] * SecPerBeat) + playtime - BeatAdvanceTime < totaltime)
        {
            Fnotespawn();
        }
        //D短生成
        if (Dshortnote < DshortNotes.Length && (DshortNotes[Dshortnote] * SecPerBeat) + playtime - BeatAdvanceTime < totaltime)
        {
            Dnotespawn();
        }
        //K短生成
        if (Kshortnote < KshortNotes.Length && (KshortNotes[Kshortnote] * SecPerBeat) + playtime - BeatAdvanceTime < totaltime)
        {
            Knotespawn();
        }
        //F長生成
        if (Flongnote < FlongNotes.Length && (FlongNotes[Flongnote] * SecPerBeat) +playtime - BeatAdvanceTime < totaltime)
        {
            Flongnotespawn();
        }
        //J長生成
        if (Jlongnote < JlongNotes.Length && (JlongNotes[Jlongnote] * SecPerBeat) + playtime - BeatAdvanceTime < totaltime)
        {
            Jlongnotespawn();
        }
        //D長生成
        if (Dlongnote < DlongNotes.Length && (DlongNotes[Dlongnote] * SecPerBeat) + playtime - BeatAdvanceTime < totaltime)
        {
            Dlongnotespawn();
        }
        //K長生成
        if (Klongnote < KlongNotes.Length && (KlongNotes[Klongnote] * SecPerBeat) + playtime - BeatAdvanceTime < totaltime)
        {
            Klongnotespawn();
        }
        if(linenote< songPosInBeats)
        {
            Instantiate(BeatLine, LineSpawn, new Quaternion(0, 0, 0, 0));
            linenote += 4;
        }
        if (songPosition > songLenght)
        {
            SceneManager.LoadScene("Manu");
        }  
    }



    void Jnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        Instantiate(JCube, JshortSpawn, new Quaternion(0, 0, 0, 0));
        Jshortnote++;
    }
    void Fnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        Instantiate(FCube, FshortSpawn, new Quaternion(0, 0, 0, 0));
        Fshortnote++;
    }
    void Dnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        Instantiate(DCube, DshortSpawn, new Quaternion(0, 0, 0, 0));
        Dshortnote++;
    }
    void Knotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        Instantiate(KCube, KshortSpawn, new Quaternion(0, 0, 0, 0));
        Kshortnote++;
    }
    void Flongnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        uptime = hittime + (FlongNotesBest[Flongnote] * SecPerBeat);//鬆開的時機
        FlongNoteBeatLenght = FlongNotesBest[Flongnote];
        FLongCubeLenght = (FlongNotesBest[Flongnote] - 1) * SpeedPerBeat;
        FLongCube.transform.localScale = new Vector3(15, 1, FLongCubeLenght + 3);
        FlongSpawn = new Vector3(-11.75f, 0, (5 + (advanceBeat * SpeedPerBeat) + (FLongCubeLenght / 2)));//長方塊生成點
        FlongRemove = new Vector3(-11.75f, 0, (5 - ((afterBeat * SpeedPerBeat) + (FLongCubeLenght / 2))));//長方塊移除點
        Instantiate(FLongCube, FlongSpawn, new Quaternion(0, 0, 0, 0));
        Flongnote++;
    }
    void Jlongnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        uptime = hittime + (JlongNotesBest[Jlongnote] * SecPerBeat);//鬆開的時機
        JlongNoteBeatLenght = JlongNotesBest[Jlongnote];
        JLongCubeLenght = (JlongNotesBest[Jlongnote] - 1) * SpeedPerBeat;
        JLongCube.transform.localScale = new Vector3(15, 1, JLongCubeLenght + 3);
        JlongSpawn = new Vector3(11.75f, 0, (5 + (advanceBeat * SpeedPerBeat) + (JLongCubeLenght / 2)));//長方塊生成點
        JlongRemove = new Vector3(11.75f, 0, (5 - ((afterBeat * SpeedPerBeat) + (JLongCubeLenght / 2))));//長方塊移除點
        Instantiate(JLongCube, JlongSpawn, new Quaternion(0, 0, 0, 0));
        Jlongnote++;
    }
    void Dlongnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        uptime = hittime + (DlongNotesBest[Dlongnote] * SecPerBeat);//鬆開的時機
        DlongNoteBeatLenght = DlongNotesBest[Dlongnote];
        DLongCubeLenght = (DlongNotesBest[Dlongnote] - 1) * SpeedPerBeat;
        DLongCube.transform.localScale = new Vector3(15, 1, DLongCubeLenght + 3);
        DlongSpawn = new Vector3(-35.25f, 0, (5 + (advanceBeat * SpeedPerBeat) + (DLongCubeLenght / 2)));//長方塊生成點
        DlongRemove = new Vector3(-35.25f, 0, (5 - ((afterBeat * SpeedPerBeat) + (DLongCubeLenght / 2))));//長方塊移除點
        Instantiate(DLongCube, DlongSpawn, new Quaternion(0, 0, 0, 0));
        Dlongnote++;
    }
    void Klongnotespawn()
    {
        hittime = songPosition + (advanceBeat * SecPerBeat);
        uptime = hittime + (KlongNotesBest[Klongnote] * SecPerBeat);//鬆開的時機
        KlongNoteBeatLenght = KlongNotesBest[Klongnote];
        KLongCubeLenght = (KlongNotesBest[Klongnote] - 1) * SpeedPerBeat;
        KLongCube.transform.localScale = new Vector3(15, 1, KLongCubeLenght + 3);
        KlongSpawn = new Vector3(35.25f, 0, (5 + (advanceBeat * SpeedPerBeat) + (KLongCubeLenght / 2)));//長方塊生成點
        KlongRemove = new Vector3(35.25f, 0, (5 - ((afterBeat * SpeedPerBeat) + (KLongCubeLenght / 2))));//長方塊移除點
        Instantiate(KLongCube, KlongSpawn, new Quaternion(0, 0, 0, 0));
        Klongnote++;
    }
}
