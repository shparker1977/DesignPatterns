using UnityEngine;

namespace Chapter.State
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        public void Handle(BikeController bikeControler)
        {
            if (!_bikeController) {
                _bikeController = bikeControler;
            }
            _bikeController.CurrentSpeed = _bikeController.maxSpeed;
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