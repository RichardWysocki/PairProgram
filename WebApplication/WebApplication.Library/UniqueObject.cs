using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Library
{
    public class UniqueObject
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
            private set { UnitId = value; }
        }

        public static UniqueObject GetbyId(int Id)
        {
            return mylistDictionary[Id];
        } 
    }
}
