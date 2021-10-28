using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public Slider progressbar;
    public Sprite[] img;

    private void Start()
    {
        int rnd = Random.Range(0, 4);
        progressbar.gameObject.transform.parent.GetComponent<Image>().sprite = img[rnd];
        StopCoroutine(LoadScene());
        StartCoroutine(LoadScene());
    }
    private void Update()
    {
        
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainScene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            if (progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
