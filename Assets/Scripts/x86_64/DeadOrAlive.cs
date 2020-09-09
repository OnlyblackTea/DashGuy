using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class DeadOrAlive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Dead();
        }
    }
    public void Dead()
    {
        FindObjectOfType<SpawnPoint>().PosTrans();
    }
}
