using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightBooking.Model;

namespace FlightBooking
{
    public partial class AddFlightForm : Form
    { 
        public AddFlightForm()
        {
            InitializeComponent(); 
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            Flight flight = new Flight();
            flight.FlightName = textBox_name.Text;
            flight.From = textBox_from.Text;
            flight.To = textBox_to.Text;
            flight.FlightDate = dateTimePicker_date.Value.Date;
            flight.EconomyAvailable = Convert.ToInt32(textBox_economy.Text); 
            flight.BusinessAvailable = Convert.ToInt32(textBox_bussiness.Text); ;
            flight.FirstAvailable = Convert.ToInt32(textBox_first.Text);
            flight.BasePrice = Convert.ToDouble(textBox_base.Text); ;
            MainForm.flights.Add(flight);
            DialogResult = DialogResult.OK;
        }
    }
}
