using UnityEngine;

public class BolaDeNeve : MonoBehaviour
{
    public float velocidade = 8f;
    public int dano = 1;
    public float tempoDeVida = 3f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, tempoDeVida);
    }

    public void DefinirDirecao(Vector2 dir)
    {
        rb.linearVelocity = dir.normalized * velocidade;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vida vida = col.GetComponent<Vida>();
        if (vida != null)
        {
            vida.TomarDano(dano);
        }

        Destroy(gameObject);
    }
}
