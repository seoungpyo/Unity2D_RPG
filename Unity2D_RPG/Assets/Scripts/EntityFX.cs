using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Flash FX")]
    [SerializeField] private Material hitMaterial;
    [SerializeField] private float hitDuration = 0.2f;
    private Material originalMaterial;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private IEnumerator FlashFX()
    {
        spriteRenderer.material = hitMaterial;

        yield return new WaitForSeconds(hitDuration);

        spriteRenderer.material = originalMaterial;

    }

    private void RedColorBlink()
    {
        if(spriteRenderer.color != Color.white)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void CancelRedBlink()
    {
        CancelInvoke();
        spriteRenderer.color = Color.white;
    }
}
