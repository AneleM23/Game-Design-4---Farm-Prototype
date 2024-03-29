using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
}
