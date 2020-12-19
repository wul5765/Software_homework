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
    public partial class BookingForm : Form
    {
        private Flight flight;

        public BookingForm(Flight flight)
        {
            InitializeComponent();
            this.flight = flight;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            if (flight != null)
            {
                textBox1.Text = flight.FlightName;
                textBox2.Text = flight.From;
                textBox3.Text = flight.To;
                dateTimePicker1.Value = flight.FlightDate;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_vip.Checked)
            {
                checkBox_meal.Enabled = true;
                checkBox_pickup.Enabled = true;
            }
            else
            {
                checkBox_meal.Enabled = false;
                checkBox_pickup.Enabled = false;
            }
        }


        double totalPrice;
        double discount;
        double finalPrice;
        private void button2_Click(object sender, EventArgs e)
        {
            totalPrice = flight.BasePrice;
            double beishu = 1;

            if (comboBox_cabintype.SelectedIndex == 0)
            {
                beishu = 1;
            }
            else if (comboBox_cabintype.SelectedIndex == 1)
            {
                beishu = 2;
            }
            else if (comboBox_cabintype.SelectedIndex == 2)
            {
                beishu = 4.5;
            }

            totalPrice = totalPrice * beishu;

            if (checkBox_meal.Checked)
            {
                totalPrice = totalPrice + 7;
            }

            if (checkBox_pickup.Checked)
            {
                totalPrice = totalPrice + 12;
            }

            label10.Text = "Total: $ " + totalPrice;

            if (checkBox_vip.Checked)
            {
                label12.Text = "Discount: $ " + totalPrice * 0.1;
                discount = totalPrice * 0.1;
                label13.Text = "Final Price: $ " + totalPrice * 0.9;
                finalPrice = totalPrice * 0.9;
            }
            else
            { 
                label12.Text = "Discount: $ 0";
                discount = 0;
                label13.Text = "Final Price: $ " + totalPrice;
                finalPrice = totalPrice;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking();
            Passenger passenger = new Passenger();
            passenger.Name = textBox_pname.Text;
            passenger.Number = textBox_pnumber.Text;
            passenger.IsVip = checkBox_vip.Checked;

            booking.Flight = flight;
            booking.Passenger = passenger;
            if (comboBox_ltype.SelectedIndex == 0)
            {
                booking.LuggageType = LuggageType.Checked;
            }
            else {
                booking.LuggageType = LuggageType.Carry_on;
            }

            if (comboBox_cabintype.SelectedIndex == 0)
            {
                booking.CabinType = CabinType.Economy;
            }
            else if (comboBox_cabintype.SelectedIndex == 1)
            {
                booking.CabinType = CabinType.Business;
            }
            else
            {
                booking.CabinType = CabinType.First;
            }

            List<PremiumService> services = new List<PremiumService>();
            if (checkBox_meal.Checked)
            {
                PremiumService premiumService = new PremiumService();
                premiumService.ServiceName = "Airline Meal";
                premiumService.Price = 7;
                services.Add(premiumService);
            }
             if(checkBox_pickup.Checked)
            {
                PremiumService premiumService = new PremiumService();
                premiumService.ServiceName = "Airport Pickup";
                premiumService.Price = 12;
                services.Add(premiumService);
            }

            booking.PremiumServices = services; 
            booking.FinalPrice = finalPrice;
            booking.TotalPrice = totalPrice;
            booking.Discount = discount;

            MainForm.Bookings.Add(booking);

            MessageBox.Show("Saved successfully");

            if (comboBox_cabintype.SelectedIndex == 0)
            {
                MainForm.flights.First(t => t.FlightName == flight.FlightName).EconomyAvailable--; 
            }
            else if (comboBox_cabintype.SelectedIndex == 1)
            {
                MainForm.flights.First(t => t.FlightName == flight.FlightName).BusinessAvailable--;
            }
            else
            {
                MainForm.flights.First(t => t.FlightName == flight.FlightName).FirstAvailable--;
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
