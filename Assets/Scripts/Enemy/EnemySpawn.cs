using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject ghost;
 
    int maxGhosts = 3;

    GameObject[] currentGhosts;

    void Start()
    {
     
       
    }

    public void SpawnGhostCondition()
    {
        SpawnGhosts();
        StartCoroutine(CheckGhostsRoutine());
    }

    IEnumerator CheckGhostsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            currentGhosts = GameObject.FindGameObjectsWithTag("ghost");

            if (currentGhosts.Length == 0)
            {
                SpawnGhosts();
            }


        }
    }



    void SpawnGhosts()
    {
        for(int i =0; i<maxGhosts; i++)
        {
            // 스폰 지점 배열에서 무작위 위치
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform radomSpawnPoint = spawnPoints[randomIndex];

            GameObject newGhost = Instantiate(ghost, radomSpawnPoint.position, Quaternion.identity);
        }
    }
}
