using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMatOffset : MonoBehaviour
{
    private Renderer renderer;
    [SerializeField][Range(0,.2f)]private float scrollSpeed=.1f;
    void Start()
    {
        renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));//çapraz hareket etsin
    }
}
