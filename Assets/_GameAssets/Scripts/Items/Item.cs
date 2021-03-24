using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            GameManager gm = GameManager.Instance;
            gm.AddItem(gameObject);
        }
    }
    public string GetItemName()
    {
        return this.itemName;
    }
}
