using UnityEngine;
using System.Collections.Generic;

public class BucketAnimator : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public List<Sprite> images;
    private int _imageIndex, _tick;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _tick++;

        if (_tick > 5)
        {
            _tick = 0;
            _imageIndex = (_imageIndex + 1) % images.Count;
            _renderer.sprite = images[_imageIndex];
        }
    }

}
