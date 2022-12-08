using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroy : MonoBehaviour
{
    public float AfterSecondsToDestroy;
    public bool TriggerDestroy;

    public void OnTriggerEnter(Collider other)
    {
        if (TriggerDestroy == true)
        {
            Destroy(gameObject);
        }
    }
    public void Awake()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject, AfterSecondsToDestroy);
    }

}