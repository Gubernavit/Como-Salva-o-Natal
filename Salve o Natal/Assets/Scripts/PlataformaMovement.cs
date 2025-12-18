using UnityEngine;

public class PlataformaMovement : MonoBehaviour
{
    public Vector2 pontoA;
    public Vector2 pontoB;
    public float velocidade = 2f;

    private Vector2 alvo;

    void Start()
    {
        alvo = pontoB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            alvo,
            velocidade * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, alvo) < 0.05f)
        {
            alvo = (alvo == pontoA) ? pontoB : pontoA;
        }
    }
}
