using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}
