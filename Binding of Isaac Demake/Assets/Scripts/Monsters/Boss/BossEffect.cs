using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
    private bool blink_effect = false;

    private Color DEFAULT;
    private Color RED = new Color(0.78F, 0, 0, 0.8F);

    void Start()
    {
        DEFAULT = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (blink_effect)
        {
            GetComponent<Renderer>().material.color = RED;
        }
        else
        {
            GetComponent<Renderer>().material.color = DEFAULT;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.transform.parent.CompareTag("Boss"))
        {
            if (collision.tag == "Projectile")
            {
                StartCoroutine(DamageBlinkEffect());
            }
        }
    }

    IEnumerator DamageBlinkEffect()
    {
        blink_effect = true;

        yield return new WaitForSeconds(0.25F);

        blink_effect = false;
    }
}
