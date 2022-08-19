using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMove : MonoBehaviour
{
    [SerializeField] private float limitPoint;
    private Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
       if(Input.touchCount > 0)
       {
            Touch touch = Input.GetTouch(0);

            var height = Screen.height;

            var x = touch.position.x / Screen.width;

            position.x = -limitPoint + (x * 2 * limitPoint);
            transform.position = position;

            Debug.Log(x);
        }
    }
}
