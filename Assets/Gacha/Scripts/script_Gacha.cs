using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_Gacha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Pause()
    {
        //【memo】一時停止(時間に×0をする)
        Time.timeScale = 0;
    }

    public void Restart()
    {
        //【memo】再生(時間に×1をする)
        Time.timeScale = 1;
    }

    public void ChangeScene()
    {
        //【memo】シーン番号 1 以上 3 未満 をランダムでロード
        int index = Random.Range(1, 3);
        SceneManager.LoadScene(index);
        Debug.Log("Scene Loaded");
    }

    public void Return()
    {
        //【memo】シーン番号 0 をロード
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
