using UnityEngine;

public class SelectionMarker : MonoBehaviour
{

    [SerializeField] private float lifeTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
