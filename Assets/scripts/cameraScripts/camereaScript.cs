using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camereaScript : MonoBehaviour
{
    [SerializeField]
    Transform hedefTransform;
    [SerializeField]
    Transform ustZemin,altZemin;
    [SerializeField]
    float minY, maxY;

    Vector2  sonPos;

    private void Start()
    {
        sonPos = transform.position;
    }
    private void Update()
    {
        kamerayiSinirla();
        zeminleriSinirla();
    }

    void kamerayiSinirla() {
            transform.position = new Vector3(hedefTransform.position.x,
            Mathf.Clamp(hedefTransform.position.y, minY, maxY), 
            transform.position.z);
    }
    void zeminleriSinirla()
    {
        Vector2 aradakiMiktar = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);
        altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        ustZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f) * .5f ;
        sonPos = transform.position;
    }
}
