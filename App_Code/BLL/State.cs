using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChadCarter.CodeSample.BLL
{
    /// <summary>
    /// Summary description for State
    /// </summary>
    public class State
    {
        #region Fields_Properties
        ChadCarter.CodeSample.DAL.State sample_BLL = new ChadCarter.CodeSample.DAL.State();

        private int state_id;
        public int State_ID
        {
            get { return state_id; }
            set { state_id = value; }
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
        private string state_full;

        public string State_Full
        {
            get { return state_full; }
            set { state_full = value; }
        }


        #endregion

        #region Constructors
        public State() { }
        public State(int state_id, string state_short, string state_long) : this()
        {
            this.State_ID = state_id;
            this.State_Short = state_short;
            this.State_Long = state_long;
            this.State_Full = state_short + " - " + state_long;
        }
        #endregion
        #region Methods
        public List<ChadCarter.CodeSample.BLL.State> SelectAllState()
        {
            return sample_BLL.SelectAllState();
        }
        #endregion
    }
}