using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade = 2f;
    public Transform pontoEsquerda;
    public Transform pontoDireita;

    Rigidbody2D rb;
    bool indoDireita = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (indoDireita)
        {
            rb.linearVelocity = new Vector2(velocidade, 0);

            if (transform.position.x >= pontoDireita.position.x)
            {
                indoDireita = false;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-velocidade, 0);

            if (transform.position.x <= pontoEsquerda.position.x)
            {
                indoDireita = true;
            }
        }
    }

    public void Morrer()
    {
        Destroy(gameObject);
    }
}
