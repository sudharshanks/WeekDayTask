using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Response deserializedObj;
        Request serializableObj;

        private void Button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:53641/";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            var response = client.DownloadString(apiUrl + "api/WeekDay");
            deserializedObj = JsonConvert.DeserializeObject<Response>(response);
            responseCombo.DataSource = deserializedObj.WeekDaysList;

            this.responseCombo.SelectedIndexChanged += new System.EventHandler(this.ResponseCombo_SelectedIndexChanged);
        }

        private void ResponseCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = responseCombo.SelectedIndex;
            MessageBox.Show(deserializedObj.WeekDaysList[index] + " " + deserializedObj.WeekDayTimesList[index]);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.responseCombo.SelectedIndexChanged -= new System.EventHandler(this.ResponseCombo_SelectedIndexChanged);
            PopulateRequest();
            string apiUrl = "http://localhost:53641/";
            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyy hh:mm:ss"
            };
            string inputJson = JsonConvert.SerializeObject(serializableObj, Formatting.Indented);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            var response = client.UploadString(apiUrl + "api/WeekDay", inputJson);
            deserializedObj = JsonConvert.DeserializeObject<Response>(response);
            responseCombo.DataSource = deserializedObj.WeekDaysList;
            this.responseCombo.SelectedIndexChanged += new System.EventHandler(this.ResponseCombo_SelectedIndexChanged);
        }

        // Populate the request for all the date picker selections
        private void PopulateRequest()
        {
            serializableObj = new Request();
            serializableObj.InputDates = new List<DateTime>();
            serializableObj.InputDates.Add(dateTimePicker1.Value);
            serializableObj.InputDates.Add(dateTimePicker2.Value);
            serializableObj.InputDates.Add(dateTimePicker3.Value);
            serializableObj.InputDates.Add(dateTimePicker4.Value);
            serializableObj.InputDates.Add(dateTimePicker5.Value);
            serializableObj.InputDates.Add(dateTimePicker6.Value);
            serializableObj.InputDates.Add(dateTimePicker7.Value);
        }
    }
}
