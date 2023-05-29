using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    //1 = invisible 0 = visible
    public float dissolveAmount;
    public float dissolveSpeed;
    public bool isDissolving;

    [ColorUsageAttribute(true, true)]
    public Color outColor;
    [ColorUsageAttribute(true, true)]
    public Color inColor;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        DissolveManager();
    }

    public void DissolveManager()
    {
        if (isDissolving)
        {
            DissolveOut(dissolveSpeed, outColor);
        }
        if (!isDissolving)
        {
            DissolveIn(dissolveSpeed, inColor);
        }

        material.SetFloat("_DisolveAmount", dissolveAmount);
    }

    public void DissolveOut(float speed, Color color)
    {
        material.SetColor("_EdgeColor", color);
        if (dissolveAmount > -0.1)
        {
            dissolveAmount -= Time.deltaTime * speed;
        }
    }
    public void DissolveIn(float speed, Color color)
    {
        material.SetColor("_EdgeColor", color);
        if (dissolveAmount < 1)
        {
            dissolveAmount += Time.deltaTime * speed;
        }
    }
}
