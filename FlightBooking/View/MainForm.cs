using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Linq; 
using System.Windows.Forms;
using FlightBooking.Model; 

namespace FlightBooking
{
    public partial class MainForm : Form
    {
        public static  List<Flight> flights = new  List<Flight>();
        public static  List<Flight> searchedFlights = new  List<Flight>();
        public static List<Booking> Bookings = new List<Booking>();

        public MainForm()
        {
            InitializeComponent();
            InitData();
            ShowTable();
            InitDateTimePicker(this.dateTimePicker1);
        }

        private void ShowTable()
        {
            dataGridView1.DataSource = new BindingList<Flight>( flights);
        }

        private void InitData()
        {
            Flight flight=new Flight();
            flight.FlightName = "AU2312";
            flight.From = "Los Angeles";
            flight.To = "New York";
            flight.FlightDate = new DateTime(2020,12,28);
            flight.EconomyAvailable = 60;
            flight.BusinessAvailable = 20;
            flight.FirstAvailable = 10;
            flight.BasePrice = 100;
            flights.Add(flight);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            searchedFlights = flights; 
        }
         
        public  void InitDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";  
            dtp.ValueChanged -= DateTimePicker_ValueChanged;
            dtp.ValueChanged += DateTimePicker_ValueChanged;
            dtp.KeyPress -= DateTimePicker_KeyPress;
            dtp.KeyPress += DateTimePicker_KeyPress;
        }

        public   void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            dtp.Format = DateTimePickerFormat.Long;
            dtp.CustomFormat = null;  
            dtp.Checked = false; 
        }

        public   void DateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
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
            else {
                BookingForm bookingForm = new BookingForm(flights[dataGridView1.CurrentRow.Index]);
                bookingForm.ShowDialog();
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFlightForm addFlightForm = new AddFlightForm();
            addFlightForm.ShowDialog();
            if(addFlightForm.DialogResult==DialogResult.OK)
            {
                ShowTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookingListForm bookingListForm = new BookingListForm();
            bookingListForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword1 = textBox1.Text; 
            if (!String.IsNullOrWhiteSpace(keyword1))
            {
                searchedFlights = flights.Where(t => t.FlightName.Contains(keyword1)).ToList();
            }
            String keyword2 = textBox2.Text;
            if (!String.IsNullOrWhiteSpace(keyword2))
            {
                searchedFlights =  flights.Where(t => t.From.Contains(keyword2)).ToList();
            }
            String keyword3 = textBox3.Text;
            if (!String.IsNullOrWhiteSpace(keyword3))
            {
                searchedFlights = flights.Where(t => t.To.Contains(keyword3)).ToList();
            }

             DateTime dateTime = dateTimePicker1.Value;
            if ( !String.IsNullOrWhiteSpace( dateTimePicker1.Text ))
            {
                searchedFlights = flights.Where(t => t.FlightDate.Date== dateTime).ToList();
            }
             
            dataGridView1.DataSource = searchedFlights; 

            if (String.IsNullOrWhiteSpace(keyword1)&& String.IsNullOrWhiteSpace(keyword2)&& String.IsNullOrWhiteSpace(keyword3)
                && String.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                dataGridView1.DataSource = flights;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitDateTimePicker(this.dateTimePicker1);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = ""; 
        }
    }
}
