using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private int remainingTime = 0;
    [SerializeField]
    private TextMeshProUGUI time;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTimer(int time)
    {
        remainingTime = time;
        this.time.text = "Time remaining - " + remainingTime.ToString();
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        yield return new WaitForSeconds(1.0f);
        remainingTime--;
        time.text = "Time remaining - " + remainingTime.ToString();
        if (remainingTime == 0)
        {
            gameManager.EndGame();
        }
        else
        {
            StartCoroutine(UpdateTime());
        }
    }
}
