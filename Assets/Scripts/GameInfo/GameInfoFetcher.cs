using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameInfoFetcher : MonoBehaviour
{
    private const string API_URL = "http://content.gamefuel.info/api/client_programming_test/air_battle_v1/content/config/config";

    private bool logging = false;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest(API_URL));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                //Do nothing. We can start the game with the default values.
                if (logging)
                {
                    Debug.Log("Error - " + webRequest.error);
                }
            }
            else
            {
                string json = webRequest.downloadHandler.text;
                GameInfo info = JsonUtility.FromJson<GameInfo>(json);
                gameManager.UpdateDefaultValues(info);
                Log(info);
            }
        }
    }

    private void Log(GameInfo info)
    {
        if (logging)
        {
            Debug.Log("time limit - " + info.timeLimit);
            Debug.Log("points - " + info.pointsPerPlane);
            Debug.Log("score - " + info.defaultHighScore);
        }
    }
}
