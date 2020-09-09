using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;//刚体

    public float MoveSpeed;//移动速度
    public float JumpSpeed;//跳跃速度

    public Transform CheckPoint;//设置脚下的空对象作为检查点
    public float CheckRadius;//检查半径
    public LayerMask WhatIsGround;//设置地面layer
    public bool isGround;//是否在地面
    private bool Jumped;//是否在空中已经跳过

    private Animator Anim;//动画器
    private Vector3 m_scale;//记录初始缩放值

    private Vector3 RespawnPosition;//记录复活点的位置信息

    private float timer = 10.0f;

    private bool m_FacingRight;

    private void Flip()//翻转函数
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponent<Animator>();
        RespawnPosition = transform.position;
        m_scale = transform.localScale;
        m_FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(CheckPoint.position, CheckRadius, WhatIsGround);//判断是否在地上
        if (isGround)
        {
            Jumped = false;//初始化二段跳
            timer = 10.0f;
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                gameFail();
            }
        }

        if(Input.GetAxisRaw("Horizontal")>0)
        {
            m_rigidbody2D.velocity = new Vector2(MoveSpeed, m_rigidbody2D.velocity.y);//向右移动
            //transform.localScale = m_scale;
            if (!m_FacingRight)
            {
                Flip();
            }
        }
        else if(Input.GetAxisRaw("Horizontal")<0)
        {
            m_rigidbody2D.velocity = new Vector2(-MoveSpeed, m_rigidbody2D.velocity.y);//向左移动
            //transform.localScale = new Vector3(-m_scale.x, m_scale.y, m_scale.z);
            if (m_FacingRight)
            {
                Flip();
            }
        }
        else
        {
            m_rigidbody2D.velocity = new Vector2(0, m_rigidbody2D.velocity.y);//停止移动
        }

        if (Input.GetKeyDown("space") && isGround)
        {
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, JumpSpeed);//一段跳
        }
        else if(Input.GetKeyDown("space") && !isGround && !Jumped)
        {
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, JumpSpeed);//二段跳
            Jumped = true;
        }

        if(Input.GetKeyDown("r"))
        {
            FindObjectOfType<SpawnPoint>().PosTrans();
        }

        Anim.SetFloat("Speed", (m_rigidbody2D.velocity.x > 0) ? (m_rigidbody2D.velocity.x) : (-m_rigidbody2D.velocity.x));//设置动画器中速度
        Anim.SetBool("Grounded", isGround);//设置动画器中着地变量
    }

    private void gameFail()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);//返回选择界面
    }
}
