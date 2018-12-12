using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;

namespace JSON
{
    public partial class Form1 : Form
    {
        WebClient webClient = null;

        public Form1()
        {
            InitializeComponent();
            webClient = new WebClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String city = textCity.Text;
                var data =
                webClient.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=ec44ef5170a685de1464c39930c8fce4");
                JObject obj = JObject.Parse(data);
                labelCityName.Text = "" + obj["name"];
                labelCityName.ForeColor = Color.DodgerBlue;
                labelCityLongitude.Text = "" + obj["coord"]["lon"];
                labelCityLongitude.ForeColor = Color.DodgerBlue;
                labelCityLatitude.Text = "" + obj["coord"]["lat"];
                labelCityLatitude.ForeColor = Color.DodgerBlue;
                labelWeatherConditionID.Text = "" + obj["weather"][0]["id"];
                labelWeatherConditionID.ForeColor = Color.DodgerBlue;
                labelWeatherParameters.Text = "" + obj["weather"][0]["main"];
                labelWeatherParameters.ForeColor = Color.DodgerBlue;
                labelWeatherCondition.Text = "" + obj["weather"][0]["description"];
                labelWeatherCondition.ForeColor = Color.DodgerBlue;
            }
            catch (Exception ex)
            {
                labelCityName.Text = textCity.Text;
                labelCityName.ForeColor = Color.Firebrick;
                labelCityLongitude.Text = "Data not found";
                labelCityLongitude.ForeColor = Color.Firebrick;
                labelCityLatitude.Text = "Data not found";
                labelCityLatitude.ForeColor = Color.Firebrick;
                labelWeatherConditionID.Text = "Data not found";
                labelWeatherConditionID.ForeColor = Color.Firebrick;
                labelWeatherParameters.Text = "Data not found";
                labelWeatherParameters.ForeColor = Color.Firebrick;
                labelWeatherCondition.Text = "Data not found";
                labelWeatherCondition.ForeColor = Color.Firebrick;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(this, new EventArgs());
            }
        }
    }
}
