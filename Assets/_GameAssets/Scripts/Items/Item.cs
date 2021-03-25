using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemValues { LlaveAmarilla, GemaAmarilla, PowerUp, Invulnerability }

    [SerializeField]
    private ItemValues itemName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            GameManager gm = GameManager.Instance;
            gm.AddItem(gameObject);
        }
    }
    public ItemValues GetItemName()
    {
        return this.itemName;
    }
}
