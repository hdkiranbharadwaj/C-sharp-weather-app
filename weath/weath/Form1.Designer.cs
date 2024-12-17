namespace weath
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Button btnGetWeather;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblWindSpeed;
        private System.Windows.Forms.PictureBox picWeatherIcon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.btnGetWeather = new System.Windows.Forms.Button();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblWindSpeed = new System.Windows.Forms.Label();
            this.picWeatherIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWeatherIcon)).BeginInit();
            this.SuspendLayout();

            // lblCity
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCity.Location = new System.Drawing.Point(20, 20);
            this.lblCity.Text = "Enter City:";

            // txtCity
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCity.Location = new System.Drawing.Point(150, 20);
            this.txtCity.Size = new System.Drawing.Size(200, 29);

            // btnGetWeather
            this.btnGetWeather.Text = "Get Weather";
            this.btnGetWeather.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGetWeather.Location = new System.Drawing.Point(150, 60);
            this.btnGetWeather.Size = new System.Drawing.Size(200, 35);
            this.btnGetWeather.Click += new System.EventHandler(this.btnGetWeather_Click);

            // lblTemperature
            this.lblTemperature.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTemperature.Location = new System.Drawing.Point(20, 120);
            this.lblTemperature.Size = new System.Drawing.Size(300, 40);

            // lblCondition
            this.lblCondition.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblCondition.Location = new System.Drawing.Point(20, 170);
            this.lblCondition.Size = new System.Drawing.Size(300, 30);

            // lblHumidity
            this.lblHumidity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHumidity.Location = new System.Drawing.Point(20, 210);
            this.lblHumidity.Size = new System.Drawing.Size(300, 25);

            // lblWindSpeed
            this.lblWindSpeed.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblWindSpeed.Location = new System.Drawing.Point(20, 250);
            this.lblWindSpeed.Size = new System.Drawing.Size(300, 25);

            // picWeatherIcon
            this.picWeatherIcon.Location = new System.Drawing.Point(350, 120);
            this.picWeatherIcon.Size = new System.Drawing.Size(100, 100);
            this.picWeatherIcon.Click += new System.EventHandler(this.picWeatherIcon_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.btnGetWeather);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.lblHumidity);
            this.Controls.Add(this.lblWindSpeed);
            this.Controls.Add(this.picWeatherIcon);
            this.Text = "weath - Weather App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWeatherIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
