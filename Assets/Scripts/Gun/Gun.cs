using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private int rotation;
    [SerializeField]
    private int maximumBullets = 5;

    [SerializeField]
    private Sprite defaultStateSprite;
    [SerializeField]
    private Sprite upStateSprite;
    [SerializeField]
    private Sprite downStateSprite;

    [SerializeField]
    private KeyCode fireKey = KeyCode.Space;
    [SerializeField]
    private KeyCode upKey = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode downKey = KeyCode.DownArrow;

    private Image image;
    [SerializeField]
    private ObjectPool bullets;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = transform.position;
        position.x = Screen.width / 4;
        transform.position = position;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            GameObject bullet = bullets.GetObject();
            if (bullet != null)
            {
                bullet.GetComponent<Bullet>().fireAngle = rotation;
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
        if (Input.GetKey(downKey))
        {
            rotation = 30;
            image.sprite = downStateSprite;
        }
        else if (Input.GetKey(upKey))
        {
            rotation = 90;
            image.sprite = upStateSprite;
        }
        else
        {
            rotation = 60;
            image.sprite = defaultStateSprite;
        }
    }

    public void DestroyAllBullets()
    {
        bullets.DestroyAllObjects();
    }
}
