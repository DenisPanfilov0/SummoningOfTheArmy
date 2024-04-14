using System;
using CodeBase.EditorTool;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.TestTools
{
    public class TestSO : MonoBehaviour
    {
        [SerializeField] private UnitConfig _unitConfig;

        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(Test);
        }

        [Button]
        public void Test()
        {
            Debug.Log("нажали на задний фон");
        }
    }
    


}