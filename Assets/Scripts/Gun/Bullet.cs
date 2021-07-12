using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int fireAngle = 60;
    [SerializeField]
    private float speed = 20;
    private const string planeTag = "Plane";

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float a = fireAngle * Mathf.Deg2Rad;
        Vector3 direction = (transform.up * Mathf.Sin(a) + transform.right * Mathf.Cos(a)).normalized;

        transform.Translate((direction * speed * Time.deltaTime));
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (!screenRect.Contains(transform.position)) //check if a bullet is inside the screen rect
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == planeTag)
        {
            gameObject.SetActive(false); //disable if collided with plane
        }
    }
}
