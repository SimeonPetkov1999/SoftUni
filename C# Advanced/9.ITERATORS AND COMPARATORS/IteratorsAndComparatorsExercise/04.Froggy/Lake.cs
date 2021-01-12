using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    class Lake : IEnumerable<int>
    {
        public List<int> Numbers { get; set; }

        public Lake(List<int> numbers)
        {
            this.Numbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.Numbers[i];
                }
            }


            for (int i = this.Numbers.Count - 1; i >= 0; i--)
            {
                if(i % 2 != 0)
                {
                    yield return this.Numbers[i];
                }
            }
                
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
