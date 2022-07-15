using UnityEngine;

namespace Chapter.State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        public void Handle(BikeController bikeControler)
        {
            if (!_bikeController) {
                _bikeController = bikeControler;
            }
            _bikeController.CurrentSpeed = 0;
        }
    }
}