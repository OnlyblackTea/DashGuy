using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_select : MonoBehaviour
{
    //select场景
    public void Transtomap1(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);//地图一场景序号
    }
    public void Transtomap2(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);//地图二场景序号
    }
    public void Transtomap3(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);//地图三场景序号
    }
}
