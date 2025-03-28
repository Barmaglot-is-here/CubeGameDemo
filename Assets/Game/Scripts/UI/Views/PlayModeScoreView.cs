using System.Collections.Generic;
using UnityEngine;

public class PlayModeScoreView : MonoBehaviour
{
    [SerializeField]
    private Transform _container;

    [SerializeField]
    private GameObject _defaultInstance;
    [SerializeField]
    private Sprite[] _spritePrefabs;

    [SerializeField]
    private float _digitsSpace;

    private List<SpriteRenderer> _spriteInstances;

    public int OrderInLayer 
    {
        get => _spriteInstances[0].sortingOrder;
        set
        {
            foreach (var instance in _spriteInstances)
                instance.sortingOrder = value;
        }
    }

    public void Awake()
    {
        _spriteInstances = new();

        var firstSprite = _defaultInstance.GetComponent<SpriteRenderer>();
        _spriteInstances.Add(firstSprite);
    }

    public void Show(int score)
    {
        int i = 1;
        foreach (int spriteIndex in GetDigits(score))
        {
            if (_spriteInstances.Count < i)
            {
                var sprite = AddNew(_defaultInstance);

                _spriteInstances.Add(sprite);
            }

            _spriteInstances[^i].sprite = _spritePrefabs[spriteIndex];

            i++;
        }

        ResizeView();
    }

    public void Reset()
    {
        for (int i = 1; i < _spriteInstances.Count; i++)
        {
            var instance = _spriteInstances[i];

            _spriteInstances.Remove(instance);

            Destroy(instance.gameObject);
        }

        _spriteInstances[0].sprite = _spritePrefabs[0];
    }

    private IEnumerable<int> GetDigits(int number)
    {
        for (; number != 0;)
        {
            int digit = number / 10;

            int spriteIndex = number - digit * 10;

            number = digit;

            yield return spriteIndex;
        }
    }

    private SpriteRenderer AddNew(GameObject prefab)
    {
        var instance = Instantiate(prefab, _container);

        return instance.GetComponent<SpriteRenderer>();
    }

    private void ResizeView()
    {
        float totalWidth = 0;

        foreach (var sprite in _spriteInstances)
        {
            sprite.transform.localPosition = new (totalWidth, 0);

            totalWidth += sprite.size.x + _digitsSpace;
        }

        CenterContainer();
    }

    private void CenterContainer()
    {
        float lastSpritePosition = _spriteInstances[^1].transform.localPosition.x;
        float containerXPosition = -lastSpritePosition / 2 * _container.localScale.x;

        _container.localPosition = new(containerXPosition,
                                       _container.localPosition.y,
                                       _container.localPosition.z);
    }
}