using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_run : MonoBehaviour
{
    //用于判断游戏是否处于暂停状态
    public bool isPaused = true;
    public GameObject menuGO;
    public GameObject buttonPause;
    public GameObject buttonRestart;
    public GameObject Player;
    
    //run场景
    //使菜单初始不可见
    private void  Awake() {
        UnPause();
        gameRead();
    }
    //暂停游戏并隐藏暂停和重置按钮
    public void PauseGame()
    {
        Pause();
    }
    //继续游戏
    public void ContinueGame()
    {
        UnPause();
    }
    //重新开始本轮游戏
    public void RestartGame()
    {
        Restart();
    }
    //退出游戏，返回主菜单
    public void QuitGame()
    {
        Quit();
    }
    //新游戏，返回选择界面
    public void NewGame()
    {
        New();
    }
    
    private void Pause()
    {
        isPaused = true;
        menuGO.SetActive(true);
        Time.timeScale=0;
        buttonPause.SetActive(false);
        buttonRestart.SetActive(false);
    }

    private void UnPause()
    {
        isPaused = false;
        menuGO.SetActive(false);
        Time.timeScale=1;
        buttonPause.SetActive(true);
        buttonRestart.SetActive(true);
    }

    private void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);//本场景序号
        Time.timeScale=1;
    }
    private void New()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);//选择界面场景序号
        Time.timeScale=1;
    }
    private void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);//开始场景序号
        Time.timeScale=1;
    }
    public void gameRead() {
        //坐标位置初始化
        float x=0,y=0;
        //读取人物位置坐标信息
        if (PlayerPrefs.HasKey("scene1_playerPosition.x"))
            x = PlayerPrefs.GetFloat("scene1_playerPosition.x");
        if (PlayerPrefs.HasKey("scene1_playerPosition.y"))
            y = PlayerPrefs.GetFloat("scene1_playerPosition.y");
        //设置人物位置 
        Player.transform.localPosition = new Vector2(x,y) ;
    }
    
}
