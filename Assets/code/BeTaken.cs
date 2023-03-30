using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeTaken : MonoBehaviour
{
    public string itemName;
    public int itemLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            other.gameObject.GetComponent<Hero>().items[itemName] = itemLevel;
            Destroy(gameObject);
        }
    }
}
