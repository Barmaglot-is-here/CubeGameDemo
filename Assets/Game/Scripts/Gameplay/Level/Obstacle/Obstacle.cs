using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject[] _sections;

    public new Rigidbody2D rigidbody { get; private set; }

    private void Awake()
    {
        _sections = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);

            _sections[i] = child.gameObject;
        }

        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Construct(ObstacleData data)
    {
        for (int i = 0; i < _sections.Length; i++)
        {
            var section = _sections[i];
            var enabled = data.SectionEnabled[i];

            section.SetActive(enabled);
        }
    }
}