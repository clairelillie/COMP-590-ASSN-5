using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    public float extendSpeed = 0.1f;
    private float minScale = 0f;
    private float maxScale;
 
    private float currentScale;
    private float initialScaleX;
    private float initialScaleZ;

    private float extendDelta;
    private bool weaponActive;

    public GameObject blade;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Start");
        initialScaleX = transform.localScale.x;
        initialScaleZ = transform.localScale.z;

        maxScale = transform.localScale.y;

        currentScale = maxScale;

        extendDelta = maxScale / extendSpeed;
        weaponActive = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar");
            aud = GetComponent<AudioSource>();
            aud.Play();
            extendDelta = weaponActive ? -Mathf.Abs(extendDelta) : Mathf.Abs(extendDelta);
            

        }
        currentScale += extendDelta * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
        transform.localScale = new Vector3(initialScaleX, currentScale, initialScaleZ);
        weaponActive = currentScale > 0;

        if (weaponActive && !blade.activeSelf)
        {
            blade.SetActive(true);
        }
        else if (!weaponActive && blade.activeSelf)
        {
            blade.SetActive(false);
        }
    }
}
