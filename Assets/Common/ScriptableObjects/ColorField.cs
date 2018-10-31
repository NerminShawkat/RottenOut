using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Kandooz
{
    [CreateAssetMenu(menuName = "Kandooz/Color Field")]

    public class ColorField : ScriptableObject
    {
        public event Action<Color> onChange;
        [SerializeField]
        [ColorUsageAttribute(true,true)]
        private Color value;
        private float intensty = 1;

        public Color Value
        {
            get
            {
                Color c = new Color(this.value.r, this.value.g, this.value.b, this.value.a);
                c.r *= intensty;
                c.g *= intensty;
                c.b *= intensty;

                return c;
            }

            set
            {

                if (this.value != value)
                {
                    this.value = value;

                    if (onChange != null)
                    {
                        Color c = new Color(this.value.r, this.value.g, this.value.b, this.value.a);

                        c.r *= intensty;
                        c.g *= intensty;
                        c.b *= intensty;
                        onChange(c);
                    }
                }
            }
        }

        public float Intensty
        {
            get
            {
                return intensty;
            }

            set
            {
                intensty = value;
                if (onChange != null)
                {

                    Color c = new Color(this.value.r,this.value.g,this.value.b,this.value.a);
                    c.r *= intensty;
                    c.g *= intensty;
                    c.b *= intensty;
                    onChange(c);

                }

            }
        }
    }
}
