using CustomControls;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Character _character;
    [SerializeField]
    private SwipeManager _swipeManager;

    private void Awake()
    {
        _swipeManager.OnSwipe += OnSwipe;
    }

    private void OnSwipe(SwipeDirection direction)
    {
        switch (direction)
        {
            case SwipeDirection.Up:
                _character.ChangeDirectionUp(); 

                break;
            case SwipeDirection.Down:
                _character.ChangeDirectionDown(); 

                break;
            case SwipeDirection.Right:
                _character.UseAbility(); 

                break;
        }
    }
}