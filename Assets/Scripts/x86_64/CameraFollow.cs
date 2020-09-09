using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_playerTransform;
    //public float Ahead = 5;能看到的最远值
    public float height = 3;
    private Vector3 targetPos;//要移动到的地方
    public float smooth = 1;//缓动速度插值
    // Start is called before the first frame update
    void Start()
    {
        m_playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(m_playerTransform.position.x, m_playerTransform.position.y + height, transform.position.z);
        /*if(m_playerTransform.position.x > 0f)
        {
            targetPos = new Vector3(m_playerTransform.position.x + Ahead, transform.position.y, transform.position.z);
        }
        else
        {
            targetPos = new Vector3(m_playerTransform.position.x - Ahead, transform.position.y, transform.position.z);
        }*/
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}
