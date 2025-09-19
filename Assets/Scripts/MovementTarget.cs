using UnityEngine;

public class MovementTarget : MonoBehaviour
{
    public Transform[] puntos;
    public float velocidad = 3f;
    private int indice = 0;


    public GameObject targetRoto;

    public GameObject target;
    private Collider colliderTarget;

    private bool destruido = false;
    private float contador = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colliderTarget = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntos[indice].position, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, puntos[indice].position) < 0.1f)
        {
            indice = (indice + 1) % puntos.Length;
        }

        if (destruido)
        {
            contador += Time.deltaTime;
            if (contador >= 3f)
            {

                target.SetActive(true);
                colliderTarget.enabled = true;

                destruido = false;
                contador = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !destruido)
        {
            target.SetActive(false);
            colliderTarget.enabled = false;

            Instantiate(targetRoto, transform.position, targetRoto.transform.rotation);

            destruido = true;

            ScoreManager.scoreManager.AddScore(500);
        }
    }
}
