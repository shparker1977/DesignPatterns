using UnityEngine;

namespace Chapter.State
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;
        private Vector3 _turnDirection;

        public void Handle(BikeController bikeControler)
        {
            if (!_bikeController) {
                _bikeController = bikeControler;
            }
            _turnDirection.x =
                (float) _bikeController.CurrentTurnDirection;

            if (_bikeController.CurrentSpeed > 0)
            {
                transform.Translate(_turnDirection * _bikeController.turnDistance);
            }
        }

        void Update()
        {
            if (_bikeController && _bikeController.CurrentSpeed < 0)
            {
                _bikeController.transform.Translate(
                    Vector3.forward * (
                        _bikeController.CurrentSpeed *
                        Time.deltaTime));
            }
        }
    }
}