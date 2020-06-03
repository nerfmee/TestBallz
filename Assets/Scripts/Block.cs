using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int _hitsRemaining = 5;
    private SpriteRenderer _spriteRenderer;
    private TextMeshPro text;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        text.SetText(_hitsRemaining.ToString());
        _spriteRenderer.color = Color.Lerp(Color.white, Color.red, _hitsRemaining / 10f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _hitsRemaining--;

        if (_hitsRemaining > 0)
            UpdateVisualState();
        else
            Destroy(gameObject);
    }

    public void SetHits(int hits)
    {
        _hitsRemaining = hits;
        UpdateVisualState();;
    }
}
