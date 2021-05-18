using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public GameObject barSprite;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNomalized) {
        bar.localScale = new Vector3(sizeNomalized, 1f);
    }
    public void SetColor(Color color)
    {
        barSprite.GetComponent<SpriteRenderer>().color = color;
    }
}
