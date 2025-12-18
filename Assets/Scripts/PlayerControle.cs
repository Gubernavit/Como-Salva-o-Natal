using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    public float velocidade = 6f;
    public float pulo = 12f;
    public Transform checarChao;
    public LayerMask chao;

    Rigidbody2D rb;
    bool noChao;
    float movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // primeira perta faz a movimentação da direita/esquerda
        movimento = 0f;

        if (Input.GetKey(KeyCode.A))
            movimento = -1f;

        if (Input.GetKey(KeyCode.D))
            movimento = 1f;

        //isso faz um check pra ver se o boneco ta no chão (evita ele sair da tela)
        noChao = Physics2D.OverlapCircle(checarChao.position, 0.2f, chao);

        rb.linearVelocity = new Vector2(movimento * velocidade,rb.linearVelocity.y);        

        // esse é o pulo
        if (Input.GetKeyDown(KeyCode.W) && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, pulo);
        }

        Debug.Log("Update rodando");

    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Enemy"))
        {
            // check para queda em cima do inimigo
            if (rb.linearVelocity.y < 0)
            {
                colisao.gameObject.GetComponent<Enemy>().Morrer();

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, pulo * 0.8f);
            }
            else
            {
                Debug.Log("Jogador levou dano!");
                // tentar adicionar classe para a vida e morte do personagem
            }
        }
    }
}
