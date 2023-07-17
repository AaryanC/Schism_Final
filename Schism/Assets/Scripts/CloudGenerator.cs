using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject[] cloudPrefabs;
    public float scrollSpeed;
    public float deleteTime;
    public float recreateTime;

    private float screenWidth;
    private List<GameObject> clouds = new List<GameObject>();
    private Camera mainCamera;
    private float lastCloudPositionX;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        screenWidth = GetScreenWidth();
        CreateClouds();
    }

    void Update()
    {
        MoveClouds();
        DeleteClouds();
    }

    void MoveClouds()
    {
        foreach (GameObject cloud in clouds)
        {
            cloud.transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
        }
    }

    void DeleteClouds()
    {
        if (clouds.Count > 0 && Time.time >= deleteTime)
        {
            GameObject cloudToDelete = clouds[0];
            clouds.RemoveAt(0);
            Destroy(cloudToDelete);
        }
    }

    IEnumerator RecreateCloud()
    {
        yield return new WaitForSeconds(recreateTime);

        int prefabIndex = Random.Range(0, cloudPrefabs.Length);
        float startPosX = lastCloudPositionX + screenWidth;
        GameObject newCloud = Instantiate(cloudPrefabs[prefabIndex], new Vector3(startPosX, transform.position.y, transform.position.z), Quaternion.identity);
        clouds.Add(newCloud);
        lastCloudPositionX = startPosX;
    }

    void CreateClouds()
    {
        int cloudCount = (int)Mathf.Ceil(screenWidth / cloudPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x) + 2;
        float startPosX = -screenWidth;

        for (int i = 0; i < cloudCount; i++)
        {
            int prefabIndex = Random.Range(0, cloudPrefabs.Length);
            GameObject cloud = Instantiate(cloudPrefabs[prefabIndex], new Vector3(startPosX, transform.position.y, transform.position.z), Quaternion.identity);
            clouds.Add(cloud);
            startPosX += cloud.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        lastCloudPositionX = startPosX;
        StartCoroutine(RecreateCloud());
    }

    float GetScreenWidth()
    {
        float lensSize = mainCamera.orthographicSize * 2f * mainCamera.aspect;
        return lensSize;
    }
}
