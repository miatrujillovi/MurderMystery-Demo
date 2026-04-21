using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AYellowpaper.SerializedCollections
{
    public class LawnmowerLogic : MonoBehaviour
    {
        public enum NumberCodes
        {
            Eight,
            Six,
            Three,
            Zero
        }

        [Header("Arrow References")]
        public SerializedDictionary<NumberCodes, List<Transform>> arrows; //First transforms on the list are Up Arrows, Seconds are Down Arrows
        [SerializeField] List<TextMeshPro> codeShow; //0 = Eight, 1 = Six, 2 = Three, 3 = Zero
        [Space]
        [Header("RayCast and Mapping")]
        [SerializeField] private float interactDistance = 5f;
        [SerializeField] private LayerMask interactLayer;
        [SerializeField] private Camera cam;
        [Space]
        [Header("Action Reference")]
        [SerializeField] private DoAction doAction;

        private Dictionary<NumberCodes, int> currentValues = new Dictionary<NumberCodes, int>();

        private void Start()
        {
            foreach (NumberCodes code in System.Enum.GetValues(typeof(NumberCodes)))
            {
                currentValues[code] = 0;
            }

            UpdateAllVisuals();
        }

        #region Numbers and Visuals
        private void UpdateAllVisuals()
        {
            int index = 0;

            foreach (NumberCodes code in System.Enum.GetValues(typeof(NumberCodes)))
            {
                codeShow[index].text = currentValues[code].ToString();
                index++;
            }
        }

        private void Increase(NumberCodes _code)
        {
            currentValues[_code] = (currentValues[_code] + 1) % 10;
            UpdateSingleVisual(_code);

            if (IsCorrectCombination())
            {
                Debug.Log("Correct Code!");
                OnCorrectCode();
            }
        }

        private void Decrease(NumberCodes _code)
        {
            currentValues[_code]--;

            if (currentValues[_code] < 0)
                currentValues[_code] = 9;

            UpdateSingleVisual(_code);

            if (IsCorrectCombination())
            {
                Debug.Log("Correct Code!");
                OnCorrectCode();
            }
        }

        private void UpdateSingleVisual(NumberCodes _code)
        {
            int index = (int)_code;
            codeShow[index].text = currentValues[_code].ToString();
        }

        #endregion Numbers and Visuals

        #region Arrow Input

        private void Update()
        {
            if (InputManager.Instance.ClickPressedThisFrame)
            {
                TryInteract();
            }
        }

        private void TryInteract()
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
            {
                CheckArrowHit(hit.transform);
            }
        }

        private void CheckArrowHit(Transform _hitTransform)
        {
            foreach (var pair in arrows)
            {
                List<Transform> arrowList = pair.Value;

                if (arrowList == null || arrowList.Count < 2)
                {
                    continue;
                }

                //Up Arrows
                if (_hitTransform == arrowList[0])
                {
                    Increase(pair.Key);
                    return;
                }

                //Down Arrows
                if (_hitTransform == arrowList[1])
                {
                    Decrease(pair.Key);
                    return;
                }
            }
        }
        #endregion Arrow Input

        public bool IsCorrectCombination()
        {
            return currentValues[NumberCodes.Eight] == 8 &&
                   currentValues[NumberCodes.Six] == 6 &&
                   currentValues[NumberCodes.Three] == 3 &&
                   currentValues[NumberCodes.Zero] == 0;
        }

        private void OnCorrectCode()
        {
            doAction.GetLawnmower();
        }
    }
}
