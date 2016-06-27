using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChadCarter.CodeSample.Base;

namespace ChadCarter.CodeSample.BLL
{
    /// <summary>
    /// Summary description for Employee
    /// </summary>
    public class Employee : Person
    {
        #region Fields_Properties
        ChadCarter.CodeSample.DAL.Person<Employee> sample_BLL = new ChadCarter.CodeSample.DAL.Person<Employee>();
        #endregion

        #region Constructors
        public Employee() { }
        public Employee(int PersonID, string First_NM, string Last_NM, string Address, string City, int State, string State_Short, string State_Long,
                int Zip, string PType) : base(PersonID, First_NM, Last_NM, Address, City, State, State_Short, State_Long, Zip, PType) { }
        #endregion

        #region Methods
        public List<Employee> SelectAllPeople()
        {
            return sample_BLL.SelectAllPeople();
        }
        #endregion

        public override int UpsertPerson(int pid, string first_nm, string last_nm, string address, string city, int state, int zip)
        {
            return sample_BLL.UpsertPerson(pid, first_nm, last_nm, address, city, state, zip);
        }
        public override int DeletePerson(int pid)
        {
            return sample_BLL.DeletePerson(pid);
        }
    }
}