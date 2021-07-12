using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int defaultHighScore = 100;
    [SerializeField]
    private int defaultTimeLimit = 30;
    [SerializeField]
    private int defaultHitScore = 1;

    [SerializeField]
    private PlanesController planesController;
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private GameObject gameplay;
    [SerializeField]
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        gameplay.SetActive(true);
        menu.SetActive(false);
        StartCoroutine(planesController.SpawnPlanes());
    }

    public void EndGame()
    {
        planesController.DestroyAllPlanes();
        gun.DestroyAllBullets();
        ShowMenu();
    }

    private void ShowMenu()
    {
        gameplay.SetActive(false);
        menu.SetActive(true);
    }

    public void UpdateDefaultValues(GameInfo info)
    {
        defaultHighScore = info.defaultHighScore;
        defaultTimeLimit = info.timeLimit;
        defaultHitScore = info.pointsPerPlane;
    }

}
