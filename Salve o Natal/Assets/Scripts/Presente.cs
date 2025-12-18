using UnityEngine;

public class Presente : MonoBehaviour
{
    public GameObject iconeUI;
    public PresenteManager manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            iconeUI.SetActive(true);
            manager.ColetarPresente();
            gameObject.SetActive(false);
        }
    }
}
