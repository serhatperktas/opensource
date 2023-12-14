using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    float yasamaSuresi;
    private void Start()
    {
        Destroy(gameObject,yasamaSuresi);
    }

}
