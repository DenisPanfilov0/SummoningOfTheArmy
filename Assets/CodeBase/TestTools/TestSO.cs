using CodeBase.EditorTool;
using UnityEngine;

namespace CodeBase.TestTools
{
    public class TestSO : MonoBehaviour
    {
        [SerializeField] private UnitConfig _unitConfig;

        [Button]
        public void Test()
        {
            _unitConfig.DamageCalculated();
        }
    }
    


}