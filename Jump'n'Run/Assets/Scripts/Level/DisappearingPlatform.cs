using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{

    public float timeToToggle;
    public float currentTime;
    public float delay;
    public bool enabled;
    
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        currentTime -= delay;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToToggle)
        {
            currentTime = 0;
            togglePlatform();
        }
    }

    void togglePlatform()
    {
        enabled = !enabled;
        foreach (Transform child in gameObject.transform)
        {
            if (!child.CompareTag("Player"))
            {
                child.gameObject.SetActive(enabled);
            }
    }
    }
}
