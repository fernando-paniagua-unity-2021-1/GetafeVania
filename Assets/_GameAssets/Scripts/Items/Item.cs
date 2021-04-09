using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemValues { LlaveAmarilla, GemaAmarilla, PowerUp, Invulnerability }

    [SerializeField]
    private ItemValues itemName;

    bool recogido = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (recogido) return;
        recogido = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            GameManager gm = GameManager.Instance;
            gm.AddItem(gameObject);
            //Indica al SoundManager qué sonido tiene que reproducir
            SoundManager sm = SoundManager.Instance;
            sm.PlaySound(gameObject.tag);
        }
    }
    public ItemValues GetItemName()
    {
        return this.itemName;
    }
}
