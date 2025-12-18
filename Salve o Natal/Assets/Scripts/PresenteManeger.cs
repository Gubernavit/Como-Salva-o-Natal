using UnityEngine;

public class PresenteManager : MonoBehaviour
{
    public GameObject mensagemVitoria;
    public GameObject[] presentes;
    public GameObject[] iconesUI;

    private int coletados = 0;
    private bool jogoPausado = false;

    void Start()
    {
        mensagemVitoria.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ColetarPresente()
    {
        coletados++;

        if (coletados >= presentes.Length)
        {
            mensagemVitoria.SetActive(true);
            PausarJogo();
        }
    }

    void Update()
    {
        if (jogoPausado && Input.GetKeyDown(KeyCode.Space))
        {
            RetomarJogo();
            Resetar();
        }
    }

    void PausarJogo()
    {
        Time.timeScale = 0f;
        jogoPausado = true;
    }

    void RetomarJogo()
    {
        Time.timeScale = 1f;
        jogoPausado = false;
    }

    void Resetar()
    {
        coletados = 0;
        mensagemVitoria.SetActive(false);

        foreach (GameObject p in presentes)
            p.SetActive(true);

        foreach (GameObject i in iconesUI)
            i.SetActive(false);
    }
}
