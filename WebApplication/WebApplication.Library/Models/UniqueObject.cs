using System.Collections.Generic;

namespace WebApplication.Library
{
    public class UniqueObject : IUniqueObject
    {
        private readonly int _id;
        private static Dictionary<int, UniqueObject> mylistDictionary = new Dictionary<int, UniqueObject>();

        public UniqueObject(int id)
        {
            _id = id;
            mylistDictionary.Add(id,this);
            
        }

        public int UnitId
        {
            get { return _id * 2; }
            set { UnitId = value; }
        }

        public static UniqueObject GetbyId(int Id)
        {
            return mylistDictionary[Id];
        } 
    }
}
