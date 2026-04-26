using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2
{
    public class DataSerializer
    {
        public void SerializeData(object obj)
        {
            try
            {
                new Serializer().Serialize(obj);
            }
            catch (SerializationException ex)
            {
                throw new SerializationOperationException("Ошибка в сериализации", ex);
            }
        }
    }
}
