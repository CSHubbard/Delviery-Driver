using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField] Color32 hasPackageColor = new Color32(255, 0, 0, 255);
  [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
  [SerializeField] float destroyDelay = .5f;
  bool hasPackage;

  SpriteRenderer spriteRenderer;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("Ow!");

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Package" && !hasPackage)
    {
      hasPackage = true;
      Debug.Log("package retrieved!");
      Destroy(other.gameObject, destroyDelay);
      spriteRenderer.color = hasPackageColor;
    }
    else if (other.tag == "Customer" && hasPackage)
    {
      hasPackage = false;
      Debug.Log("delivered!");
      spriteRenderer.color = noPackageColor;
    }
  }
}
