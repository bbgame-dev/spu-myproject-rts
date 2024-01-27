using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
   public static InfoManager instance;

    private void Awake()
    {
        instance = this;
    }
}
