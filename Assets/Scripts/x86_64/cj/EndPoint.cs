using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    //用于判断角是否到达终点
    private bool isEnd=false;
    //角色
    public GameObject Player;
    //结束菜单
    public GameObject EndmenuGO;
    public bool ArrivalJudge()
    {
        if (Player.transform.localPosition.x==this.transform.position.x&&
            Player.transform.localPosition.y==this.transform.position.y)//或者改为碰撞条件
        {
            isEnd=true;
            PlayerPrefs.DeleteKey("scene1_playerPosition.x");
            PlayerPrefs.DeleteKey("scene1_playerPosition.y");
            CallOutEndmenu();
        }
        return isEnd;
    }//呼出结束菜单
    public void CallOutEndmenu()
    {
        EndmenuGO.SetActive(true);
    }
}
