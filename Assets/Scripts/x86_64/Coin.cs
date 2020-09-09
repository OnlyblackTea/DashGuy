using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject fakeSpike;

    //硬币与人进行碰撞检测
    public void OnTriggerEnter(Collider collider)
    {
        GameObject.Instantiate(fakeSpike, transform.position, transform.rotation);//硬币变成刺
        Destroy(gameObject);//摧毁硬币
    }
}