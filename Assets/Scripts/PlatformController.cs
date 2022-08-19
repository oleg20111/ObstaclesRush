using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform endPoint;

    private void Start()
    {
        WorldController.Instance.OnPlatformMovement += TryDellAndAddPlatform;
    }

    private void TryDellAndAddPlatform()
    {
        if (transform.position.z < WorldController.Instance.minZ)
        {
            WorldController.Instance.worldBuilder.CreatePlatform();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        WorldController.Instance.OnPlatformMovement -= TryDellAndAddPlatform;
    }
}
