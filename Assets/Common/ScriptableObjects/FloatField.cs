using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Kandooz
{
    [CreateAssetMenu(menuName = "Kandooz/Float Field")]
    public class FloatField : ScriptableObject
    {
        [SerializeField]
        private float value;
        public event System.Action<float> OnValueChanged;

        public float Value
        {
            get
            {
                return value;
            }

            set
            {
                if (Mathf.Abs(value - this.value) > 0.0001)
                {
                    
                    OnValueChanged?.Invoke(value);
                    this.value = value;

                }
            }
        }

        public static implicit operator float(FloatField b)
        {
            return b.Value;

        }
    }
}
