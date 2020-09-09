using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject Player;//将复活点位置改成角色当前位置
    public int DeadCount;
    // Start is called before the first frame update
    private void Start()
    {
        Player.transform.position = transform.position;
        DeadCount = 0;
    }
    public void PosTrans()
    {
        Player.transform.position = transform.position;
        DeadCount++;
    }
}
