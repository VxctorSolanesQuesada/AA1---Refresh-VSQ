using UnityEngine;

public class TargetController : MonoBehaviour
{

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

            ScoreManager.scoreManager.AddScore(100);
        }
    }
}


