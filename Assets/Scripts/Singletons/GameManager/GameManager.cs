using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static List<GameObject> inventory = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void SaveItem(GameObject obj)
    {
        if (!obj.CompareTag("Untagged"))
        {
            inventory.Add(obj);
        }
        else
        {
            Debug.LogError("THE GAME OBJECT " + obj.name + " DOES NOT HAVE A TAG"); 
        }
    }

    public static void DropItem(string findTag, Vector3 position)
    {
        var objectFound = inventory.Find(item => item.tag == findTag);
        objectFound.transform.position = position;
        objectFound.SetActive(true);
        
    }
}
