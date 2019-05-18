using System;
namespace MyQADLL.src
{
    public class Counter
    {
        //Fields
        private int _value;

        //Constructor
        public Counter()
        {
            _value = 0;
        }

        //Property
        public int Value { get => _value; set => _value = value; }

        //Methods
        public void Increment() => _value++;
        public void Reset() => _value = 0;
        public void Decrease()
        {
            if (Value > 0)
                _value--;
        }
    }
}
