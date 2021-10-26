using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    private GameObject player;
    private bool blink_effect = false;

    private Color DEFAULT;
    private Color RED = new Color(0.78F, 0, 0, 0.8F);

    void Start()
    {
        player = this.gameObject;

        DEFAULT = player.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(blink_effect)
        {
            player.GetComponent<Renderer>().material.color = RED;
        }
        else 
        {
            player.GetComponent<Renderer>().material.color = DEFAULT;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            StartCoroutine(DamageBlinkEffect());
        }
    }

    IEnumerator DamageBlinkEffect()
    {
        blink_effect = true;

        yield return new WaitForSeconds(0.25F);

        blink_effect = false;
    }
}
