using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    [Header("Mario Parameters")]
    public float m_speedJump;
    public float m_radius;
    public LayerMask m_layerGround;

    [Header("Mario Sprites")]
    public Sprite m_marioIdle;
    public Sprite m_marioJump;

    Rigidbody2D m_body;
    SpriteRenderer m_sprite;

    bool m_isInGround;

    // Start is called before the first frame update
    void Start()
    {
        m_body = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        bool wasGround = m_isInGround;
        m_isInGround = (Physics2D.OverlapCircle(transform.position, m_radius, m_layerGround) != null);
        if (wasGround != m_isInGround)
        {
            m_sprite.sprite = m_isInGround ? m_marioIdle : m_marioJump;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isInGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_body.velocity = new Vector2(m_body.velocity.x, m_speedJump);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float currentVelocityY = m_body.velocity.y;
            if (currentVelocityY > 0)
            {
                float halfVelocityY = currentVelocityY * 0.5f;
                m_body.velocity = new Vector2(m_body.velocity.x, halfVelocityY);
            }
        }
    }
}
