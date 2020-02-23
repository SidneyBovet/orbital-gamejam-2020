using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLighting : MonoBehaviour
{
    public Light light1;
    public Light light2;

    public Color positive1;
    public Color positive2;
    public Color negative1;
    public Color negative2;

    // Temporary buffers
    Color buffer1;
    Color buffer2;

    int lastCharge = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastCharge = GameManager.Instance.currentCharge;

        TestCharge();

        SwapColors();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sign(lastCharge) != Mathf.Sign(GameManager.Instance.currentCharge))
        {
            lastCharge = GameManager.Instance.currentCharge;

            TestCharge();
        }

        SwapColors();
    }

    void SwapColors()
    {
        // Lerp colors for smooth effects FFS!
        light1.color = Color.Lerp(light1.color, buffer1, 3.0f * Time.deltaTime);
        light2.color = Color.Lerp(light2.color, buffer2, 3.0f * Time.deltaTime);
    }

    void TestCharge()
    {
        if (Mathf.Sign(lastCharge) > 0)
        {
            buffer1 = positive1;
            buffer2 = positive2;
        }
        else
        {
            buffer1 = negative1;
            buffer2 = negative2;
        }
    }
}
