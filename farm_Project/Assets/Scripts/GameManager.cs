using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Item_Manager item_manager;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else
        {
            instance = this;
        }


        DontDestroyOnLoad(gameObject);


        item_manager = GetComponent<Item_Manager>();
    }
}
