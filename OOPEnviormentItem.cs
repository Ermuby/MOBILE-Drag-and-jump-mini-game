using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPEnviormentItem : MonoBehaviour

{
	[SerializeField] private GameObject[] enviormentItem;
	[SerializeField] private List<GameObject> enviormentItemList;
	private int size = 20;

	private const int one = 1;

	private static OOPEnviormentItem instance;
	public static OOPEnviormentItem Instance => instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		AddList(size);
	}

	void AddList(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			int random = Random.Range(0, enviormentItem.Length);
			GameObject newEnvItem = Instantiate(enviormentItem[random]);
			newEnvItem.transform.parent = transform;
			enviormentItemList.Add(newEnvItem);
			newEnvItem.SetActive(false);
		}
	}

	public GameObject Spawn()
	{
		for (int i = 0; i < enviormentItemList.Count; i++)
		{
			i = Random.Range(0, enviormentItemList.Count);
			if (!enviormentItemList[i].activeSelf)
			{
				enviormentItemList[i].SetActive(true);
				return enviormentItemList[i];
			}
		}

		AddList(1);
		enviormentItemList[enviormentItemList.Count - 1].SetActive(true);
		return enviormentItemList[enviormentItemList.Count - 1];
	}
}

