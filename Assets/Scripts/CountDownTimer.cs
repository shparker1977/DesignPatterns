using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
    public class CountDownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float duration = 3.0f;

        void onEnable() {
            RaceEventBus.Subscribe(
                RaceEventType.COUNTDOWN, StartTimer);
        }

        void onDisable() {
            RaceEventBus.Unsubscribe(
                RaceEventType.COUNTDOWN, StartTimer);
        }

        private void StartTimer() {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown() {
            _currentTime = duration;

            while (_currentTime > 0) {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }

            RaceEventBus.Publish(RaceEventType.START);
        }

        void onGUI() {
            GUI.color = Color.blue;
            GUI.Label(
                new Rect(125, 0, 100, 20),
                "COUNTDOWN: " + _currentTime);
        }
    }
}