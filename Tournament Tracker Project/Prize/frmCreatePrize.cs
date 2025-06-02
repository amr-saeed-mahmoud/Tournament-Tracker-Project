using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project
{
    public partial class frmCreatePrize : Form
    {
        public event EventHandler<clsPrize> OnPrizeCreated;
        protected virtual void RaiseOnPrizeCreated(clsPrize clsPrize) => OnPrizeCreated?.Invoke(this, Prize);

        private decimal CurPrizePercentage;
        private decimal RestOfTournamentMoney;
        private decimal TotalTournamentMoney;

        private clsPrize Prize = new clsPrize();
        private void ValidNumber(object sender, CancelEventArgs e)
        {
            TextBox Input = (TextBox)sender;
            if (!clsValidation.IsValidNumber(Input.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Input, "Enter A Valid Number");
            }
            else errorProvider1.SetError(Input, null);
        }
        private void txtPlaceName_Validating(object sender, CancelEventArgs e)
        {
            if(!clsValidation.IsValidName(txtPlaceName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPlaceName, "Enter A Valid Name.");
            }
            else errorProvider1.SetError(txtPlaceName, null);
        }
        private void txtPrizePercentage_Validating(object sender, CancelEventArgs e)
        {
            if(txtPrizePercentage.Enabled == true)
            {
                if (!clsValidation.IsValidNumber(txtPrizePercentage.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPrizePercentage, "Enter A Valid Number");
                }
                else if (CurPrizePercentage + Convert.ToDecimal(txtPrizePercentage.Text.Trim()) > 100)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPrizePercentage, $"Enter A Valid Prize Percentage, Prize Percentage is grater than 100 => Current Prize Percentage = {CurPrizePercentage}");
                }
                else errorProvider1.SetError(txtPrizePercentage, null);
            }
            else errorProvider1.SetError(txtPrizePercentage, null);

        }
        private void txtPrizeAmount_Validating(object sender, CancelEventArgs e)
        {
            if(txtPrizeAmount.Enabled == true)
            {
                if (!clsValidation.IsValidNumber(txtPrizeAmount.Text.Trim()))
                {
                    errorProvider1.SetError(txtPrizeAmount, "Enter A Valid Number");
                    e.Cancel = true;
                }
                else if (RestOfTournamentMoney < Convert.ToDecimal(txtPrizeAmount.Text.Trim()))
                {
                    errorProvider1.SetError(txtPrizeAmount, $"Enter A Valid Prize Amount, Prize Amount is grater than Rest of Money => {RestOfTournamentMoney}");
                    e.Cancel = true;
                }
                else errorProvider1.SetError(txtPrizeAmount, null);
            }
            else errorProvider1.SetError(txtPrizeAmount, null);
        }

        public frmCreatePrize(decimal CurPrizePercentage, decimal RestOfTournamentMoney, decimal totalTournamentMoney)
        {
            InitializeComponent();
            this.CurPrizePercentage = CurPrizePercentage;
            this.RestOfTournamentMoney = RestOfTournamentMoney;
            TotalTournamentMoney = totalTournamentMoney;
        }

        private void txtPrizeAmount_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPrizeAmount.Text))
            {
                txtPrizePercentage.Enabled = false;
                txtPrizePercentage.Clear(); // Clear any existing value in txtPrizePercentage
                errorProvider1.SetError(txtPrizePercentage, null);
            }
            else
                txtPrizePercentage.Enabled = true;

        }

        private void txtPrizePercentage_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrizePercentage.Text))
            {

                // Enable txtPrizePercentage and disable txtPrizeAmount
                txtPrizeAmount.Enabled = false;
                txtPrizeAmount.Clear(); // Clear any existing value in txtPrizeAmount
                errorProvider1.SetError(txtPrizeAmount, null);
            }
            else
                txtPrizeAmount.Enabled = true;
        }

        // in here we create object Prize only and send it to frmCreateTournament by Event Handler
        private void btnCreatePrize_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are fields that are not Valid In Add New Member Info. Point to the red dots to read the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Prize.PlaceNumber = Convert.ToInt32(txtPlaceNumber.Text.Trim());// take place number
            Prize.PlaceName = txtPlaceName.Text.Trim();// take place name
            
            if(string.IsNullOrEmpty(txtPrizeAmount.Text.Trim()))// if prize percentage is enterded 
            {
                Prize.PrizePercentage = Convert.ToDecimal(txtPrizePercentage.Text.Trim());
                Prize.PrizeAmount = (Prize.PrizePercentage/100) * TotalTournamentMoney;
            }
            else// if prize amount is enterded
            {
                Prize.PrizeAmount = Convert.ToDecimal(txtPrizeAmount.Text.Trim());
                Prize.PrizePercentage = (Prize.PrizeAmount / TotalTournamentMoney) * 100;
            }
            MessageBox.Show("Prize Created Sucessfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RestOfTournamentMoney -= Prize.PrizeAmount;
            CurPrizePercentage += Prize.PrizePercentage;
            RaiseOnPrizeCreated(Prize);
            SetDefaultValue();
        }
        private void SetDefaultValue()
        {
            txtPlaceName.Text = "";
            txtPlaceNumber.Text = "";
            txtPrizeAmount.Text = "";
            txtPrizePercentage.Text = "";
            Prize = new clsPrize();
        }
        private void frmCreatePrize_Load(object sender, EventArgs e)
        {
            SetDefaultValue();
        }

       
    }
}
