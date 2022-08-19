using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public float speed = 2.5f;
    public WorldBuilder worldBuilder;
    public float minZ = -10;

    public delegate void TryToDellAndAddPlatform();
    public event TryToDellAndAddPlatform OnPlatformMovement;

    public static WorldController Instance;

    private void Awake()
    {
        if(WorldController.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        WorldController.Instance = this;
    }

    private void OnDestroy()
    {
        WorldController.Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnPlatformMovementCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }

    IEnumerator OnPlatformMovementCorutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if(OnPlatformMovement != null)
                OnPlatformMovement();
        }
    }
}
