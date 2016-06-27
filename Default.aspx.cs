using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    #region Fields_Properties
    protected ChadCarter.CodeSample.BLL.Employee Employee_BLL = new ChadCarter.CodeSample.BLL.Employee();
    protected ChadCarter.CodeSample.BLL.Customer Customer_BLL = new ChadCarter.CodeSample.BLL.Customer();
    protected ChadCarter.CodeSample.BLL.State State_BLL = new ChadCarter.CodeSample.BLL.State();
    protected ChadCarter.CodeSample.BLL.CareerBuilder CB_BLL = new ChadCarter.CodeSample.BLL.CareerBuilder();
    List<ChadCarter.CodeSample.BLL.Customer> custs;
    List<ChadCarter.CodeSample.BLL.Employee> employees;
    List<ChadCarter.CodeSample.BLL.State> states;
    #endregion

    #region Page_Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        bindLists();

        if (!Page.IsPostBack)
        {
            createRadioList();
            populateStateDDL();
        }
        createEventHandlers();
    }
    #endregion

    #region Event_Handlers
    protected void createEventHandlers()
    {
        rdlPersonType.SelectedIndexChanged += new EventHandler(rdlPersonType_SelectedIndexChange);
        lbPerson.SelectedIndexChanged += new EventHandler(lbPerson_SelectedIndexChange);
        btnAdd.Click += new EventHandler(btnUpsert_Click);
        btnUpdate.Click += new EventHandler(btnUpsert_Click);
        btnDelete.Click += new EventHandler(btnDelete_Click);
        btnReverseString.Click += new EventHandler(btnReverseString_Click);
        btnCountCharacters.Click += new EventHandler(btnCountCharacters_Click);
    }
    protected void rdlPersonType_SelectedIndexChange(object sender, System.EventArgs e)
    {
        populateListBox();
    }
    protected void lbPerson_SelectedIndexChange(object sender, System.EventArgs e)
    {
        int selected = Convert.ToInt32(lbPerson.SelectedValue.ToString());
        if (rdlPersonType.SelectedValue.ToString() == "emp")
        {
            ChadCarter.CodeSample.BLL.Employee result = employees.Where(p => p.ID == selected).FirstOrDefault();
            txtFirstNM.Text = result.First_NM;
            txtLastName.Text = result.Last_NM;
            txtAddress.Text = result.Address;
            txtCity.Text = result.City;
            ddlState.ClearSelection();
            ddlState.Items.FindByValue(result.State.ToString()).Selected = true;
            txtZip.Text = result.Zip.ToString();
            ddlPersonType.ClearSelection();
            ddlPersonType.Items.FindByValue("emp").Selected = true;
        } else if (rdlPersonType.SelectedValue.ToString() == "cust")
        {
            ChadCarter.CodeSample.BLL.Customer result = custs.Where(p => p.ID == selected).FirstOrDefault();
            txtFirstNM.Text = result.First_NM;
            txtLastName.Text = result.Last_NM;
            txtAddress.Text = result.Address;
            txtCity.Text = result.City;
            ddlState.ClearSelection();
            ddlState.Items.FindByValue(result.State.ToString()).Selected = true;
            txtZip.Text = result.Zip.ToString();
            ddlPersonType.ClearSelection();
            ddlPersonType.Items.FindByValue("cust").Selected = true;
        }
    }
    protected void btnUpsert_Click(object sender, System.EventArgs e)
    {
        int id = 0;
        int ret = 0;
        string first_nm;
        string last_nm;
        string address;
        string city;
        int state;
        int zip;
        string ptype;

        lblSTatus.Text = "";
        if (txtFirstNM.Text == "") { lblSTatus.Text = "Please Enter a First Name"; return; } else { first_nm = txtFirstNM.Text; }
        if (txtLastName.Text == "") { lblSTatus.Text = "Please Enter a Last Name"; return; } else { last_nm = txtLastName.Text; }
        if (txtAddress.Text == "") { lblSTatus.Text = "Please Enter an Address"; return; } else { address = txtAddress.Text; }
        if (txtCity.Text == "") { lblSTatus.Text = "Please Enter a City"; return; } else { city = txtCity.Text; }
        if (!Int32.TryParse(ddlState.SelectedValue.ToString(), out state)) { lblSTatus.Text = "The state selected is invalid"; return; }
        if (!Int32.TryParse(txtZip.Text, out zip)) { lblSTatus.Text = "The zipcode is invalid"; return; }
        if (ddlPersonType.SelectedValue.ToString() == "0") { lblSTatus.Text = "Please Select a Person Type"; return; } else { ptype = ddlPersonType.SelectedValue.ToString(); }

        Button clickedButton = sender as Button;
        
        if (clickedButton == null)
            return;

        if (clickedButton.ID == "btnUpdate")
        {
            id = Convert.ToInt32(lbPerson.SelectedValue.ToString());
        }

        if (ptype == "emp")
        {
            ret = Employee_BLL.UpsertPerson(id, first_nm, last_nm, address, city, state, zip);
        } else if (ptype == "cust")
        {
            ret = Customer_BLL.UpsertPerson(id, first_nm, last_nm, address, city, state, zip);
        } else
        {
            lblSTatus.Text = "Unable to determine Person Type";
            return;
        }

        if (ret != 1)
        {
            if (clickedButton.ID == "btnUpdate")
            {
                lblSTatus.Text = "An error occured while updating the record.";
                return;
            }
            else
            {
                lblSTatus.Text = "An error occured while adding the record.";
                return;
            }
        } else
        {
            lblSTatus.Text = "Record successfully updated.";
        }
    }
    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
        int id = 0;
        string ptype;
        int ret = 0;
        id = Convert.ToInt32(lbPerson.SelectedValue.ToString());
        if (ddlPersonType.SelectedValue.ToString() == "0") { lblSTatus.Text = "Please Select a Person Type"; return; } else { ptype = ddlPersonType.SelectedValue.ToString(); }
        if (ptype == "emp")
        {
            ret = Employee_BLL.DeletePerson(id);
        }
        else if (ptype == "cust")
        {
            ret = Customer_BLL.DeletePerson(id);
        }
        else
        {
            lblSTatus.Text = "Unable to determine Person Type";
            return;
        }
        if (ret != 1)
        {
            lblSTatus.Text = "An error occured while deleting the record.";
                return;
        
        } else
        {
            lblSTatus.Text = "Record successfully deleted.";
        }
    }
    protected void btnReverseString_Click(object sender, System.EventArgs e)
    {
        lblReverseString.Text = CB_BLL.ReverseOrder(txtReverseString.Text);
    }
    protected void btnCountCharacters_Click(object sender, System.EventArgs e)
    {
        lblCharactersCount.Text = CB_BLL.CountCharacterOccurenceOrdinally(txtCountCharacters.Text);
    }
    #endregion

    #region Loads
    protected void bindLists()
    {
        custs = Customer_BLL.SelectAllPeople().OrderBy(x => x.Full_NM).ToList();
        employees = Employee_BLL.SelectAllPeople().OrderBy(x => x.Full_NM).ToList();
    }
    protected void createRadioList()
    {
        rdlPersonType.Items.Clear();
        rdlPersonType.Items.Add(new ListItem("Employees: " + employees.Count.ToString(), "emp"));
        rdlPersonType.Items.Add(new ListItem("Customers: " + custs.Count.ToString(), "cust"));
    }
    protected void populateStateDDL()
    {
        ddlState.Items.Clear();
        states = State_BLL.SelectAllState();
        ddlState.Items.Add(new ListItem("", "0"));
        foreach (ChadCarter.CodeSample.BLL.State state in states)
        {
            ddlState.Items.Add(new ListItem(state.State_Full, state.State_ID.ToString()));
        }
    }
    protected void populateListBox()
    {
        lbPerson.Items.Clear();

        if (rdlPersonType.SelectedValue.ToString() == "emp")
        {
            foreach (ChadCarter.CodeSample.BLL.Employee emp in employees)
            {
                lbPerson.Items.Add(new ListItem(emp.Full_NM, emp.ID.ToString()));
            }

        }
        else if (rdlPersonType.SelectedValue.ToString() == "cust")
        {
            foreach (ChadCarter.CodeSample.BLL.Customer cust in custs)
            {
                lbPerson.Items.Add(new ListItem(cust.Full_NM, cust.ID.ToString()));
            }
        }
    }
    #endregion

}