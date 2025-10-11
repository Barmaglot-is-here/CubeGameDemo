using UnityEngine;

//Класс подстраивающий положение объектов под ширину экрана
public class LevelResizeUtility : MonoBehaviour
{
    [SerializeField]
    private Transform _deathZone;
    private Transform _spawnPoint;

    private void Awake()
    {
        Destroy(this);
    }
}