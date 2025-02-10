using UnityEngine;
using CustomControls;

public class CarouselController : MonoBehaviour
{
    [SerializeField]
    private Carousel _carousel;
    [SerializeField]
    private SelectionController _selectionController;
    [SerializeField]
    private SwipeManager _swipeManager;

    private void Awake()
    {
        _swipeManager.OnSwipe += OnSwipe;
    }

    private void OnSwipe(SwipeDirection direction)
    {
        if (direction == SwipeDirection.Up)
        {
            _carousel           .ScrollNext();
            _selectionController.SelectNext();
        }
        else if (direction == SwipeDirection.Down)
        {
            _carousel           .ScrolLast();
            _selectionController.SelectLast();
        }
    }
}