using System;
using System.Collections.Generic;

namespace lib
{
        [Serializable]
        public class Fases
        {
                public bool fase0 = true;
                public bool fase1 = true;
                public bool fase2 = true;
                public bool fase3 = true;
                public bool fase4 = true;
                public bool fase5 = true;
                public bool fase6 = true;
                public bool fase7 = true;
                private List<bool> fases;

                public Fases()
                {
                        fases = new List<bool>() {fase0,fase1,fase2,fase3,fase4,fase5,fase6,fase7};
                }

                public bool getState(int n)
                {
                        return fases[n];
                }
        
        }
}