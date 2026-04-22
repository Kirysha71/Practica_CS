using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Task2
{
    public static class PeopleCounter
    {
        public static void CountPeopleInCity(List<Person> people, out string[] cities, out int[] counts)
        {
            List<string> uniqueCities = new List<string>();

            foreach (Person person in people)
            {
                bool exists = false;
                foreach (string city in uniqueCities)
                {
                    if (city == person.City)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    uniqueCities.Add(person.City);
                }
            }

            cities = new string[uniqueCities.Count];
            counts = new int[uniqueCities.Count];

            for (int i = 0; i < uniqueCities.Count; i++)
            {
                cities[i] = uniqueCities[i];
                counts[i] = 0;

                foreach (Person person in people)
                {
                    if (person.City == uniqueCities[i])
                    {
                        counts[i]++;
                    }
                }
            }
        }
    }
}
