using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace weath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering for smooth gradient rendering
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Paint the gradient background
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.LightBlue,  // Starting color
                Color.MidnightBlue, // Ending color
                System.Drawing.Drawing2D.LinearGradientMode.Vertical)) // Gradient direction
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set PictureBox to transparent
            SetTransparentPictureBox(picWeatherIcon);

            // Set labels to transparent
            SetTransparentLabel(lblTemperature);
            SetTransparentLabel(lblCondition);
            SetTransparentLabel(lblHumidity);
            SetTransparentLabel(lblWindSpeed);

            // Display welcome message
            MessageBox.Show("Welcome to the Weather App!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picWeatherIcon_Click(object sender, EventArgs e)
        {
            // Code for PictureBox click event
            MessageBox.Show("This is the weather icon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text.Trim();

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please enter a valid city name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var weatherData = await GetWeatherDataAsync(city);
                if (weatherData != null)
                {
                    lblTemperature.Text = $"{weatherData.Temperature}°C";
                    lblCondition.Text = char.ToUpper(weatherData.Condition[0]) + weatherData.Condition.Substring(1);
                    lblHumidity.Text = $"Humidity: {weatherData.Humidity}%";
                    lblWindSpeed.Text = $"Wind: {weatherData.WindSpeed} m/s";

                    // Load the weather icon dynamically from CDN
                    LoadWeatherIcon(weatherData.IconCode);
                }
                else
                {
                    MessageBox.Show($"Could not fetch weather data for '{city}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<WeatherInfo> GetWeatherDataAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = "fc220d1745506595e73cc9c43852f308";
                string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
                string url = $"{baseUrl}?q={city}&units=metric&appid={apiKey}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return ParseWeatherData(responseData);
                }
                else
                {
                    return null;
                }
            }
        }

        private WeatherInfo ParseWeatherData(string jsonData)
        {
            var data = JObject.Parse(jsonData);
            return new WeatherInfo
            {
                Temperature = data["main"]["temp"].Value<float>(),
                Condition = data["weather"][0]["description"].Value<string>(),
                Humidity = data["main"]["humidity"].Value<int>(),
                WindSpeed = data["wind"]["speed"].Value<float>(),
                IconCode = data["weather"][0]["icon"].Value<string>() // Get the icon code from API
            };
        }

        private void LoadWeatherIcon(string iconCode)
        {
            string iconUrl = $"https://openweathermap.org/img/wn/{iconCode}@2x.png";

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Download and display the image
                    byte[] imageData = client.DownloadData(iconUrl);
                    using (var ms = new MemoryStream(imageData))
                    {
                        picWeatherIcon.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load icon from CDN: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picWeatherIcon.Image = null; // Clear the image on error
            }
        }

        private void SetTransparentPictureBox(PictureBox pictureBox)
        {
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Parent = this; // Set the parent as the form to inherit its background
            pictureBox.Refresh();
        }

        private void SetTransparentLabel(Label label)
        {
            label.BackColor = Color.Transparent;
            label.Parent = this; // Set the parent as the form to inherit its background
            label.Refresh();
        }
    }

    public class WeatherInfo
    {
        public float Temperature { get; set; }
        public string Condition { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public string IconCode { get; set; } // Added for dynamic icon loading
    }
}
