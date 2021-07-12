using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesController : MonoBehaviour
{
    [SerializeField]
    private int minimumNumberOfPlanes = 3;
    [SerializeField]
    private int maximumNumberOfPlanes = 5;
    [SerializeField]
    private ObjectPool planesPool;

    private int numberOfActivePlanes = 0;

    [SerializeField]
    private int defaultSpawnYOffset = 200;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator SpawnPlanes()
    {
        int numberOfPlanes = Random.Range(minimumNumberOfPlanes, maximumNumberOfPlanes + 1);
        numberOfActivePlanes = numberOfPlanes;
        for (int i = 0; i < numberOfPlanes; i++)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject plane = planesPool.GetObject();
            if (plane != null)
            {
                plane.GetComponent<EnemyPlane>().controller = this;
                plane.transform.position = GetSpawnPositionFor(plane, i);
                plane.transform.rotation = transform.rotation;
                plane.SetActive(true);
            }
        }
    }

    private Vector2 GetSpawnPositionFor(GameObject plane, int index)
    {
        RectTransform rect = (RectTransform)plane.transform;
        float height = rect.rect.height;

        Vector2 spawnPosition = new Vector2(0, Screen.height - defaultSpawnYOffset - index * height / 2);
        return spawnPosition;
    }

    public void OnBulletHit()
    {
        audioSource.Play();
        scoreManager.OnHit();
        DestroyPlane();
    }

    public void DestroyPlane()
    {
        numberOfActivePlanes--;
           if (numberOfActivePlanes == 0)
        {
            StartCoroutine(SpawnPlanes());
        }
    }

    public void DestroyAllPlanes()
    {
        planesPool.DestroyAllObjects();
    }
}
