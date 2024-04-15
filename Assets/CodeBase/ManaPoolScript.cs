using System;
using CodeBase.Config;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.State
{
    public class ManaPoolScript : MonoBehaviour
    {
        [SerializeField] private float _maxMana;
        
        [SerializeField] public float CurrentMana;
        
        [SerializeField] private float _manaRegeneration;
        
        [SerializeField] private Image _manaBar;

        public void Init(MainPlayerConfig config)
        {
            _maxMana = config.MaxManaPool;
            CurrentMana = config.StartManaPool;
            _manaRegeneration = config.ManaRegeneration;
        }

        private void Update()
        {
            // Увеличиваем текущее значение маны на скорость регенерации
            CurrentMana += _manaRegeneration * Time.deltaTime;
            // Ограничиваем текущее значение максимальным значением маны
            CurrentMana = Mathf.Clamp(CurrentMana, 0f, _maxMana);

            // Обновляем отображение маны на изображении маны
            UpdateManaBar();
        }

        private void UpdateManaBar()
        {
            // Рассчитываем процент заполнения маны для изображения
            float fillAmount = CurrentMana / _maxMana;
            // Устанавливаем fillAmount для изображения маны
            _manaBar.fillAmount = fillAmount;
        }
    }
}