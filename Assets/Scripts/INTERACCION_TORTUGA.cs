using UnityEngine;

public class INTERACCION_TORTUGA : MonoBehaviour
{
    private bool isCarrying = false;
    private GameObject carriedObject;
    public GameObject objectA;       // Objeto A
    public GameObject objectB;       // Objeto B
    public GameObject objectCPrefab; // Prefab del objeto C
    public AudioClip sonido;
    public AudioSource audioSource;

    public bool circuloSi = false;
    public GameObject circulo;
    public GameObject circuloTortuga;
    public bool tortugaCompletado = false;
    private Vector3 screenPosition;
    private Vector3 offset;

    private void Start()
    {
        circulo.SetActive(false);
        circuloTortuga.SetActive(true);
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
       if (Input.GetKey("joystick button 1"))
        {
            if (!isCarrying)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Tortuga"))
                    {
                        PickUpObject(hit.collider.gameObject);
                        if (circuloSi)
                        {
                            circulo.SetActive(true);
                        }
                    }
                }
            }
            else
            {
                DropObject();
                circulo.SetActive(false);
            }
        }
        
    }

    void PickUpObject(GameObject obj)
    {
        isCarrying = true;
        carriedObject = obj;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(Camera.main.transform);
        circuloSi = true;
    }


void DropObject()
{
    isCarrying = false;
    Rigidbody carriedRigidbody = carriedObject.GetComponent<Rigidbody>();

    // Habilitar la gravedad en el Rigidbody
    carriedRigidbody.useGravity = true;

    Vector3 spawnPosition = objectA.transform.position;

    // Verificar si el objeto A colisiona con el objeto B
    if (carriedObject == objectA && IsCollidingWithObjectB(objectA))
    {
        // Instancia el objeto C en la posición de B
        Instantiate(objectCPrefab, spawnPosition, objectB.transform.rotation);

        // Destruye el objeto A
        Destroy(objectA);
        tortugaCompletado = true;
        audioSource.PlayOneShot(sonido);
    }
}

    bool IsCollidingWithObjectB(GameObject obj)
    {
        Collider objCollider = obj.GetComponent<Collider>();
        Collider objBCollider = objectB.GetComponent<Collider>();

        if (objCollider != null && objBCollider != null)
        {
            return objCollider.bounds.Intersects(objBCollider.bounds);
            Debug.Log("aa");
        }

        return false;
    }
}