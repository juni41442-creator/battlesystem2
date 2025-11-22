using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 어떤 오브젝트를 생성 할 것 인가?
    // 몇 마리 생성 할 것 인가?
    // 몇 초 간격으로?
    [SerializeField] GameObject[] prefabs;
    [SerializeField] int count = 5;
    [SerializeField] float interval = 1.0f;
    //어디에서 생성할 것 인가?
    [SerializeField] Transform spawnPos;

    private void Start()
    {
        StartCoroutine(SpawnInterval());
    }

    private void Spawn()
    {
        int index = UnityEngine.Random.Range(0, prefabs.Length); // 동일한 확률
        
        Instantiate(prefabs[index], spawnPos.position, Quaternion.identity);
        
    }

    //몇마리 몇 초 간격으로
    IEnumerator SpawnInterval()
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
            yield return new WaitForSeconds(interval);
        }
        
    }

}
