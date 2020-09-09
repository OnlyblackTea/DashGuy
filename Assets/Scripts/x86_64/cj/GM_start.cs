using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_start : MonoBehaviour
{
    //start场景
    //开始游戏进入选择地图界面
    public void BeginGame()
    {
        Begin();
    }
    //结束游戏
    public void EndGame()
    {
        End();
    }
    private void Begin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);//地图选择界面序号
    }
    private void End()
    {
        Application.Quit();
    }
}
