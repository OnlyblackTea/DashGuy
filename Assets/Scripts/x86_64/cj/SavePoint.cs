using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject m_Player;
    public GameObject m_SpawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" || collision.tag == "Player")
        {
            m_SpawnPoint.transform.position = m_Player.transform.position;
        }
        if(collision.tag == "Bullet")
        {
            Debug.Log("Saved!");
        }
    }
}
