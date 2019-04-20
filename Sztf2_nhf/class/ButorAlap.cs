﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sztf2_nhf
{
    abstract class ButorAlap : IMeret
    {
        public double Szelesseg { get; set; }
        public double Magassag { get; set; }
        public double Hosszusag { get; set; }
        abstract public double Alapterulet { get; set; }

        public ButorAlap(int szel, int magas, int hossz)
        {
            this.Szelesseg = szel;
            this.Magassag = magas;
            this.Hosszusag = hossz;
        }
        //public abstract override string ToString();

        public override bool Equals(object obj)
        {
            return (obj as ButorAlap).Szelesseg.Equals(this.Szelesseg) && (obj as ButorAlap).Hosszusag.Equals(this.Hosszusag) && (obj as ButorAlap).Magassag.Equals(this.Magassag);
        }
    }
}
