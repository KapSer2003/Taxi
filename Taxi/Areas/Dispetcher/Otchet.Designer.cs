
namespace Taxi.Areas.Dispetcher
{
    partial class Otchet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.number_lb = new System.Windows.Forms.Label();
            this.brand_lb = new System.Windows.Forms.Label();
            this.model_lb = new System.Windows.Forms.Label();
            this.classComfort_lb = new System.Windows.Forms.Label();
            this.statusCar_lb = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numberOrder_lb = new System.Windows.Forms.Label();
            this.phoneNumber_lb = new System.Windows.Forms.Label();
            this.stausOrd_lb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusCar_lb);
            this.groupBox1.Controls.Add(this.classComfort_lb);
            this.groupBox1.Controls.Add(this.model_lb);
            this.groupBox1.Controls.Add(this.brand_lb);
            this.groupBox1.Controls.Add(this.number_lb);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(419, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сведения об автомобиле";
            // 
            // number_lb
            // 
            this.number_lb.AutoSize = true;
            this.number_lb.Location = new System.Drawing.Point(6, 20);
            this.number_lb.Name = "number_lb";
            this.number_lb.Size = new System.Drawing.Size(63, 18);
            this.number_lb.TabIndex = 0;
            this.number_lb.Text = "Номер: ";
            // 
            // brand_lb
            // 
            this.brand_lb.AutoSize = true;
            this.brand_lb.Location = new System.Drawing.Point(6, 38);
            this.brand_lb.Name = "brand_lb";
            this.brand_lb.Size = new System.Drawing.Size(61, 18);
            this.brand_lb.TabIndex = 1;
            this.brand_lb.Text = "Марка: ";
            // 
            // model_lb
            // 
            this.model_lb.AutoSize = true;
            this.model_lb.Location = new System.Drawing.Point(6, 56);
            this.model_lb.Name = "model_lb";
            this.model_lb.Size = new System.Drawing.Size(68, 18);
            this.model_lb.TabIndex = 2;
            this.model_lb.Text = "Модель:";
            // 
            // classComfort_lb
            // 
            this.classComfort_lb.AutoSize = true;
            this.classComfort_lb.Location = new System.Drawing.Point(6, 74);
            this.classComfort_lb.Name = "classComfort_lb";
            this.classComfort_lb.Size = new System.Drawing.Size(136, 18);
            this.classComfort_lb.TabIndex = 3;
            this.classComfort_lb.Text = "Класс комфорта: ";
            // 
            // statusCar_lb
            // 
            this.statusCar_lb.AutoSize = true;
            this.statusCar_lb.Location = new System.Drawing.Point(6, 92);
            this.statusCar_lb.Name = "statusCar_lb";
            this.statusCar_lb.Size = new System.Drawing.Size(64, 18);
            this.statusCar_lb.TabIndex = 4;
            this.statusCar_lb.Text = "Статус: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stausOrd_lb);
            this.groupBox2.Controls.Add(this.phoneNumber_lb);
            this.groupBox2.Controls.Add(this.numberOrder_lb);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Общие сведения о заявке";
            // 
            // numberOrder_lb
            // 
            this.numberOrder_lb.AutoSize = true;
            this.numberOrder_lb.Location = new System.Drawing.Point(6, 20);
            this.numberOrder_lb.Name = "numberOrder_lb";
            this.numberOrder_lb.Size = new System.Drawing.Size(115, 18);
            this.numberOrder_lb.TabIndex = 0;
            this.numberOrder_lb.Text = "Номер заявки: ";
            // 
            // phoneNumber_lb
            // 
            this.phoneNumber_lb.AutoSize = true;
            this.phoneNumber_lb.Location = new System.Drawing.Point(6, 38);
            this.phoneNumber_lb.Name = "phoneNumber_lb";
            this.phoneNumber_lb.Size = new System.Drawing.Size(197, 18);
            this.phoneNumber_lb.TabIndex = 1;
            this.phoneNumber_lb.Text = "Номер телефона клиента: ";
            // 
            // stausOrd_lb
            // 
            this.stausOrd_lb.AutoSize = true;
            this.stausOrd_lb.Location = new System.Drawing.Point(6, 56);
            this.stausOrd_lb.Name = "stausOrd_lb";
            this.stausOrd_lb.Size = new System.Drawing.Size(64, 18);
            this.stausOrd_lb.TabIndex = 2;
            this.stausOrd_lb.Text = "Статус: ";
            // 
            // Otchet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Otchet";
            this.Text = "Отчёт по заявке №   ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label statusCar_lb;
        private System.Windows.Forms.Label classComfort_lb;
        private System.Windows.Forms.Label model_lb;
        private System.Windows.Forms.Label brand_lb;
        private System.Windows.Forms.Label number_lb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label stausOrd_lb;
        private System.Windows.Forms.Label phoneNumber_lb;
        private System.Windows.Forms.Label numberOrder_lb;
    }
}