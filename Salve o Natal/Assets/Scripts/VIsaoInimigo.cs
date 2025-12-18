using UnityEngine;

public class VisaoInimigo : MonoBehaviour
{
    public float distanciaVisao = 6f;
    public LayerMask layerObstaculos;

    public bool PlayerVisivel { get; private set; }

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direcao = player.position - transform.position;
        float distancia = direcao.magnitude;

        if (distancia <= distanciaVisao)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                direcao.normalized,
                distanciaVisao,
                layerObstaculos
            );

            PlayerVisivel = hit && hit.collider.CompareTag("Player");
        }
        else
        {
            PlayerVisivel = false;
        }
    }
}
