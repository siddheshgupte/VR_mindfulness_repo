using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public static ChangeScene instance = null;

    List<string> sceneList;
    int currentSceneIndex = 0;

    private void Awake()
    {
        #region Singleton definition
        // Singleton definition
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        #endregion

    }

    // Use this for initialization
    void Start () {

        int sceneCount = SceneManager.sceneCountInBuildSettings;
	    sceneList = new List<string>();

        for (int i = 0; i< sceneCount; i++)
        {
            sceneList.Add(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
        }

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E)){

            Debug.Log("Key Pressed");

            int nextSceneIndex = (currentSceneIndex + 1) % sceneList.Count;

            SceneManager.LoadScene(nextSceneIndex);

            currentSceneIndex = nextSceneIndex;

        }
	}
}
