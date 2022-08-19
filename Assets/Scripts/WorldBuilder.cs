using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject[] freePlatforms;
    [SerializeField] private GameObject[] obstaclePlatforms;
    public Transform platformContainer;

    private bool isObstacle;

    private Transform lastPlatform = null;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            CreatePlatform();
    }

    public void Init()
    {
        CreateFreePlatform();
        CreateFreePlatform();

        for (int i = 0; i < 5; i++)
        {
            CreatePlatform();
        }
    }

    public void CreatePlatform()
    {
        if (isObstacle)
            CreateFreePlatform();
        else
            CreateObstaclePlatform();
    }

    private void CreateFreePlatform()
    {
        Vector3 position = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;

        int index = Random.Range(0, freePlatforms.Length);
        GameObject result = Instantiate(freePlatforms[index], position, Quaternion.identity, platformContainer);
        lastPlatform = result.transform;
        isObstacle = false;
    }

    private void CreateObstaclePlatform()
    {
        Vector3 position = (lastPlatform == null) ?
            platformContainer.position :
            lastPlatform.GetComponent<PlatformController>().endPoint.position;

        int index = Random.Range(0, obstaclePlatforms.Length);
        GameObject result = Instantiate(obstaclePlatforms[index], position, Quaternion.identity, platformContainer);
        lastPlatform = result.transform;
        isObstacle = true;
    }
}
