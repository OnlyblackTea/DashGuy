using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{//碰撞检测
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")//与刺或硬币产生碰撞
        {
            GameObject.Find("Player").GetComponent<DeadOrAlive>().Dead();
        }
    }
}