using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXmanager : MonoBehaviour
{
    public GameObject vfxBumper;
    public GameObject vfxSwitch;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VFXBumper(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxBumper, spawnPosition, Quaternion.identity);
    }
    public void VFXSwitch(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxSwitch, spawnPosition, Quaternion.identity);
    }
}
