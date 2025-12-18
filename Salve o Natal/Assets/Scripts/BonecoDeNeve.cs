using UnityEngine;

public class BonecoDeNeve : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 2f;
    public float pontoA;
    public float pontoB;

    [Header("Visão")]
    public float distanciaVisao = 6f;
    public LayerMask playerLayer;

    [Header("Ataque")]
    public GameObject bolaDeNevePrefab;
    public Transform pontoDisparo;
    public float tempoEntreTiros = 1.5f;

    private float proximoTiro;
    private bool indoParaB = true;
    private Transform player;

    void Update()
    {
        Patrulhar();
        VerPlayer();
    }

    void Patrulhar()
    {
        float alvo = indoParaB ? pontoB : pontoA;
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(alvo, transform.position.y),
            velocidade * Time.deltaTime
        );

        if (Mathf.Abs(transform.position.x - alvo) < 0.1f)
            indoParaB = !indoParaB;

        float direcao = indoParaB ? 1 : -1;
        transform.localScale = new Vector3(direcao, 1, 1);
    }

    void VerPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.right * transform.localScale.x,
            distanciaVisao,
            playerLayer
        );

        if (hit.collider != null)
        {
            player = hit.transform;
            Atirar();
        }
    }

    void Atirar()
    {
        if (Time.time < proximoTiro) return;

        GameObject bola = Instantiate(
            bolaDeNevePrefab,
            pontoDisparo.position,
            Quaternion.identity
        );

        Vector2 dir = transform.right * transform.localScale.x;
        bola.GetComponent<BolaDeNeve>().DefinirDirecao(dir);

        proximoTiro = Time.time + tempoEntreTiros;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(
            transform.position,
            transform.position + Vector3.right * distanciaVisao * transform.localScale.x
        );
    }
}
