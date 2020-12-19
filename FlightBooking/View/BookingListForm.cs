using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FlightBooking.Model;

namespace FlightBooking
{
    public partial class BookingListForm : Form
    {
        public BookingListForm()
        {
            InitializeComponent();
            ShowTable();
        }

        private void ShowTable()
        {
            var result = MainForm.Bookings.Select(t => new
            {
                FlightName = t.Flight.FlightName,
                Name = t.Passenger.Name,
                Number = t.Passenger.Number,
                IsVip = t.Passenger.IsVip,
                LuggageType = t.LuggageType,
                CabinType = t.CabinType,
                Count = t.PremiumServices.Count,
                FinalPrice = t.FinalPrice
            }).ToList();
            dataGridView1.DataSource = result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTable();
            InitDateTimePicker(this.dateTimePicker1);
        }


        public void InitDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";  //必须设置成" "
            dtp.ValueChanged -= DateTimePicker_ValueChanged;
            dtp.ValueChanged += DateTimePicker_ValueChanged;
            dtp.KeyPress -= DateTimePicker_KeyPress;
            dtp.KeyPress += DateTimePicker_KeyPress;
        }

        public void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Format = DateTimePickerFormat.Long;
            dtp.CustomFormat = null;
            dtp.Checked = false;
        }

        public void DateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                DateTimePicker dtp = (DateTimePicker)sender;
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = " ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a flight");
            }
            else
            {
                // BookingForm bookingForm = new BookingForm(flights[dataGridView1.CurrentRow.Index]);
                //  bookingForm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFlightForm addFlightForm = new AddFlightForm();
            addFlightForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword1 = textBox1.Text;
            List<Booking> temp = new List<Booking>();
            temp = MainForm.Bookings;
            if (!String.IsNullOrWhiteSpace(keyword1))
            {
                temp = MainForm.Bookings.Where(t => t.Flight.FlightName.Contains(keyword1)).ToList();
            }
            String keyword2 = textBox2.Text;
            if (!String.IsNullOrWhiteSpace(keyword2))
            {
                temp = MainForm.Bookings.Where(t => t.Passenger.Name.Contains(keyword2)).ToList();
            }

            DateTime dateTime = dateTimePicker1.Value;
            if (!String.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                temp = MainForm.Bookings.Where(t => t.BookingDate == dateTime).ToList();
            }

            var result = temp.Select(t => new
            {
                FlightName = t.Flight.FlightName,
                Name = t.Passenger.Name,
                Number = t.Passenger.Number,
                IsVip = t.Passenger.IsVip,
                LuggageType = t.LuggageType,
                CabinType = t.CabinType,
                Count = t.PremiumServices.Count,
                FinalPrice = t.FinalPrice
            }).ToList();
            dataGridView1.DataSource = result;
             
        }
    }
}
