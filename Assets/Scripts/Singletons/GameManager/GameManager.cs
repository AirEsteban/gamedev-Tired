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

    // Method to drop an item at certain point. not implemented really good rn.
    public static void DropItem(string findTag, Vector3 position)
    {
        var objectFound = inventory.Find(item => item.tag == findTag);
        // set position
        objectFound.SetActive(true);
    }

    public static bool HaveItem(string tagItem)
    {
        var found = false;
        inventory.ForEach(item =>
        {
            if (item.CompareTag(tagItem))
            {
                found = true;
            }
        });
        return found;
    }
}
