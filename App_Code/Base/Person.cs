using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChadCarter.CodeSample.Base
{
    public abstract class Person
    {
        #region Fields_Properties
        ChadCarter.CodeSample.DAL.Person<ChadCarter.CodeSample.BLL.Customer> customer_BLL = 
            new ChadCarter.CodeSample.DAL.Person<ChadCarter.CodeSample.BLL.Customer>();
        ChadCarter.CodeSample.DAL.Person<ChadCarter.CodeSample.BLL.Employee> employee_BLL = 
            new ChadCarter.CodeSample.DAL.Person<ChadCarter.CodeSample.BLL.Employee>();

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string first_nm;
        public string First_NM
        {
            get { return first_nm; }
            set { first_nm = value; }
        }
        private string last_nm;
        public string Last_NM
        {
            get { return last_nm; }
            set { last_nm = value; }
        }
        private string full_nm;
        public string Full_NM
        {
            get { return full_nm; }
            set { full_nm = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private int state;
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private string state_short;
        public string State_Short
        {
            get { return state_short; }
            set { state_short = value; }
        }
        private string state_long;
        public string State_Long
        {
            get { return state_long; }
            set { state_long = value; }
        }
        private int zip;
        public int Zip
        {
            get { return zip; }
            set { zip = value; }
        }
        private string ptype;

        public string PType
        {
            get { return ptype; }
            set { ptype = value; }
        }

        #endregion

        #region Constructors
        public Person() { }
        public Person(int PersonID, string First_NM, string Last_NM, string Address, string City, int State,
            string State_Short, string State_Long, int Zip, string PType) : this()
        {
            if (PersonID <= 0) { throw new ArgumentOutOfRangeException("PersonID"); } else { id = PersonID; }
            if (First_NM == null) { throw new ArgumentNullException("First_NM"); } else { first_nm = First_NM; }
            if (Last_NM == null) { throw new ArgumentNullException("Last_NM"); } else { last_nm = Last_NM; }
            full_nm = first_nm + ' ' + last_nm;
            if (Address == null) { throw new ArgumentNullException("Address"); } else { address = Address; }
            if (City == null) { throw new ArgumentNullException("City"); } else { city = City; }
            if (State <= 0) { throw new ArgumentOutOfRangeException("State"); } else { state = State; }
            if (State_Short == null) { throw new ArgumentNullException("State_Short"); } else { state_short = State_Short; }
            if (State_Long == null) { throw new ArgumentNullException("State_Long"); } else { state_long = State_Long; }
            if (Zip <= 0) { throw new ArgumentOutOfRangeException("Zip"); } else { zip = Zip; }
            if (PType == null) { throw new ArgumentNullException("PType"); } else { ptype = PType; }
        }
        #endregion

        #region Methods
        abstract public int UpsertPerson(int pid, string first_nm, string last_nm, string address, string city, int state, int zip);
        abstract public int DeletePerson(int pid);
        #endregion
    }

}