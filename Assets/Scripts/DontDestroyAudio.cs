using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Don't destroy audio
public class DontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);


    }

}
