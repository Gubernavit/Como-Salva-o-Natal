using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float bordaX = 3f;
    public float bordaY = 2f;
    public float suavizacao = 5f;

    public float limiteEsquerda = -40f;
    public float limiteDireita = 40f;
    public float limiteCima = 30f;

    private float alvoX;
    private float alvoY;

    void Start()
    {
        alvoX = transform.position.x;
        alvoY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float distX = player.position.x - transform.position.x;
        float distY = player.position.y - transform.position.y;

        if (Mathf.Abs(distX) > bordaX)
            alvoX = player.position.x;

        if (Mathf.Abs(distY) > bordaY)
            alvoY = player.position.y;

        float x = Mathf.Lerp(transform.position.x, alvoX, suavizacao * Time.deltaTime);
        float y = Mathf.Lerp(transform.position.y, alvoY, suavizacao * Time.deltaTime);

        x = Mathf.Clamp(x, limiteEsquerda, limiteDireita);
        y = Mathf.Clamp(y, 0f, limiteCima); 

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
