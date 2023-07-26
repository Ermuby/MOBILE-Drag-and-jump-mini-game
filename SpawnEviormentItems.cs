using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEviormentItems : MonoBehaviour
{
    private Dictionary<int, EnvironmentItems> spawnEnvItem = new Dictionary<int, EnvironmentItems>();

    [SerializeField] private List<Transform> spawnPoint;

    private int[] count = new int[10];

    private EnvironmentItems _environmentItems;

    private void Awake()
    {
        _environmentItems = FindObjectOfType<EnvironmentItems>();
    }

    private void Start()
    {
        SpawnEnv();
    }

    private void SpawnEnv()
    {
        Vector3 leftSpawn = new Vector3(-1.5f, 2, 0);
        Vector3 midSpawn = new Vector3(0, 2, 0);
        Vector3 rightSpawn = new Vector3(1.5f, 2, 0);

        for (int i = 0; i < 10; i++)
        {
            int random = Random.Range(0, 6);

            switch (random)
            {
                case 0:
                    GameObject envItem = OOPEnviormentItem.Instance.Spawn();
                    envItem.transform.position = leftSpawn;
                    break;
                case 1:
                    GameObject envItem1 = OOPEnviormentItem.Instance.Spawn();
                    envItem1.transform.position = midSpawn;
                    break;
                case 2:
                    GameObject envItem2 = OOPEnviormentItem.Instance.Spawn();
                    envItem2.transform.position = rightSpawn;
                    break;
                case 3:
                    GameObject envItem3 = OOPEnviormentItem.Instance.Spawn();
                    GameObject envItem4 = OOPEnviormentItem.Instance.Spawn();
                    envItem3.transform.position = leftSpawn;
                    envItem4.transform.position = midSpawn;
                    break;
                case 4:
                    GameObject envItem5 = OOPEnviormentItem.Instance.Spawn();
                    GameObject envItem6 = OOPEnviormentItem.Instance.Spawn();
                    envItem5.transform.position = midSpawn;
                    envItem6.transform.position = rightSpawn;
                    break;
                case 5:
                    GameObject envItem7 = OOPEnviormentItem.Instance.Spawn();
                    GameObject envItem8 = OOPEnviormentItem.Instance.Spawn();
                    envItem7.transform.position = leftSpawn;
                    envItem8.transform.position = rightSpawn;
                    break;
            }

            leftSpawn += new Vector3(0, 2, 0);
            midSpawn += new Vector3(0, 2, 0);
            rightSpawn += new Vector3(0, 2, 0);
        }
    }
}