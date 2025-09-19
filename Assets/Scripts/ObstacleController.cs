using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform[] puntos;
    public float velocidad = 3f;
    private int indice = 0;

    // Update is called once per frame
    void Update()
    {
        if (puntos.Length == 0) return;

        // Mover hacia el punto actual
        transform.position = Vector3.MoveTowards(transform.position, puntos[indice].position, velocidad * Time.deltaTime);

        // Cambiar al siguiente punto cuando llegue
        if (Vector3.Distance(transform.position, puntos[indice].position) < 0.1f)
        {
            indice = (indice + 1) % puntos.Length;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.scoreManager.AddScore(-500);   
        }
    }
}
