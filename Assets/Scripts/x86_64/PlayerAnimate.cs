using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;

    public float MoveSpeed;
    public float JumpSpeed;

    public Transform CheckPoint;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    public bool isGround;
    private bool Jumped;

    private Animator Anim;
    private Vector3 m_scale;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Anim = gameObject.GetComponent<Animator>();
        m_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(CheckPoint.position, CheckRadius, WhatIsGround);
        if (isGround)
        {
            Jumped = false;
        }
        if(Input.GetAxisRaw("Horizontal")>0)
        {
            m_rigidbody2D.velocity = new Vector2(MoveSpeed, m_rigidbody2D.velocity.y);
            transform.localScale = m_scale;
        }
        else if(Input.GetAxisRaw("Horizontal")<0)
        {
            m_rigidbody2D.velocity = new Vector2(-MoveSpeed, m_rigidbody2D.velocity.y);
            transform.localScale = new Vector3(-m_scale.x, m_scale.y, m_scale.z);
        }
        else
        {
            m_rigidbody2D.velocity = new Vector2(0, m_rigidbody2D.velocity.y);
        }
        if (Input.GetKeyDown("space") && isGround)
        {
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, JumpSpeed);
        }
        else if(Input.GetKeyDown("space") && !isGround && !Jumped)
        {
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, JumpSpeed);
            Jumped = true;
        }

        Anim.SetFloat("Speed", m_rigidbody2D.velocity.x);
        Anim.SetBool("Grounded", isGround);
    }
}
