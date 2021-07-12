using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    [SerializeField]
    private float speed = 20;
    public PlanesController controller;
    private const string bulletTag = "Bullet";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.right * speed * Time.deltaTime));
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (!screenRect.Contains(transform.position))
        {
            controller.DestroyPlane();
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == bulletTag)
        {
            controller.OnBulletHit();
            gameObject.SetActive(false);
        }
    }
}
