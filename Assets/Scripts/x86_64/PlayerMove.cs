using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;

    //在角色底下添加一个空物体，设置跳跃监测点
    public Transform CheckPoint;
    //设置跳跃监测半径
    public float CheckRadius;
    //设置跳跃检测层
    public LayerMask WhatIsGround;
    //角色默认是否着地
    public bool isGround;

    //private Animator m_Animator;

    private Vector3 m_scale;
    private Rigidbody2D m_Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        m_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        isGround = Physics2D.OverlapCircle(CheckPoint.position, CheckRadius, WhatIsGround);
        //角色水平移动，按下右方向键后向右移动
        if(Input.GetAxisRaw("Horizontal") > 0)
        {

            m_Rigidbody2D.velocity = new Vector2(MoveSpeed, m_Rigidbody2D.velocity.y);

            //设置自身缩放的值
            transform.localScale = m_scale;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            m_Rigidbody2D.velocity = new Vector2(-MoveSpeed, m_Rigidbody2D.velocity.y);

            transform.localScale = new Vector3(-m_scale.x, m_scale.y, 1);
        }

        float H = Input.GetAxisRaw("Horizontal");
        m_Rigidbody2D.velocity = new Vector2(MoveSpeed * H, m_Rigidbody2D.velocity.y);
        transform.localScale = new Vector3(m_scale.x * H, m_scale.y, m_scale.z);

        //按下空格键跳跃
        if(Input.GetKeyDown("space") && isGround)
        {
            Debug.Log("I jumped!");
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, JumpSpeed); 
        }
        
    }
}
