using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Serializer
    {
        public void Serialize(object obj)
        {
            if (!obj.GetType().IsSerializable)
                throw new Exception("Объект не сериализуем");
        }
    }
}
